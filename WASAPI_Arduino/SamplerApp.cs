using CSCore;
using CSCore.SoundIn;
using CSCore.Streams;
using System;
using System.Timers;
using System.IO.Ports;
using System.Threading;
using System.Drawing;

namespace WASAPI_Arduino
{
    /*
     Audio capture, USB handling, settings and variables initializator. 
     */
    public class SamplerApp
    {
        
        // Serial ports initialization variables
        static SerialPort serialPort;
        private string Port;
        private int baud;

        // Ticker that triggers audio re-rendering. User-controllable via the systray menu
        private System.Timers.Timer ticker;

        // Corrector columns that are applied when the corrector box is checked.
        public double Hz31Column = Properties.Settings.Default.Hz31;
        public double Hz62Column = Properties.Settings.Default.Hz62;
        public double Hz125Column = Properties.Settings.Default.Hz125;
        public double Hz250Column = Properties.Settings.Default.Hz250;
        public double Hz500Column = Properties.Settings.Default.Hz500;
        public double Hz1000Column = Properties.Settings.Default.Hz1000;
        public double Hz2000Column = Properties.Settings.Default.Hz2000;
        public double Hz4000Column = Properties.Settings.Default.Hz4000;
        public double Hz8000Column = Properties.Settings.Default.Hz8000;
        public double Hz16000Column = Properties.Settings.Default.Hz16000;
        public double preamp = Properties.Settings.Default.preamp;
        public double[] correctors = new double[11];
        public double[] zero = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] valuesToSend = new double[11];

        // Interrupt byte to send to Arduino for setting colours 
        byte[] interrupt = BitConverter.GetBytes(101); 

        /* The weight given to the previous sample for time-based smoothing. High value works great when 
         * sending it to the LED strip when the software is set to a high refresh rate, making the 
         * transition between values much milder, lower values increase accuracy of sampling.
         * Setting it too low on a high refreshed stripe introduces VERY annoying flicker. 
         */
        public double smoothing = Properties.Settings.Default.smoothing;

        // CSCore classes that read the WASAPI data and pass it to the SampleHandler
        private WasapiCapture wasapiCapture;
        private SingleBlockNotificationStream notificationSource;
        private IWaveSource finalSource;

        // In-program class calls
        private SampleHandler SampleHandler;
        private Handler Handler;

        // Declaration of a switch for swapping between 3-columns and octave audio handling, by default it will 
        // use octaves to analyze sound.
        public Boolean bassBased;
        private Boolean reload;

        /*
         * Basic initialization. No audio is read until SetEnable(true) is called.
         */
        public SamplerApp()
        {
            // Init the timer
            ticker = new System.Timers.Timer(Properties.Settings.Default.UpdateSpeed);
            ticker.Elapsed += Tick;

            // Init the output modifiers 
            
            this.correctors = new double[11] {Hz31Column,Hz62Column,Hz125Column,Hz250Column,Hz500Column,
            Hz1000Column,Hz2000Column,Hz4000Column,Hz8000Column,Hz16000Column,preamp};
            this.smoothing = Properties.Settings.Default.smoothing;
            this.bassBased = Properties.Settings.Default.bassBased;

            // Init the COM port and USB baud rate.
            this.Port = Properties.Settings.Default.Port;
            this.baud = 115200;


            // Create a handler
            Handler = new Handler();
        }

        /*
         * Enable or disable audio capture.
         */
        public void SetEnabled(bool enabled)
        {
            if (enabled)
            {

                    serialPort = new SerialPort(Port, baud);
                    // serialPort.ReadTimeout = 250;
                    // serialPort.WriteTimeout = 250;
                try
                {
                    if (serialPort.IsOpen == false)
                    {
                        serialPort.Open();
                    }

                    // Apply saved colour when starting capture
                    Color colour = Properties.Settings.Default.Colour;
                    byte R = colour.R;
                    byte G = colour.G;
                    byte B = colour.B;
                    byte[] RGB = { R, G, B };
                    COMSetColour(RGB);
                    StartCapture();
                    ticker.Start();
                    
                }
                catch(Exception)
                    {

                }
            }
            else
            {
                StopCapture();

                // Send zero bit through port, this will force LEDs to blackout
                byte[] end =BitConverter.GetBytes(0);
                serialPort.Write(end, 0, 1);
                if (serialPort.IsOpen == true)
                {
                    serialPort.Close();
                }
                ticker.Stop();
                
            }
        }

        // Convert data to bits then send through selected COM
        public void COMSend(int data)
        {
            byte[] b = BitConverter.GetBytes(data);
            serialPort.Write(b, 0, 1);
            
        }
               
        public void COMSetColour(byte[] data)
        {
            
            if (serialPort.IsOpen == false)
            {
                serialPort.Open();
            }
            ticker.Stop();
            Thread.Sleep(10); // Use if there are issues with sending the colour information
            serialPort.Write(interrupt, 0, 1);
            serialPort.Write(data, 0, 3);
            Thread.Sleep(10);
            ticker.Start();
        }
        
        /*
         * Update the timer tick speed, which updates the FFT and sound rendering speeds(?).
         */
        public void UpdateTickSpeed(double intervalMs)
        {
            ticker.Interval = intervalMs;
        }

        // Overwrite the default null COMPort
        public void Selected_COMPort(string COMPort)
        {
            Port = COMPort;
        }

        
        /*
         * Disable the program upon shutting down to clear data and close ports without having to pause the program beforehand.
         * With no exception catching the program would throw an error upon shutting it down. Gotta love the try-catch.
         */
        public void Shutdown(object sender, EventArgs e)
        {
            try
            {
                SetEnabled(false);
            }
            catch (Exception)
            {
            }
            Properties.Settings.Default.Save();
        }

       
        /*
         * Ticker callback handler. Performs the actual FFT, massages the data into raw spectrum
         * data, and sends it to handler.
         */
        private void Tick(object sender, ElapsedEventArgs e)
        {
            reload = Properties.Settings.Default.reload;

            if (reload)
            { // Reinitialize columns only if the "reload" bool is true, saves computing power (oy, this isn't
              // Pentium IV times!! *Who cares*).
                double smoothing = Properties.Settings.Default.smoothing;
                double Hz31Column = Properties.Settings.Default.Hz31;
                double Hz62Column = Properties.Settings.Default.Hz62;
                double Hz125Column = Properties.Settings.Default.Hz125;
                double Hz250Column = Properties.Settings.Default.Hz250;
                double Hz500Column = Properties.Settings.Default.Hz500;
                double Hz1000Column = Properties.Settings.Default.Hz1000;
                double Hz2000Column = Properties.Settings.Default.Hz2000;
                double Hz4000Column = Properties.Settings.Default.Hz4000;
                double Hz8000Column = Properties.Settings.Default.Hz8000;
                double Hz16000Column = Properties.Settings.Default.Hz16000;
                double preamp = Properties.Settings.Default.preamp;
                this.preamp = Properties.Settings.Default.preamp;
                this.smoothing = smoothing;
                this.correctors = new double[11] {Hz31Column,Hz62Column,Hz125Column,Hz250Column,Hz500Column,
            Hz1000Column,Hz2000Column,Hz4000Column,Hz8000Column,Hz16000Column,preamp};
                Properties.Settings.Default.reload = false;
            }
            // Get the FFT results and send to Handler with method as a results handling variable.


            if (!Properties.Settings.Default.corrector)
                valuesToSend = zero;
            else
                valuesToSend = correctors;
                double[] values = SampleHandler.GetSpectrumValues(smoothing, valuesToSend);
           
                Handler.SendData(values, bassBased);
        }

        
        /*
         * Initializes WASAPI, initializes the sample handler, and sends captured data to it.
         */
        private void StartCapture()
        {
            // Initialize hardware capture
            wasapiCapture = new WasapiLoopbackCapture(10);
            wasapiCapture.Initialize();

            // Initialize sample handler
            SampleHandler = new SampleHandler(wasapiCapture.WaveFormat.Channels);

            // Configure per-block reads rather than per-sample reads
            notificationSource = new SingleBlockNotificationStream(new SoundInSource(wasapiCapture).ToSampleSource());
            notificationSource.SingleBlockRead += (s, e) => SampleHandler.Add(e.Left, e.Right);
            finalSource = notificationSource.ToWaveSource();
            wasapiCapture.DataAvailable += (s, e) => finalSource.Read(e.Data, e.Offset, e.ByteCount);

            // Start capture
            wasapiCapture.Start();
        }

        /*
         * Stop the audio capture, if currently recording. Properly disposes member objects.
         */
        private void StopCapture()
        {
            if (wasapiCapture.RecordingState == RecordingState.Recording)
            {
                wasapiCapture.Stop();

                finalSource.Dispose();
                notificationSource.Dispose();
                wasapiCapture.Dispose();

                SampleHandler = null;
            }
        }

    }
}