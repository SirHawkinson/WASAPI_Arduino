using CSCore.DSP;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoundSampler
{

    public class SampleHandler
    {
        // Different data handling approach.
        private List<float> _spectrumData;

        // Basic FFT constants.
        const FftSize fftSize = FftSize.Fft2048;
        const int fftSizeInt = (int)fftSize;

        

        // Drop the index to 0 if below this threshold. Helps prevent lingering color after sound
        // has stopped.
        const float minThreshold = 0.001f;

        /* 
         * The number of index points to take from the raw FFT data. Number of columns corresponds
         * with a standard 10 bands equalizers and octaves.
         */

        public const int columns = 10;
        public const int indexes = columns + 1;

        // FFT fields for CSCore FFT.
        FftProvider fftProvider;
        float[] fftBuf;

        /*
         * Initialize the SampleHandler with the number of audio channels and the sample rate
         * taken from system config.
         */

        // Previous-sample spectrum data, used for smoothing out the output.
        double[] prevSpectrumValues = new double[columns];

        public SampleHandler()
        {
        }
        public SampleHandler(int channels)
        {
            // Setup an FFT data provider with number of channels taken from system audio settings, buffer size and
            // a list of FFT results assigned.
            fftProvider = new FftProvider(channels, fftSize);
            fftBuf = new float[fftSizeInt];
            _spectrumData = new List<float>();
        }
        
        /*
         * Add a single block to the FFT data.
         */
        public void Add(float left, float right)
        {
            fftProvider.Add(left, right);
        }
        
        /*
         Get the current array of sample data by running the FFT and massaging the output. 
        */
        public double[] GetSpectrumValues(double smoothing)
        {
            // Check for no data coming through FFT and send null if true
            if (!fftProvider.IsNewDataAvailable)
            {
                // Real-time debug only
                // Console.WriteLine("no new data available");
                return null;
            }

            else

                // Do the FFT
                fftProvider.GetFftData(fftBuf);

            // Assign to frequency bands
            double[] spectrumValues = new double[columns];

            // This assigns results kind of properly to 10-band octaves but still have ginormous leakage when presented 
            // with a single frequency. Code taken from https://github.com/m4r1vs/Audioly

            {
                int spectrumColumn;
                float peak;
                int indexTick = 0;
                int fftIdxs = 1023;
                for (spectrumColumn = 0; spectrumColumn < columns; spectrumColumn++)
                {
                    double max = 0;
                    int Idxs = (int)Math.Pow(2, spectrumColumn * 10.0 / (columns - 1));
                    if (Idxs > fftIdxs)
                        Idxs = fftIdxs;
                    if (Idxs <= indexTick)
                        Idxs = indexTick + 1;
                    for (; indexTick < Idxs; indexTick++)
                    {
                        if (max < fftBuf[1 + indexTick])
                            max = fftBuf[1 + indexTick];
                    }
                    peak = (float)max;

                    // Peak exceeding 0-100 handling. Not that it happens;
                    if (peak > 100) peak = 100;
                    if (peak < 0) peak = 0;
                    _spectrumData.Add(peak);
                    
                    // Output is in amplitude, using a dB level for our purpose generates so little dB difference
                    // between beats it's mostly a flicker than brightness change. I'm including a dB method as a 
                    // comment, if you want to use it, there's no practical reason to do so.
                    for (int i = 0; i < _spectrumData.ToArray().Length; i++)
                    {

                        try
                        {
                            // double dBscaled = (20*Math.Pow(_spectrumData[i]+90);
                            // double Smoothed = prevSpectrumValues[i] * smoothing + dBscaled * (1 - smoothing);
                            double Smoothed = prevSpectrumValues[i] * smoothing + _spectrumData[i] * (1 - smoothing);
                            spectrumValues[i] = Smoothed < minThreshold ? 0 : Smoothed;
                        }
                        catch (Exception)
                        {
                        }
                    }
                }


                // Clear the _spectrumData from any previous results for new FFT data.
                _spectrumData.Clear();
                return prevSpectrumValues = spectrumValues;
            }
        }
    }
}
