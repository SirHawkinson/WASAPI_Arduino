using System;
using System.Windows.Forms;

namespace WASAPI_Arduino
{
    public partial class Form1 : Form
    {
        /*
         * Math.Pow(10,value/20) converts dB to amplitude value, the 200 in textboxes is used because
         * value is previously multiplied. If a value of a bar/textbox is below 0 multiply the input by -1 
         * to provide negative values, lowering output data.
        */

       // private SampleHandler SampleHandler;
        private int previousHeight=100;
        private double previousValue=100;


        public Form1()
        {
            InitializeComponent();
           // SampleHandler = new SampleHandler();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            double value = (double)trackBar1.Value / 10;

            if (value > 0)
            {
                Properties.Settings.Default.preamp = value;
                Properties.Settings.Default.BarPreamp = (int)value * 10;
                Properties.Settings.Default.textPreamp = value.ToString();
            }
            else if (value == 0)
            {
                Properties.Settings.Default.preamp = 0;
                Properties.Settings.Default.BarPreamp = 0;
                Properties.Settings.Default.textPreamp = value.ToString();
            }
            else
                Properties.Settings.Default.preamp = value;           
            textBox1.Text = Math.Round(value, 1).ToString();
            Properties.Settings.Default.reload =true; 
            Properties.Settings.Default.BarPreamp = (int)value * 10;
            Properties.Settings.Default.textPreamp = value.ToString();
            keyStroke = false;

        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
                if (wtf = textBox1.ContainsFocus)
                {
                    if (textBox1.Text == "--")
                        textBox1.Text = "-";
                    if (textBox1.Text == "-")
                        keyStroke = false;
                    if (keyStroke == true)
                    {                        
                        try
                        {
                            double newValue = double.Parse(textBox1.Text);
                        if (newValue > 300)
                            newValue = 30;
                        if (newValue < -300)
                            newValue = -30;
                        trackBar1.Value = (int)newValue *10;
                        Properties.Settings.Default.BarPreamp = (int)newValue * 10;
                        Properties.Settings.Default.textPreamp = newValue.ToString();
                        previousValue = newValue;
                        }
                        catch (Exception)
                        {
                            textBox1.Text = previousValue.ToString();
                        }
                   
                    Properties.Settings.Default.reload = true;
                        keyStroke = false;
                    }
                }
        }
        
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            double value = (double)trackBar2.Value / 10;
            textBox2.Text = Math.Round(value, 1).ToString();
            if (value > 0)
            {
                Properties.Settings.Default.Hz31 = value;
                Properties.Settings.Default.Bar31 = (int)value * 10;
                Properties.Settings.Default.text31 = value.ToString();
            }
            else if (value == 0)
            {
                Properties.Settings.Default.Hz31 = 0;
                Properties.Settings.Default.Bar31 = 0;
                Properties.Settings.Default.text31 = value.ToString();
            }
            else
                Properties.Settings.Default.Hz31 = value;
            Properties.Settings.Default.Bar31 = (int)value * 10;
            Properties.Settings.Default.text31 = value.ToString();
            Properties.Settings.Default.reload = true;
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            if (wtf = textBox2.ContainsFocus)
            {
                if (textBox2.Text == "--")
                    textBox2.Text = "-";
                if (textBox2.Text == "-")
                    keyStroke = false;
                if (keyStroke == true)
                {
                    
                    try
                    {                        
                        double newValue = double.Parse(textBox2.Text);
                        if (newValue > 300)
                            newValue = 30;
                        if (newValue < -300)
                            newValue = -30;
                        trackBar2.Value = (int)newValue *10;
                        Properties.Settings.Default.Bar31 = (int)newValue * 10;
                        Properties.Settings.Default.text31 = newValue.ToString();
                        previousValue = newValue;
                    }
                    catch (Exception)
                    {
                        textBox2.Text = previousValue.ToString();
                    }

                    Properties.Settings.Default.reload = true;
                    keyStroke = false;
                }
            }
        }
    

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            double value = (double)trackBar3.Value / 10;
            textBox3.Text = Math.Round(value, 1).ToString();
            if (value > 0)
            {
                Properties.Settings.Default.Hz62 = value;
                Properties.Settings.Default.Bar62 = (int)value * 10;
                Properties.Settings.Default.text62 = value.ToString();
            }
            else if (value == 0)
            {
                Properties.Settings.Default.Hz62 = 0;
                Properties.Settings.Default.Bar62 = 0;
                Properties.Settings.Default.text62 = value.ToString();
            }
            else

                Properties.Settings.Default.Hz62 = value;
            Properties.Settings.Default.Bar62 = (int)value * 10;
            Properties.Settings.Default.text62 = value.ToString();
            Properties.Settings.Default.reload = true;
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

            if (wtf = textBox3.ContainsFocus)
            {
                if (textBox3.Text == "--")
                    textBox3.Text = "-";
                if (textBox3.Text == "-")
                    keyStroke = false;
                if (keyStroke == true)
                {
                    
                    try
                    {
                        double newValue = double.Parse(textBox3.Text);
                        if (newValue > 300)
                            newValue = 30;
                        if (newValue < -300)
                            newValue = -30;
                        trackBar3.Value = (int)newValue *10;
                        Properties.Settings.Default.Bar62 = (int)newValue * 10;
                        Properties.Settings.Default.text62 = newValue.ToString();
                        previousValue = newValue;
                    }
                    catch (Exception)
                    {
                        textBox3.Text = previousValue.ToString();
                    }

                    Properties.Settings.Default.reload = true;
                    keyStroke = false;
                }
            }
        }

       
        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            double value = (double)trackBar4.Value / 10;
            textBox4.Text = Math.Round(value, 1).ToString();
            if (value > 0)
            {
                Properties.Settings.Default.Hz125 = value;
                Properties.Settings.Default.Bar125 = (int)value * 10;
                Properties.Settings.Default.text125 = value.ToString();
            }
            else if (value == 0)
            {
                Properties.Settings.Default.Hz125 = 0;
                Properties.Settings.Default.Bar125 = 0;
                Properties.Settings.Default.text125 = value.ToString();
            }
            else
                Properties.Settings.Default.Hz125 = value;
            Properties.Settings.Default.Bar125 = (int)value * 10;
            Properties.Settings.Default.text125 = value.ToString();
            Properties.Settings.Default.reload = true;
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (wtf = textBox4.ContainsFocus)
            {
                if (textBox4.Text == "--")
                    textBox4.Text = "-";
                if (textBox4.Text == "-")
                    keyStroke = false;
                if (keyStroke == true)
                {
                    
                    try
                    {
                        double newValue = double.Parse(textBox4.Text);
                        if (newValue > 300)
                            newValue = 30;
                        if (newValue < -300)
                            newValue = -30;
                        trackBar4.Value = (int)newValue * 10;
                        Properties.Settings.Default.Bar125 = (int)newValue * 10;
                        Properties.Settings.Default.text125 = newValue.ToString();
                        previousValue = newValue;
                    }
                    catch (Exception)
                    {
                        textBox4.Text = previousValue.ToString();
                    }

                    Properties.Settings.Default.reload = true;
                    keyStroke = false;
                }
            }
        }
        
        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            double value = (double)trackBar5.Value / 10;
            textBox5.Text = Math.Round(value, 1).ToString();
            if (value > 0)
            {
                Properties.Settings.Default.Hz250 = value;
                Properties.Settings.Default.Bar250 = (int)value * 10;
                Properties.Settings.Default.text250 = value.ToString();
            }
            else if (value == 0)
            {
                Properties.Settings.Default.Hz250 = 0;
                Properties.Settings.Default.Bar250 = 0;
                Properties.Settings.Default.text250 = value.ToString();
            }
            else
                Properties.Settings.Default.Hz250 = value; 
            Properties.Settings.Default.Bar250 = (int)value * 10;
            Properties.Settings.Default.text250 = value.ToString();
            Properties.Settings.Default.reload = true;
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

            if (wtf = textBox5.ContainsFocus)
            {
                if (textBox5.Text == "--")
                    textBox5.Text = "-";
                if (textBox5.Text == "-")
                    keyStroke = false;
                if (keyStroke == true)
                {                    

                    try
                    {
                        double newValue = double.Parse(textBox5.Text);
                        if (newValue > 300)
                            newValue = 30;
                        if (newValue < -300)
                            newValue = -30;
                        trackBar5.Value = (int)newValue * 10;
                        Properties.Settings.Default.Bar250 = (int)newValue * 10;
                        Properties.Settings.Default.text250 = newValue.ToString();
                        previousValue = newValue;
                    }
                    catch (Exception)
                    {
                        textBox5.Text = previousValue.ToString();
                    }

                    Properties.Settings.Default.reload = true;
                    keyStroke = false;
                }
            }
        }
    

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            double value = (double)trackBar6.Value / 10;
            textBox6.Text = Math.Round(value, 1).ToString();
            if (value > 0)
            {
                Properties.Settings.Default.Hz500 = value;
                Properties.Settings.Default.Bar500 = (int)value * 10;
                Properties.Settings.Default.text500 = value.ToString();
            }
            else if (value == 0)
            {
                Properties.Settings.Default.Hz500 = 0;
                Properties.Settings.Default.Bar500 = 0;
                Properties.Settings.Default.text500 = value.ToString();
            }
            else
                Properties.Settings.Default.Hz500 = value;
            Properties.Settings.Default.Bar500 = (int)value * 10;
            Properties.Settings.Default.text500 = value.ToString();
            Properties.Settings.Default.reload = true;
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {

            if (wtf = textBox6.ContainsFocus)
            {
                if (textBox6.Text == "--")
                    textBox6.Text = "-";
                if (textBox6.Text == "-")
                    keyStroke = false;
                if (keyStroke == true)
                {
                    
                    try
                    {
                        double newValue = double.Parse(textBox6.Text);
                        if (newValue > 300)
                            newValue = 30;
                        if (newValue < -300)
                            newValue = -30;
                        trackBar6.Value = (int)newValue * 10;
                        Properties.Settings.Default.Bar500 = (int)newValue * 10;
                        Properties.Settings.Default.text500 = newValue.ToString();
                        previousValue = newValue;
                    }
                    catch (Exception)
                    {
                        textBox6.Text = previousValue.ToString();
                    }

                    Properties.Settings.Default.reload = true;
                    keyStroke = false;
                }
            }
        }
     
        private void trackBar7_Scroll(object sender, EventArgs e)
        {
            double value = (double)trackBar7.Value / 10;
            textBox7.Text = Math.Round(value, 1).ToString();
            if (value > 0)
            {
                Properties.Settings.Default.Hz1000 = value;
                Properties.Settings.Default.Bar1000 = (int)value * 10;
                Properties.Settings.Default.text1000 = value.ToString();
            }
            else if (value == 0)
            {
                Properties.Settings.Default.Hz1000 = 0;
                Properties.Settings.Default.Bar1000 = 0;
                Properties.Settings.Default.text1000 = value.ToString();
            }
            else
                Properties.Settings.Default.Hz1000 = value;
            Properties.Settings.Default.Bar1000 = (int)value * 10;
            Properties.Settings.Default.text1000 = value.ToString();
            Properties.Settings.Default.reload = true;
        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {

            if (wtf = textBox7.ContainsFocus)
            {
                if (textBox7.Text == "--")
                    textBox7.Text = "-";
                if (textBox7.Text == "-")
                    keyStroke = false;
                if (keyStroke == true)
                {
                    try
                    {
                        double newValue = double.Parse(textBox7.Text);
                        if (newValue > 300)
                            newValue = 30;
                        if (newValue < -300)
                            newValue = -30;
                        trackBar7.Value = (int)newValue * 10;
                        Properties.Settings.Default.Bar1000 = (int)newValue * 10;
                        Properties.Settings.Default.text1000 = newValue.ToString();
                        previousValue = newValue;
                    }
                    catch (Exception)
                    {
                        textBox7.Text = previousValue.ToString();
                    }

                    Properties.Settings.Default.reload = true;
                    keyStroke = false;
                }
            }
        }
      
        private void trackBar8_Scroll(object sender, EventArgs e)
        {
            double value =(double)trackBar8.Value / 10;
            textBox8.Text = Math.Round(value, 1).ToString();
            if (value > 0)
            {
                Properties.Settings.Default.Hz2000 = value;
                Properties.Settings.Default.Bar2000 = (int)value * 10;
                Properties.Settings.Default.text2000 = value.ToString();
            }
            else if (value == 0)
            {
                Properties.Settings.Default.Hz2000 = 0;
                Properties.Settings.Default.Bar2000 = 0;
                Properties.Settings.Default.text2000 = value.ToString();
            }
            else
                Properties.Settings.Default.Hz2000 = value;
            Properties.Settings.Default.Bar2000 = (int)value * 10;
            Properties.Settings.Default.text2000 = value.ToString();
            Properties.Settings.Default.reload = true;
        }
        private void textBox8_TextChanged(object sender, EventArgs e)
        {

            if (wtf = textBox8.ContainsFocus)
            {
                if (textBox8.Text == "--")
                    textBox8.Text = "-";
                if (textBox8.Text == "-")
                    keyStroke = false;
                if (keyStroke == true)
                {
                    try
                    {
                        double newValue = double.Parse(textBox8.Text);
                        if (newValue > 300)
                            newValue = 30;
                        if (newValue < -300)
                            newValue = -30;
                        trackBar8.Value = (int)newValue * 10;
                        Properties.Settings.Default.Bar2000 = (int)newValue * 10;
                        Properties.Settings.Default.text2000 = newValue.ToString();
                        previousValue = newValue;
                    }
                    catch (Exception)
                    {
                        textBox8.Text = previousValue.ToString();
                    }

                    Properties.Settings.Default.reload = true;
                    keyStroke = false;
                }
            }
        }
      
        private void trackBar9_Scroll(object sender, EventArgs e)
        {
            double value = (double)trackBar9.Value / 10;
            textBox9.Text = Math.Round(value, 1).ToString();
            if (value > 0)
            {
                Properties.Settings.Default.Hz4000 = value;
                Properties.Settings.Default.Bar4000 = (int)value * 10;
                Properties.Settings.Default.text4000 = value.ToString();
            }
            else if (value == 0)
            {
                Properties.Settings.Default.Hz4000 = 0;
                Properties.Settings.Default.Bar4000 = 0;
                Properties.Settings.Default.text4000 = value.ToString();
            }
            else
                Properties.Settings.Default.Hz4000 = value;
            Properties.Settings.Default.Bar4000 = (int)value * 10;
            Properties.Settings.Default.text4000 = value.ToString();
            Properties.Settings.Default.reload = true;
        }
         private void textBox9_TextChanged(object sender, EventArgs e)
        {

            if (wtf = textBox9.ContainsFocus)
            {
                if (textBox9.Text == "--")
                    textBox9.Text = "-";
                if (textBox9.Text == "-")
                    keyStroke = false;
                if (keyStroke == true)
                {
                    

                    try
                    {
                        double newValue = double.Parse(textBox9.Text);
                        if (newValue > 300)
                            newValue = 30;
                        if (newValue < -300)
                            newValue = -30;
                        trackBar9.Value = (int)newValue * 10;
                        Properties.Settings.Default.Bar4000 = (int)newValue * 10;
                        Properties.Settings.Default.text4000 = newValue.ToString();
                        previousValue = newValue;
                    }
                    catch (Exception)
                    {
                        textBox9.Text = previousValue.ToString();
                    }

                    Properties.Settings.Default.reload = true;
                    keyStroke = false;
                }
            }
        }

        private void trackBar10_Scroll(object sender, EventArgs e)
        {
            double value = (double)trackBar10.Value / 10;
            textBox10.Text = Math.Round(value, 1).ToString();
            if (value > 0)
            {
                Properties.Settings.Default.Hz8000 = value;
                Properties.Settings.Default.Bar8000 = (int)value * 10;
                Properties.Settings.Default.text8000 = value.ToString();
            }
            else if (value == 0)
            {
                Properties.Settings.Default.Hz8000 = 0;
                Properties.Settings.Default.Bar8000 = 0;
                Properties.Settings.Default.text8000 = value.ToString();
            }
            else
            {
                Properties.Settings.Default.Hz8000 = value;
                Properties.Settings.Default.Bar8000 = (int)value * 10;
                Properties.Settings.Default.text8000 = value.ToString();
            }
            Properties.Settings.Default.reload = true;
        }
        private void textBox10_TextChanged(object sender, EventArgs e)
        {

            if (wtf = textBox10.ContainsFocus)
            {
                if (textBox10.Text == "--")
                    textBox10.Text = "-";
                if (textBox10.Text == "-")
                    keyStroke = false;
                if (keyStroke == true)
                {
                    

                    try
                    {
                        double newValue = double.Parse(textBox10.Text);
                        if (newValue > 300)
                            newValue = 30;
                        if (newValue < -300)
                            newValue = -30;
                        trackBar10.Value = (int)newValue * 10;
                        Properties.Settings.Default.Bar8000 = (int)newValue*10;
                        Properties.Settings.Default.text8000 = newValue.ToString();
                        previousValue = newValue;
                    }
                    catch (Exception)
                    {
                        textBox10.Text = previousValue.ToString();
                    }

                    Properties.Settings.Default.reload = true;
                    keyStroke = false;
                }
            }
        }
     
        private void trackBar11_Scroll(object sender, EventArgs e)
        {
            double value = (double)trackBar11.Value / 10;
            textBox11.Text =value.ToString();
            if (value > 0)
            {
                Properties.Settings.Default.Hz16000 = value;
                Properties.Settings.Default.Bar16000 = (int)value * 10;
                Properties.Settings.Default.text16000 = value.ToString();
            }
            else if (value == 0)
            {
                Properties.Settings.Default.Hz16000 = 0;
                Properties.Settings.Default.Bar16000 = 0;
                Properties.Settings.Default.text16000 = value.ToString();
            }
            else
            {
                Properties.Settings.Default.Hz16000 = value;
                Properties.Settings.Default.Bar16000 = (int)value * 10;
                Properties.Settings.Default.text16000 = value.ToString();
            }
            Properties.Settings.Default.reload = true;

        }
        private void textBox11_TextChanged(object sender, EventArgs e)
        {

            if (wtf = textBox11.ContainsFocus)
            { 
                if (textBox11.Text == "--")
                    textBox11.Text = "-";
                if (textBox11.Text == "-")
                    keyStroke = false;
                if (keyStroke == true)
                {


                    try
                    {
                        double newValue = double.Parse(textBox11.Text);
                        if (newValue > 300)
                            newValue = 30;
                        if (newValue < -300)
                            newValue = -30;
                        trackBar11.Value = (int)newValue*10;
                        Properties.Settings.Default.Bar16000 = (int)newValue*10;
                        Properties.Settings.Default.text16000 = newValue.ToString();
                        previousValue = newValue;
                    }
                    catch (Exception)
                    {
                        textBox11.Text = previousValue.ToString();
                    }

                    Properties.Settings.Default.reload = true;
                    keyStroke = false;
                }
            }
        }
        private void trackBar12_Scroll(object sender, EventArgs e)
        {
           
            double value = trackBar12.Value;
            Properties.Settings.Default.barSmoothing = (int)value;
            double doubleValue = value / 1000;
            textBox12.Text = doubleValue.ToString();
            Properties.Settings.Default.smoothing = doubleValue;
            Properties.Settings.Default.textSmoothing = doubleValue.ToString();
            Properties.Settings.Default.reload = true;
        }
        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            if (textBox12.Text == "--")
                textBox12.Text = "";
            if (wtf = textBox12.ContainsFocus)
            {
                if (keyStroke == true)
                {

                    try
                    {
                        double newValue = double.Parse(textBox12.Text);
                        if (newValue > 0.999)
                            newValue = 0.999;
                        double intValue = newValue * 1000;
                        trackBar12.Value = (int)intValue;
                        previousValue = newValue;
                    }
                    catch (Exception)
                    {
                        textBox12.Text = previousValue.ToString();
                    }

                    Properties.Settings.Default.reload = true;
                    keyStroke = false;

                }
            }
            else
            {
            }
        }
        private void trackBar13_Scroll(object sender, EventArgs e)
        {
            
            int value = trackBar13.Value;
            textBox13.Text = value.ToString();
            if (value >= 100)
                Properties.Settings.Default.height = 100;
            else
                Properties.Settings.Default.height = value;
            Properties.Settings.Default.reload = true;
        }
        private void textBox13_TextChanged(object sender, EventArgs e)
        {

            if (textBox13.Text == "--")
                textBox13.Text = "";
            if (textBox13.Text == ".")
                textBox13.Text = "";
            if (wtf = textBox13.ContainsFocus)
            {
                if (keyStroke == true)
                {

                    try
                    {
                        int newValue = int.Parse(textBox13.Text);
                        if (newValue > 100)
                            newValue = 100;
                        trackBar13.Value = newValue;
                        previousHeight = newValue;
                    }                                                                
                    catch (Exception)
                    {
                        textBox13.Text = previousHeight.ToString();
                    }

                    Properties.Settings.Default.reload = true;
                    keyStroke = false;
                    
                }
            }
            else
            {
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.corrector = !Properties.Settings.Default.corrector;
        }

        
    }

}
