using System;
using System.Windows.Forms;

namespace SoundSampler
{
    public partial class Form1 : Form
    {
        /* Math.Pow(10,value/20) converts dB to amplitude value, the 200 in textboxes is used because
         * value is previously multiplied. If a value of a bar/textbox is below 0 multiply the input by -1 
         * to provide negative values, lowering output data.
        */
        private SampleHandler SampleHandler;
        private SamplerApp SamplerApp;

        // TrackBars range values definitions.
        private int max = 300;
        private int min = -300;

        public Form1()
        {
            InitializeComponent();
            SampleHandler = new SampleHandler();
            SamplerApp = new SamplerApp();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            double value = (double)trackBar1.Value / 10;
           // textBox1.Text = Math.Round(value, 1).ToString();

            if (value>=0)
                Properties.Settings.Default.preamp = (double)Math.Pow(10, value / 20);
            else if (value==0)
                Properties.Settings.Default.preamp = 0;
            else
                Properties.Settings.Default.preamp = (double)Math.Pow(10, (-1) * value / 20)*(-1);

            Properties.Settings.Default.reload =true;
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "--")
                textBox1.Text = "-";

            if (keyStroke == true)
            {
                
                var newValue = double.Parse(textBox1.Text) * 10;
                if (newValue > max)
                {
                    newValue = max / 10;
                    textBox1.Text = newValue.ToString();
                    textBox1.SelectionStart = textBox1.Text.Length;
                    Properties.Settings.Default.BarPreamp = max;
                    Properties.Settings.Default.preamp = (double)Math.Pow(10 , max / 200);
                }
                
                else if (newValue>=0)
                {
                    textBox1.Text = Math.Round(newValue, 1).ToString();
                    Properties.Settings.Default.BarPreamp = (int)newValue;
                    Properties.Settings.Default.preamp = (double)Math.Pow(10, newValue / 200);
                }

                else if (newValue < 0)
                {
                    textBox1.Text = Math.Round(newValue, 1).ToString();
                    Properties.Settings.Default.BarPreamp = (int)newValue;
                    Properties.Settings.Default.preamp = (double)Math.Pow(10, (-1) * newValue / 200)*(-1);
                }

                else if (newValue < min)
                {
                    newValue = min / 10;
                    textBox1.Text = newValue.ToString();
                    textBox1.SelectionStart = textBox1.Text.Length;
                    Properties.Settings.Default.BarPreamp = min;
                    Properties.Settings.Default.preamp = (double)Math.Pow(10 , min / 200);
                }
              //  try
              //  {
                    trackBar1.Value = int.Parse(newValue.ToString());
              //  }
              //  catch (Exception)
              //  {
                    newValue /= 10;
              //      textBox1.Text = Math.Round(newValue,1).ToString();
              //      textBox1.SelectionStart = textBox1.Text.Length; //yeah, doesn't work
             //   }
                Properties.Settings.Default.BarPreamp= (int)newValue;
                Properties.Settings.Default.preamp = (double)Math.Pow(10,newValue/200);
                Properties.Settings.Default.reload = true;
                keyStroke = false;
            }
            else
            { 
            }

        }
       
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            double value = (double)trackBar2.Value / 10;
            textBox2.Text = Math.Round(value, 1).ToString();
            if (value >= 0)
                Properties.Settings.Default.Hz31 = (double)Math.Pow(10, value / 20);
            else if (value == 0)
                Properties.Settings.Default.preamp = 0;
            else
                Properties.Settings.Default.Hz31 = (double)Math.Pow(10, (-1) * value / 20) * (-1);
            Properties.Settings.Default.reload = true;
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            if (textBox2.Text == "--")
                textBox2.Text = "-";
            if (keyStroke == true)
            {

                var newValue = double.Parse(textBox2.Text) * 10;
                if (newValue > max)
                {
                    newValue = max / 10;
                    textBox2.Text = newValue.ToString();
                    textBox2.SelectionStart = textBox2.Text.Length;
                    Properties.Settings.Default.Bar31 = max;
                    Properties.Settings.Default.Hz31 = (double)max/200;
                }
                else if (newValue >= 0)
                {
                    textBox1.Text = newValue.ToString();
                    Properties.Settings.Default.Bar31 = (int)newValue;
                    Properties.Settings.Default.Hz31 = (double)Math.Pow(10, newValue / 200);
                }

                else if (newValue < 0)
                {
                    textBox1.Text = newValue.ToString();
                    Properties.Settings.Default.Bar31 = (int)newValue;
                    Properties.Settings.Default.Hz31 = (double)Math.Pow(10, (-1) * newValue / 200) * (-1);
                }

                else if (newValue < min)
                {
                    newValue = min / 10;
                    textBox2.Text = newValue.ToString();
                    textBox2.SelectionStart = textBox2.Text.Length;
                    Properties.Settings.Default.Bar31 = min;
                    Properties.Settings.Default.Hz31 = (double)Math.Pow(10,min/200);
                }
                try
                {
                    trackBar2.Value = int.Parse(newValue.ToString());
                }
                catch (Exception)
                {
                    newValue /= 10;
                    textBox2.Text = Math.Round(newValue, 1).ToString();
                    textBox2.SelectionStart = textBox2.Text.Length;
                }
                keyStroke = false;
                Properties.Settings.Default.reload = true;
            }
            else
            {
            }
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            double value = (double)trackBar3.Value / 10;
            textBox3.Text = Math.Round(value, 1).ToString();
            if (value >= 0)
                Properties.Settings.Default.Hz62 = (double)Math.Pow(10, value / 20);
            else if (value == 0)
                Properties.Settings.Default.preamp = 0;
            else
                Properties.Settings.Default.Hz62 = (double)Math.Pow(10, (-1) * value / 20) * (-1);
            Properties.Settings.Default.reload = true;
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

            if(textBox3.Text == "--")
                textBox3.Text = "-";
            if (keyStroke == true)
            {

                
                var newValue = double.Parse(textBox3.Text) * 10;
                if (newValue > max)
                {
                    newValue = max / 10;
                    textBox3.Text = newValue.ToString();
                    Properties.Settings.Default.Bar62 = max;
                    Properties.Settings.Default.Hz62 = (double)max/200;
                }
                else if (newValue >= 0)
                {
                    textBox1.Text = newValue.ToString();
                    Properties.Settings.Default.Bar62 = (int)newValue;
                    Properties.Settings.Default.Hz62 = (double)Math.Pow(10, newValue / 200);
                }

                else if (newValue < 0)
                {
                    textBox1.Text = newValue.ToString();
                    Properties.Settings.Default.Bar62 = (int)newValue;
                    Properties.Settings.Default.Hz62 = (double)Math.Pow(10, (-1) * newValue / 200) * (-1);
                }

                else if (newValue < min)
                {
                    newValue = min / 10;
                    textBox3.Text = newValue.ToString();
                    Properties.Settings.Default.Bar62 = min;
                    Properties.Settings.Default.Hz62 = (double)min / 10;
                }
                try
                {
                    trackBar3.Value = int.Parse(newValue.ToString());
                }
                catch (Exception)
                {
                    newValue /= 10;
                    textBox3.Text = Math.Round(newValue, 1).ToString();
                    textBox3.SelectionStart = textBox3.Text.Length;
                }
                Properties.Settings.Default.Bar62 = (int)newValue;
                Properties.Settings.Default.Hz62 = (double)Math.Pow(10,newValue/200);
                Properties.Settings.Default.reload = true;
            }
            else
            {
            }
        }

       
        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            double value = (double)trackBar4.Value / 10;
            textBox4.Text = Math.Round(value, 1).ToString();
            if (value >= 0)
                Properties.Settings.Default.Hz125 = (double)Math.Pow(10, value / 20);
            else if (value == 0)
                Properties.Settings.Default.preamp = 0;
            else
                Properties.Settings.Default.Hz125 = (double)Math.Pow(10, (-1) * value / 20) * (-1);
            Properties.Settings.Default.reload = true;
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if(textBox4.Text == "--")
                textBox4.Text = "-";
            if (keyStroke == true)
            {

                
                var newValue = double.Parse(textBox4.Text) * 10;
                if (newValue > max)
                {
                    newValue = max / 10;
                    textBox4.Text = newValue.ToString();
                    Properties.Settings.Default.Bar125 = max;
                    Properties.Settings.Default.Hz125 = (double)max/200;
                }
                else if (newValue >= 0)
                {
                    textBox1.Text = newValue.ToString();
                    Properties.Settings.Default.Bar125 = (int)newValue;
                    Properties.Settings.Default.Hz125 = (double)Math.Pow(10, newValue / 200);
                }

                else if (newValue < 0)
                {
                    textBox1.Text = newValue.ToString();
                    Properties.Settings.Default.Bar125 = (int)newValue;
                    Properties.Settings.Default.Hz125 = (double)Math.Pow(10, (-1) * newValue / 200) * (-1);
                }

                else if (newValue < min)
                {
                    newValue = min / 10;
                    textBox4.Text = newValue.ToString();
                    Properties.Settings.Default.Bar125 = min;
                    Properties.Settings.Default.Hz125 = (double)min / 10;
                }
                try
                {
                    trackBar4.Value = int.Parse(newValue.ToString());
                }
                catch (Exception)
                {
                    newValue /= 10;
                    textBox4.Text = Math.Round(newValue, 1).ToString();
                    textBox4.SelectionStart = textBox4.Text.Length;
                }
                Properties.Settings.Default.Bar125 = (int)newValue;
                Properties.Settings.Default.Hz125 = (double)Math.Pow(10,newValue/200);
                keyStroke = false;
                Properties.Settings.Default.reload = true;
            }
            else
            {
            }
        }
        
        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            double value = (double)trackBar5.Value / 10;
            textBox5.Text = Math.Round(value, 1).ToString();
            if (value >= 0)
                Properties.Settings.Default.Hz250 = (double)Math.Pow(10, value / 20);
            else if (value == 0)
                Properties.Settings.Default.preamp = 0;
            else
                Properties.Settings.Default.Hz250 = (double)Math.Pow(10, (-1) * value / 20) * (-1);
            Properties.Settings.Default.reload = true;
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

            if (textBox5.Text == "--")
                textBox5.Text = "-";
            if (keyStroke == true)
            {

                
                var newValue = double.Parse(textBox5.Text) * 10;
                if (newValue > max)
                {
                    newValue = max / 10;
                    textBox5.Text = newValue.ToString();
                    Properties.Settings.Default.Bar250 = max;
                    Properties.Settings.Default.Hz250 = (double)max/200;
                }
                else if (newValue >= 0)
                {
                    textBox1.Text = newValue.ToString();
                    Properties.Settings.Default.Bar250 = (int)newValue;
                    Properties.Settings.Default.Hz250 = (double)Math.Pow(10, newValue / 200);
                }

                else if (newValue < 0)
                {
                    textBox1.Text = newValue.ToString();
                    Properties.Settings.Default.Bar250 = (int)newValue;
                    Properties.Settings.Default.Hz250 = (double)Math.Pow(10, (-1) * newValue / 200) * (-1);
                }

                else if (newValue < min)
                {
                    newValue = min / 10;
                    textBox5.Text = newValue.ToString();
                    Properties.Settings.Default.Bar250 = min;
                    Properties.Settings.Default.Hz250 = (double)min / 10;
                }
                try
                {
                    trackBar5.Value = int.Parse(newValue.ToString());
                }
                catch (Exception)
                {
                    newValue /= 10;
                    textBox5.Text = Math.Round(newValue, 1).ToString();
                    textBox5.SelectionStart = textBox5.Text.Length;
                }
                Properties.Settings.Default.Bar250 = (int)newValue;
                Properties.Settings.Default.Hz250 = (double)Math.Pow(10,newValue/200);
                keyStroke = false;
                Properties.Settings.Default.reload = true;
            }
            else
            {
            }
        }
    

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            double value = (double)trackBar6.Value / 10;
            textBox6.Text = Math.Round(value, 1).ToString();
            if (value >= 0)
                Properties.Settings.Default.Hz500 = (double)Math.Pow(10, value / 20);
            else if (value == 0)
                Properties.Settings.Default.preamp = 0;
            else
                Properties.Settings.Default.Hz500 = (double)Math.Pow(10, (-1) * value / 20) * (-1);
            Properties.Settings.Default.reload = true;
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {

            if (textBox6.Text == "--")
                textBox6.Text = "-";
            if (keyStroke == true)
            {

                
                var newValue = double.Parse(textBox6.Text) * 10;
                if (newValue > max)
                {
                    newValue = max / 10;
                    textBox6.Text = newValue.ToString();
                    Properties.Settings.Default.Bar500= max;
                    Properties.Settings.Default.Hz500 = (double)max/200;
                }
                else if (newValue >= 0)
                {
                    textBox1.Text = newValue.ToString();
                    Properties.Settings.Default.Bar500 = (int)newValue;
                    Properties.Settings.Default.Hz500 = (double)Math.Pow(10, newValue / 200);
                }

                else if (newValue < 0)
                {
                    textBox1.Text = newValue.ToString();
                    Properties.Settings.Default.Bar500 = (int)newValue;
                    Properties.Settings.Default.Hz500 = (double)Math.Pow(10, (-1) * newValue / 200) * (-1);
                }

                else if (newValue < min)
                {
                    newValue = min / 10;
                    textBox6.Text = newValue.ToString();
                    Properties.Settings.Default.Bar500 = min;
                    Properties.Settings.Default.Hz500 = (double)min / 10;
                }
                try
                {
                    trackBar6.Value = int.Parse(newValue.ToString());
                }
                catch (Exception)
                {
                    newValue /= 10;
                    textBox6.Text = Math.Round(newValue, 1).ToString();
                    textBox6.SelectionStart = textBox6.Text.Length;
                }
                Properties.Settings.Default.Bar500 = (int)newValue;
                Properties.Settings.Default.Hz500 = (double)Math.Pow(10,newValue/200);
                keyStroke = false;
                Properties.Settings.Default.reload = true;
            }
            else
            {
            }
        }
     
        private void trackBar7_Scroll(object sender, EventArgs e)
        {
            double value = (double)trackBar7.Value / 10;
            textBox7.Text = Math.Round(value, 1).ToString();
            if (value >= 0)
                Properties.Settings.Default.Hz1000 = (double)Math.Pow(10, value / 20);
            else if (value == 0)
                Properties.Settings.Default.preamp = 0;
            else
                Properties.Settings.Default.Hz1000 = (double)Math.Pow(10, (-1) * value / 20) * (-1);
            Properties.Settings.Default.reload = true;
        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {

            if (textBox7.Text == "--")
                textBox7.Text = "-";
            if (keyStroke == true)
            {

                
                var newValue = double.Parse(textBox7.Text) * 10;
                if (newValue > max)
                {
                    newValue = max / 10;
                    textBox7.Text = newValue.ToString();
                    Properties.Settings.Default.Bar1000 = max;
                    Properties.Settings.Default.Hz1000 = max/200;
                }
                else if (newValue >= 0)
                {
                    textBox1.Text = newValue.ToString();
                    Properties.Settings.Default.Bar1000 = (int)newValue;
                    Properties.Settings.Default.Hz1000 = (double)Math.Pow(10, newValue / 200);
                }

                else if (newValue < 0)
                {
                    textBox1.Text = newValue.ToString();
                    Properties.Settings.Default.Bar1000 = (int)newValue;
                    Properties.Settings.Default.Hz1000 = (double)Math.Pow(10, (-1) * newValue / 200) * (-1);
                }
                else if (newValue < min)
                {
                    newValue = min / 10;
                    textBox7.Text = newValue.ToString();
                    Properties.Settings.Default.Bar1000 = min;
                    Properties.Settings.Default.Hz1000 = (double)min / 10;
                
                }

                try
                {
                    trackBar7.Value = int.Parse(newValue.ToString());
                }
                catch (Exception)
                {
                    newValue /= 10;
                    textBox7.Text = Math.Round(newValue, 1).ToString();
                    textBox7.SelectionStart = textBox7.Text.Length;
                }
                Properties.Settings.Default.Bar1000 = (int)newValue;
                Properties.Settings.Default.Hz1000 = (double)Math.Pow(10,newValue/200);
                keyStroke = false;
                Properties.Settings.Default.reload = true;
            }
            else
            {
            }
        }
      
        private void trackBar8_Scroll(object sender, EventArgs e)
        {
            double value =(double)trackBar8.Value / 10;
            textBox8.Text = Math.Round(value, 1).ToString();
            if (value >= 0)
                Properties.Settings.Default.Hz2000 = (double)Math.Pow(10, value / 20);
            else if (value == 0)
                Properties.Settings.Default.preamp = 0;
            else
                Properties.Settings.Default.Hz2000 = (double)Math.Pow(10, (-1) * value / 20) * (-1);
            Properties.Settings.Default.reload = true;
        }
        private void textBox8_TextChanged(object sender, EventArgs e)
        {

            if (textBox8.Text == "--")
                textBox8.Text = "-";
            if (keyStroke == true)
            {

                
                var newValue = double.Parse(textBox8.Text) * 10;
                if (newValue > max)
                {
                    newValue = max / 10;
                    textBox8.Text = newValue.ToString();
                    Properties.Settings.Default.Bar2000 = max;
                    Properties.Settings.Default.Hz2000 = (double)max/200;
                }
                else if (newValue < min)
                {
                    newValue = min / 10;
                    textBox8.Text = newValue.ToString();
                    Properties.Settings.Default.Bar2000 = min;
                    Properties.Settings.Default.Hz2000 = (double)min / 10;
                }
                else if (newValue >= 0)
                {
                    textBox1.Text = newValue.ToString();
                    Properties.Settings.Default.Bar2000 = (int)newValue;
                    Properties.Settings.Default.Hz2000 = (double)Math.Pow(10, newValue / 200);
                }

                else if (newValue < 0)
                {
                    textBox1.Text = newValue.ToString();
                    Properties.Settings.Default.Bar2000 = (int)newValue;
                    Properties.Settings.Default.Hz2000 = (double)Math.Pow(10, (-1) * newValue / 200) * (-1);
                }

                try
                {
                    trackBar8.Value = int.Parse(newValue.ToString());
                }
                catch (Exception)
                {
                    newValue /= 10;
                    textBox8.Text = Math.Round(newValue, 1).ToString();
                    textBox8.SelectionStart = textBox8.Text.Length;
                }
                Properties.Settings.Default.Bar2000 = (int)newValue;
                Properties.Settings.Default.Hz2000 = (double)Math.Pow(10,newValue/200);
                keyStroke = false;
                Properties.Settings.Default.reload = true;
            }
            else
            {
            }
        }
      
        private void trackBar9_Scroll(object sender, EventArgs e)
        {
            double value = (double)trackBar9.Value / 10;
            textBox9.Text = Math.Round(value, 1).ToString();
            if (value >= 0)
                Properties.Settings.Default.Hz4000 = (double)Math.Pow(10, value / 20);
            else if (value == 0)
                Properties.Settings.Default.preamp = 0;
            else
                Properties.Settings.Default.Hz4000 = (double)Math.Pow(10, (-1) * value / 20) * (-1);
            Properties.Settings.Default.reload = true;
        }
         private void textBox9_TextChanged(object sender, EventArgs e)
        {

            if (textBox9.Text == "--")
                textBox9.Text = "-";
            if (keyStroke == true)
            {

                
                var newValue = double.Parse(textBox9.Text) * 10;
                if (newValue > max)
                {
                    newValue = max / 10;
                    textBox9.Text = newValue.ToString();
                    Properties.Settings.Default.Bar4000 = max;
                    Properties.Settings.Default.Hz4000 = (double)max/200;
                }
                else if (newValue >= 0)
                {
                    textBox1.Text = newValue.ToString();
                    Properties.Settings.Default.Bar4000 = (int)newValue;
                    Properties.Settings.Default.Hz4000 = (double)Math.Pow(10, newValue / 200);
                }

                else if (newValue < 0)
                {
                    textBox1.Text = newValue.ToString();
                    Properties.Settings.Default.Bar4000 = (int)newValue;
                    Properties.Settings.Default.Hz4000 = (double)Math.Pow(10, (-1) * newValue / 200) * (-1);
                }

                else if (newValue < min)
                {
                    newValue = min / 10;
                    textBox9.Text = newValue.ToString();
                    Properties.Settings.Default.Bar4000 = min;
                    Properties.Settings.Default.Hz4000 = (double)min / 10;
                }
                try
                {
                    trackBar9.Value = int.Parse(newValue.ToString());
                }
                catch (Exception)
                {
                    newValue /= 10;
                    textBox9.Text = Math.Round(newValue, 1).ToString();
                    textBox9.SelectionStart = textBox9.Text.Length;
                }

                Properties.Settings.Default.Bar4000 = (int)newValue;
                Properties.Settings.Default.Hz4000 = (double)Math.Pow(10,newValue/200);
                keyStroke = false;
                Properties.Settings.Default.reload = true;
            }
            else
            {
            }
        }

        private void trackBar10_Scroll(object sender, EventArgs e)
        {
            double value = (double)trackBar10.Value / 10;
            textBox10.Text = Math.Round(value, 1).ToString();
            if (value >= 0)
                Properties.Settings.Default.Hz8000 = (double)Math.Pow(10, value / 20);
            else if (value == 0)
                Properties.Settings.Default.preamp = 0;
            else
                Properties.Settings.Default.Hz8000 = (double)Math.Pow(10, (-1) * value / 20) * (-1);
            Properties.Settings.Default.reload = true;
        }
        private void textBox10_TextChanged(object sender, EventArgs e)
        {

            if (textBox10.Text == "--")
                textBox10.Text = "-";
            if (keyStroke == true)
            {

                
                var newValue = double.Parse(textBox10.Text) * 10;
                if (newValue > max)
                {
                    newValue = max / 10;
                    textBox10.Text = newValue.ToString();
                    Properties.Settings.Default.Bar8000 = max;
                    Properties.Settings.Default.Hz8000 = (double)max / 10;
                }
                else if (newValue >= 0)
                {
                    textBox1.Text = newValue.ToString();
                    Properties.Settings.Default.Bar8000 = (int)newValue;
                    Properties.Settings.Default.Hz8000 = (double)Math.Pow(10, newValue / 200);
                }

                else if (newValue < 0)
                {
                    textBox1.Text = newValue.ToString();
                    Properties.Settings.Default.Bar8000 = (int)newValue;
                    Properties.Settings.Default.Hz8000 = (double)Math.Pow(10, (-1) * newValue / 200) * (-1);
                }

                else if (newValue < min)
                {
                    newValue = min / 10;
                    textBox10.Text = newValue.ToString();
                    Properties.Settings.Default.Bar8000 = min;
                    Properties.Settings.Default.Hz8000 = (double)min / 10;
                }
                try
                {
                    trackBar10.Value = int.Parse(newValue.ToString());
                }
                catch(Exception)
                {
                    newValue /= 10;
                    textBox10.Text = Math.Round(newValue, 1).ToString();
                    textBox10.SelectionStart = textBox10.Text.Length;
                }

                Properties.Settings.Default.Bar8000 = (int)newValue;
                Properties.Settings.Default.Hz8000 = (double)Math.Pow(10,newValue/200);
                keyStroke = false;
                Properties.Settings.Default.reload = true;
            }
            else
            {
            }
        }
     
        private void trackBar11_Scroll(object sender, EventArgs e)
        {
            double value = (double)trackBar11.Value / 10;
            textBox11.Text = Math.Round(value,1).ToString();
            if (value>=0)
                Properties.Settings.Default.Hz16000 = (double)Math.Pow(10,value/20);
            else if (value == 0)
                Properties.Settings.Default.preamp = 0;
            else
                Properties.Settings.Default.Hz16000 = (double)Math.Pow(10, (-1) * value / 20)*(-1);
            Properties.Settings.Default.reload = true;

        }
        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if (textBox11.Text == "--")
                textBox11.Text = "-";
            if (keyStroke == true)
            {

                
                var newValue = double.Parse(textBox11.Text) * 10;
                if (newValue > max)
                {
                    newValue = max/200;
                    textBox11.Text = newValue.ToString(); 
                    Properties.Settings.Default.Bar16000 = max;
                    Properties.Settings.Default.Hz16000 = (double)max/200;

                }
                else if (newValue >= 0)
                {
                    textBox1.Text = newValue.ToString();
                    Properties.Settings.Default.Bar16000 = (int)newValue;
                    Properties.Settings.Default.Hz16000 = (double)Math.Pow(10, newValue / 200);
                }

                else if (newValue < 0)
                {
                    textBox1.Text = newValue.ToString();
                    Properties.Settings.Default.Bar16000 = (int)newValue;
                    Properties.Settings.Default.Hz16000 = (double)Math.Pow(10, (-1)*newValue / 200) * (-1);
                }

                else if (newValue < min)
                {
                    newValue = min/200;
                    textBox11.Text = newValue.ToString();
                    Properties.Settings.Default.Bar16000 = min;
                    Properties.Settings.Default.Hz16000 = (double)Math.Pow(10,min/200);
                }
                try
                {
                    trackBar11.Value = int.Parse(newValue.ToString());
                }
                catch (Exception)
                {
                    textBox11.SelectionStart = textBox11.Text.Length;
                    textBox11.Text = Math.Round(newValue, 1).ToString();
                }

                Properties.Settings.Default.Bar16000 = (int)newValue;
                Properties.Settings.Default.Hz16000 = (double)Math.Pow(10,newValue/200);
                keyStroke = false;
                Properties.Settings.Default.reload = true;
            }
            else
            {
            }
        }
        private void trackBar12_Scroll(object sender, EventArgs e)
        {
            double value = (double)trackBar12.Value / 1000;
            textBox12.Text = Math.Round(value, 3).ToString();
            Properties.Settings.Default.smoothing = value;
            Properties.Settings.Default.barSmoothing = (int)value*1000;
            SamplerApp.smoothing = value;
            Properties.Settings.Default.reload = true;
        }
        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine(keyStroke);
            if (textBox12.Text == "--")
                textBox12.Text = "";
            if (keyStroke == true)
            {
                var newValue = double.Parse(textBox12.Text) * 1000;
                if (newValue > 0.999)
                {
                    newValue = 0.999;
                    textBox12.Text = newValue.ToString();
                    Properties.Settings.Default.barSmoothing = (int)newValue*1000;
                    Properties.Settings.Default.smoothing = 0.999f;
                }
                else
                {
                    try
                    {
                        trackBar12.Value = int.Parse(newValue.ToString());
                    }
                    catch (Exception)
                    {
                        textBox12.SelectionStart = textBox12.Text.Length;
                        textBox12.Text = Math.Round(newValue, 1).ToString();
                    }
                }

                Properties.Settings.Default.barSmoothing = (int)newValue;
                Properties.Settings.Default.smoothing= (double)newValue/1000;
                SamplerApp.smoothing = (double)newValue/1000;
                keyStroke = false;
                Properties.Settings.Default.reload = true;
            }
            else
            {
            }
        }
        private void trackBar13_Scroll(object sender, EventArgs e)
        {

            int value = trackBar13.Value;
            textBox13.Text = value.ToString();
            Properties.Settings.Default.height = value;
            Properties.Settings.Default.reload = true;
        }
        private void textBox13_TextChanged(object sender, EventArgs e)
        {

            if (textBox13.Text == "--")
                textBox13.Text = "";
            if (keyStroke == true)
            {
                var newValue = int.Parse(textBox13.Text);
                if (newValue > 100)
                {
                    newValue = 100;
                    textBox13.Text = newValue.ToString();
                    Properties.Settings.Default.height = newValue;
                }
                else
                {
                    try
                    {
                        trackBar13.Value = int.Parse(newValue.ToString());
                        Console.WriteLine(newValue);
                    }
                    catch (Exception)
                    {
                        textBox13.SelectionStart = textBox13.Text.Length;
                        textBox13.Text = newValue.ToString();
                    }
                }
                Properties.Settings.Default.height = newValue;
                keyStroke = false;
                Properties.Settings.Default.reload = true;
            }
            else
            {
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.corrector = !Properties.Settings.Default.corrector;
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        
    }

}
