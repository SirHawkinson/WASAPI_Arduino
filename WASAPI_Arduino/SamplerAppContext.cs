using WASAPI_Arduino.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports;
using System.Collections.Generic;
using System.Linq;

namespace WASAPI_Arduino
{

    /*
     * Application context frame. Since the app runs only in the quick bar (so no windows or forms)
     * you can only interact with the program by enabling or disabling it on left click. You can
     * access its menu (COM Port,refresh rate selection and exit). 
     */
    public class SamplerAppContext : ApplicationContext
    {

        // Refresh rate options.
        public const double Slow_MS = 1000 / 30.0;
        public const double Med_MS = 1000 / 60.0;
        public const double Fast_MS = 1000 / 120.0;
        public const double regularLEDStrip_MS = 1000 / 400.0;
        public const double fastestLEDStrip_MS = 1000 / 1000.0;
        public const double regular_MS = 1000 / 44100.0;
        public const double double_MS = 1000 / 88200.0;

        // The systray icon and main app control.
        private NotifyIcon systrayIcon;
        private SamplerApp SamplerApp;
        private Form1 CorrectorForm;
        private Form2 Help;
        private SpecifyStrip stripForm;
        // Forms init


        // Set the program as disabled, COMPort as null by default and get settings indexes.
        private Boolean enabled = false;
        public Boolean correctorOpen = false;
        public Boolean formOpen = false;
        private string selectedPort;
        private int portIndex = Settings.Default.portIndex;
        private int updateSpeedIndex = Settings.Default.updateSpeedIndex;
        private int audioHandlingIndex = Settings.Default.audioHandlingIndex;
        
        /*
         * Set up the application. Configures the main app handler, creates and initializes the
         * systray icon and its context menu, and makes the icon visible.
         */
        public SamplerAppContext()
        {

            // Create on exit handler and application data file handling.
            SamplerApp = new SamplerApp();
            this.selectedPort = Settings.Default.Port;

            MenuItem COMList = new MenuItem("COM List");

            List<string> portList = COMlist();
            COMlist().ForEach(COM => COMList.MenuItems.Add(new MenuItem(COM, (s, e) => GetCOMIndex(s, COM.ToString(), portList))));
            systrayIcon = new NotifyIcon();

            systrayIcon.ContextMenu = new ContextMenu(new MenuItem[] {
                COMList,
                new MenuItem("Update Speed", new MenuItem[] {
                    new MenuItem("Slow (30Hz)", (s, e) => UpdateSpeed_Click(s, Slow_MS, 0)),
                    new MenuItem("Medium (60Hz)", (s, e) => UpdateSpeed_Click(s, Med_MS, 1)),
                    new MenuItem("Fast (120Hz)", (s, e) => UpdateSpeed_Click(s, Fast_MS, 2)),
                    new MenuItem("Regular LED Strip (400Hz)", (s, e) => UpdateSpeed_Click(s, regularLEDStrip_MS, 3)),
                    new MenuItem("Fastest LED strip (1000Hz)", (s, e) => UpdateSpeed_Click(s, fastestLEDStrip_MS, 4)),
                    new MenuItem("Regular audio output (44100Hz)", (s, e) => UpdateSpeed_Click(s, regular_MS,5)),
                    new MenuItem("Studio audio output (88200Hz)", (s,e) => UpdateSpeed_Click(s, double_MS, 6))
                }),
                new MenuItem("Sound columns", new MenuItem[]{
                    new MenuItem("Bass", (s,e) => AudioRange_Handling(s,true,0)),
                    new MenuItem("Octaves", (s,e) => AudioRange_Handling(s,false,1)),
                    }),
                new MenuItem("Corrector", Corrector),
                new MenuItem("Change colour",new MenuItem[]{
                    new MenuItem("Global change", Palette),
                    new MenuItem("Multiple strips", NextLed)}),
                new MenuItem("Help",HelpForm),
                new MenuItem("Exit WASAPI Arduino", OnApplicationExit)
            });

            // Default options precheck.
            systrayIcon.ContextMenu.MenuItems[0].MenuItems[portIndex].Checked = true;
            systrayIcon.ContextMenu.MenuItems[1].MenuItems[updateSpeedIndex].Checked = true;
            systrayIcon.ContextMenu.MenuItems[2].MenuItems[audioHandlingIndex].Checked = true;
            systrayIcon.MouseClick += SystrayIcon_Click;
            systrayIcon.Icon = Icon.FromHandle(Resources.WASAPI_ArduinoOFF.GetHicon());
            systrayIcon.Text = "WASAPI Arduino";
            systrayIcon.Visible = true;
            if (Settings.Default.ranalready == true)
            {
                SamplerApp.COMSetColour(Settings.Default.hex);
            }
            
        }

        /*
         * Application exit callback handler. Properly dispose of device capture. Set the systray
         * icon to false to keep it from hanging around until the user mouses over it.
         */
        public void OnApplicationExit(object sender, EventArgs e)
        {
            SamplerApp.Shutdown(sender, e);
            systrayIcon.Visible = false;
            Settings.Default.ranalready = true;
            Application.Exit();
        }
        
        private void Corrector(object sender, EventArgs e)
        {
            if(CorrectorForm == null)
                CorrectorForm = new Form1();
            else if (CorrectorForm.IsDisposed==true)
                CorrectorForm = new Form1();
            if (CorrectorForm.Created == true)
                CorrectorForm.BringToFront();
            else
                CorrectorForm.Show();            
        }
        private void HelpForm(object sender, EventArgs e)
        {
            if (Help == null)
                Help = new Form2();
            else if (Help.IsDisposed == true)
                Help = new Form2();
            if (Help.Created == true)
                Help.BringToFront();
            else
                Help.Show();
        }
        private void NextLed(object sender, EventArgs e)
        {
            if (stripForm == null)
                stripForm = new SpecifyStrip();
            else if (stripForm.IsDisposed == true)
                stripForm = new SpecifyStrip();
            if (stripForm.Created == true)
                stripForm.BringToFront();
            else
                stripForm.Show();         
        }

        // Function creating a new RGB palette, setting an adjacent byte and sending it to Arduino.
        private void Palette(object sender, EventArgs e)
        {
            colourDlg DialogForm = new colourDlg();
            string RGB = DialogForm.getColours();
            if (RGB!=null)
            SamplerApp.COMSetColour(RGB);
        }
                
        public void NextLEDSend(byte[]RGB, int LEDNumber)
        {
            SamplerApp.COMSetColour(RGB, LEDNumber);
        }

        // Get a list of serial port names, failsafe in case it will not detect any devices.
        private List<string> COMlist()
        {
            string[] ports = SerialPort.GetPortNames();
            if (ports.Length == 0)
            {
                MessageBox.Show("No connected USB device detected. WASAPI Arduino will shutdown.",
                                "No available ports detected.", MessageBoxButtons.OK);
                return null;                
            }

            else
            {
                List<string> list = ports.ToList();
                return list;
            }
        }

        // Select COM port to send data to.
        private void SetCOMPort(object sender, string port, int COMindex)
        {
            CheckMeAndUncheckSiblings((MenuItem)sender);
            SamplerApp.Selected_COMPort(port);
            selectedPort = port;
            Settings.Default.Port = port;
            Settings.Default.portIndex = COMindex;
        }

        /*
         * Left click callback handler. Enables/disables, switches between icons.
         */        
        private void SystrayIcon_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                // No device selected handling
                if (string.IsNullOrEmpty(selectedPort))
                {
                    MessageBox.Show("Please select a port.",
                              "No port selected.", MessageBoxButtons.OK);
                }
                else
                {
                    enabled = !enabled;

                    // Icon switching
                    if (enabled == true)
                        systrayIcon.Icon = Icon.FromHandle(Resources.WASAPI_ArduinoON.GetHicon());
                    else
                        systrayIcon.Icon = Icon.FromHandle(Resources.WASAPI_ArduinoOFF.GetHicon());

                    SamplerApp.SetEnabled(enabled);
                }
            }            
        }

        /*
         * Speed options callback handler. Sets the tick/render speed in the app.
         */
        private void UpdateSpeed_Click(object sender, double intervalMs, int intervalIndex)
        {
            CheckMeAndUncheckSiblings((MenuItem)sender);
            SamplerApp.UpdateTickSpeed(intervalMs);
            Settings.Default.UpdateSpeed = intervalMs;
            Settings.Default.updateSpeedIndex = intervalIndex;
        }
       
        // Set audio handling.
        private void AudioRange_Handling(object sender, bool Bass, int index)
        {
            CheckMeAndUncheckSiblings((MenuItem)sender);            
            SamplerApp.bassBased = Bass;
            Settings.Default.bassBased = Bass;
            Settings.Default.audioHandlingIndex = index;
        }
        private void GetCOMIndex(object sender, string port, List<string> COMList)
        {
            foreach (string listPort in COMList)
            {
                if (port == listPort)
                {
                    SetCOMPort(sender, port, COMList.IndexOf(listPort));
                }
            }

        }
        // Deactivate other list options after pressing one.
        private void CheckMeAndUncheckSiblings(MenuItem me)
        {
            foreach (MenuItem child in me.Parent.MenuItems)
            {
                child.Checked = child == me;
            }
        }
    }   
} 