using CSCore.DSP;
using System;
using System.Collections.Generic;

namespace WASAPI_Arduino
{

    public class SampleHandler
    {
        // Different data handling approach.
        private List<float> _spectrumData;

        // Basic FFT constants.
        const FftSize fftSize = FftSize.Fft2048;
        const int fftSizeInt = (int)fftSize;

        
        /*
        * Drop the index to 0 if below this threshold. Helps prevent lingering color after sound
        * has stopped. Value in amplitude (10^(dB/20) as a reminder), 0.001 means any signal below
        * -60dB (30dB when related to 90dB output) will be ignored.
        */
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
        float[] firstData = new float[10];

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
        public double[] GetSpectrumValues(double smoothing, double[] correctorColumns)
        {
            double preamp = correctorColumns[10];

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

                    foreach (float data in _spectrumData)
                        firstData = _spectrumData.ToArray();

                    if (Properties.Settings.Default.corrector)
                    /*
                    * Do not apply the corrector when output is less than -100dB, will prevent constant
                    * strip light up. The next part is rather stupid - convert output and corrector to dB,
                    * add them then convert back to amplitude. I'm too bad at math to do it in a better way.
                    */
                    if (_spectrumData[spectrumColumn] > 0.00001)
                    {
                            _spectrumData[spectrumColumn] = (float)(20 * Math.Log(_spectrumData[spectrumColumn], 10));
                            _spectrumData[spectrumColumn] = _spectrumData[spectrumColumn]+ (float)correctorColumns[spectrumColumn] + (float)preamp;
                            _spectrumData[spectrumColumn] = (float)(Math.Pow(10, (_spectrumData[spectrumColumn] / 20)));
                    }
                    
                    /*
                    * Output is in amplitude, using a dB level for our purpose generates so little dB difference
                    * between beats it's not even introducing a flicker. Also, values are so high, you can't even 
                    * use a positive corrector, else you're stuck with constant 100s. I'm including a dB method 
                    * as a comment, if you want to use it, but there's no practical reason to do so.
                    */
                    for (int i = 0; i < _spectrumData.ToArray().Length; i++)
                    {

                        try
                        {
                           // double dBscaled = (20*Math.Log(_spectrumData[i],10)+90);
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


