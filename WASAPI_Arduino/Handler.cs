using System;
using System.Linq;

namespace WASAPI_Arduino
{
    public class Handler
    {
        /* 
        *  During normalization, scale the FFT values by the maximum value seen for smooth
        *  operation. Maximum value in current iteration gets multiplied by the entropy
        *  value, so the transition with each tick is smooth.
        */
        private double entropy = Properties.Settings.Default.entropy;
        public double maxSeenEver = 0;

        /* This is the value that basically serves as a "volume" bar and sets a maximum signal value
         * feed to the Arduino. In example, if you drive your LED strip by a variable brightness,
         * setting the "height" variable to a 100 gives you an output of 0-100, which correlates
         * with the range of brightness setting of any (I think) device. Whereas putting it below 100
         * restricts the brightness to that value, so it's 0-x. Great if you want to avoid being blinded
         * and still have the jumping lights effect in accordance to audio input.
        */
        private int height = Properties.Settings.Default.height;

        private Boolean reload;

        /*
        * Handling of raw (massaged) FFT'ed spectrum data. 
        */

        public void SendData(double[] raw, bool bassBased)
        {
            
            double[] normalized = Normalize(raw, bassBased);
            int filtered = Filter(normalized);
            // Real-time debug only
            // Console.WriteLine(string.Join(" Handler ", normalized));
            SamplerApp samp = new SamplerApp();
            // Send filtered column to COM
            samp.COMSend(filtered);

        }
        
        /*
         * Filter columns to get a highest column, rounded to integer
         */
        private int Filter(double[] normalized)
        {
            return Convert.ToInt32(normalized.Max());
        }

        /*
        * Normalize the raw data into values between 0 and the something. The max value is subject to entropy so large spikes don't
        * ruin the cool.
        */
        private double[] Normalize(double[] raw, bool bass)
        {

            int height = Properties.Settings.Default.height;
            reload = Properties.Settings.Default.reload;
            if (reload)
            {
                this.height = Properties.Settings.Default.height;
                Properties.Settings.Default.reload = false;
            }


            // Apply 3-column normalization
            if (bass == true)
            {
                int bassBasedColumns = 3;
                double[] normalized = new double[bassBasedColumns];

                // Use maxSeenEver to normalize the range into 0-Height
                maxSeenEver = Math.Max(raw.Max(), maxSeenEver);

                    for (int i = 0; i < bassBasedColumns; i++)
                    {
                        normalized[i] = raw[i] / maxSeenEver * height;
                        if (normalized[i] > height)
                            normalized[i] = height;
                        else if(normalized[i] <0)
                            normalized[i] = 0;
                    }
                
                
                    for (int i = 0; i < bassBasedColumns; i++)
                    {
                        normalized[i] = raw[i] / maxSeenEver * height;
                    }
                
            maxSeenEver *= entropy;
                
            return normalized;
            }

            // Apply octaves based normalization
               else
               { 
                    double[] normalized = new double[raw.Length];

              // Use maxSeenEver to normalize the range into 0-Height
                    maxSeenEver = Math.Max(raw.Max(), maxSeenEver);

                    // Check for corrector checkbox checked status and apply corrector if true.
                    
                        for (int i = 0; i < raw.Length; i++)
                        {
                            normalized[i] = raw[i] / maxSeenEver * height;
                        }
               
            maxSeenEver *= entropy;
            return normalized;
               }
            // Slowly decrease maxEverSeen to keep things normalizing after a giant spike
            
        }

      
    }
}