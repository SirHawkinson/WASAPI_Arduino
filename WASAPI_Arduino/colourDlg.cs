using WASAPI_Arduino.Properties;
using System.Drawing;
using System.Windows.Forms;

namespace WASAPI_Arduino
{
    public partial class colourDlg : Form
    {
        private ColorDialog colourDialog;
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

        public colourDlg()
        {
            InitializeComponent();
            colourDialog = new ColorDialog();
            Dispose();
            Close();
        }

        public string getColours()
        {
            colourDialog.AllowFullOpen = true;
            colourDialog.FullOpen = true;
            colourDialog.AnyColor = true;
            colourDialog.SolidColorOnly = false;

            // Atrocious workaround on no native int array support, using Int32[] in settings.settings
            // does not work properly and breaks the FFT somehow
            colourDialog.CustomColors = new int[] { CustomC1, CustomC2, CustomC3, CustomC4, CustomC5, CustomC6,
                CustomC7,CustomC8,CustomC9,CustomC10,CustomC11,CustomC12,CustomC13,CustomC14,CustomC15,CustomC16,};
            colourDialog.Color = Settings.Default.Colour;

            if (colourDialog.ShowDialog() == DialogResult.OK)
            {
                Color colour = colourDialog.Color;
                int R = colour.R;
                int G = colour.G;
                int B = colour.B;
                string hex = R.ToString("X2") + G.ToString("X2") + B.ToString("X2");

                Settings.Default.Colour = colour;
                Properties.Settings.Default.CustomC1 = colourDialog.CustomColors[0];
                Properties.Settings.Default.CustomC2 = colourDialog.CustomColors[1];
                Properties.Settings.Default.CustomC3 = colourDialog.CustomColors[2];
                Properties.Settings.Default.CustomC4 = colourDialog.CustomColors[3];
                Properties.Settings.Default.CustomC5 = colourDialog.CustomColors[4];
                Properties.Settings.Default.CustomC6 = colourDialog.CustomColors[5];
                Properties.Settings.Default.CustomC7 = colourDialog.CustomColors[6];
                Properties.Settings.Default.CustomC8 = colourDialog.CustomColors[7];
                Properties.Settings.Default.CustomC9 = colourDialog.CustomColors[8];
                Properties.Settings.Default.CustomC10 = colourDialog.CustomColors[9];
                Properties.Settings.Default.CustomC11 = colourDialog.CustomColors[10];
                Properties.Settings.Default.CustomC12 = colourDialog.CustomColors[11];
                Properties.Settings.Default.CustomC13 = colourDialog.CustomColors[12];
                Properties.Settings.Default.CustomC14 = colourDialog.CustomColors[13];
                Properties.Settings.Default.CustomC15 = colourDialog.CustomColors[14];
                Properties.Settings.Default.CustomC16 = colourDialog.CustomColors[15];
                Settings.Default.Save();
                return hex;
            }
            else
            {
                return null;
            }
        }
    }
}
