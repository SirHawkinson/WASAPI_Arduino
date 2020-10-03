using System;
using System.Windows.Forms;
using WASAPI_Arduino.Properties;
using System.Drawing;

namespace WASAPI_Arduino
{
    public partial class SpecifyStrip : Form
    {
        private int CustomC1 = Properties.Settings.Default.CustomC1;
        private int CustomC2 = Properties.Settings.Default.CustomC2;
        private int CustomC3 = Properties.Settings.Default.CustomC3;
        private int CustomC4 = Properties.Settings.Default.CustomC4;
        private int CustomC5 = Properties.Settings.Default.CustomC5;
        private int CustomC6 = Properties.Settings.Default.CustomC6;
        private int CustomC7 = Properties.Settings.Default.CustomC7;
        private int CustomC8 = Properties.Settings.Default.CustomC8;
        private int CustomC9 = Properties.Settings.Default.CustomC9;
        private int CustomC10 = Properties.Settings.Default.CustomC10;
        private int CustomC11 = Properties.Settings.Default.CustomC11;
        private int CustomC12 = Properties.Settings.Default.CustomC12;
        private int CustomC13 = Properties.Settings.Default.CustomC13;
        private int CustomC14 = Properties.Settings.Default.CustomC14;
        private int CustomC15 = Properties.Settings.Default.CustomC15;
        private int CustomC16 = Properties.Settings.Default.CustomC16;

        public SpecifyStrip()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Field is empty.",
                          "No LED strip selected.", MessageBoxButtons.OK);
            }

            else
            {
                SamplerApp SamplerApp = new SamplerApp();
                byte[] RGB = getColours();
                int LEDNumber = int.Parse(textBox1.Text);
                SamplerApp.COMSetColour(RGB, LEDNumber);
            }
            
        }   

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        public byte[] getColours()
        {            
            ColorDialog colourDlg = new ColorDialog();
            colourDlg.AllowFullOpen = true;
            colourDlg.FullOpen = true;
            colourDlg.AnyColor = true;
            colourDlg.SolidColorOnly = false;

            // Atrocious workaround on no native int array support, using Int32[] in settings.settings
            // does not work properly and breaks the FFT somehow
            colourDlg.CustomColors = new int[] { CustomC1, CustomC2, CustomC3, CustomC4, CustomC5, CustomC6,
                CustomC7,CustomC8,CustomC9,CustomC10,CustomC11,CustomC12,CustomC13,CustomC14,CustomC15,CustomC16,};
            colourDlg.Color = Settings.Default.Colour;

            if (colourDlg.ShowDialog() == DialogResult.OK)
            {                
                Color colour = colourDlg.Color;
                byte R = colour.R;
                byte G = colour.G;
                byte B = colour.B;
                byte[] RGB = { R, G, B };

                Settings.Default.Colour = colour;
                Properties.Settings.Default.CustomC1 = colourDlg.CustomColors[0];
                Properties.Settings.Default.CustomC2 = colourDlg.CustomColors[1];
                Properties.Settings.Default.CustomC3 = colourDlg.CustomColors[2];
                Properties.Settings.Default.CustomC4 = colourDlg.CustomColors[3];
                Properties.Settings.Default.CustomC5 = colourDlg.CustomColors[4];
                Properties.Settings.Default.CustomC6 = colourDlg.CustomColors[5];
                Properties.Settings.Default.CustomC7 = colourDlg.CustomColors[6];
                Properties.Settings.Default.CustomC8 = colourDlg.CustomColors[7];
                Properties.Settings.Default.CustomC9 = colourDlg.CustomColors[8];
                Properties.Settings.Default.CustomC10 = colourDlg.CustomColors[9];
                Properties.Settings.Default.CustomC11 = colourDlg.CustomColors[10];
                Properties.Settings.Default.CustomC12 = colourDlg.CustomColors[11];
                Properties.Settings.Default.CustomC13 = colourDlg.CustomColors[12];
                Properties.Settings.Default.CustomC14 = colourDlg.CustomColors[13];
                Properties.Settings.Default.CustomC15 = colourDlg.CustomColors[14];
                Properties.Settings.Default.CustomC16 = colourDlg.CustomColors[15];
                Settings.Default.Save();
                return RGB;
            }

            else
            {
                return null;
            }
        }
    }
}
