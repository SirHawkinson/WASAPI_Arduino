using System.Windows.Forms;
using WASAPI_Arduino.Properties;

namespace WASAPI_Arduino
{
    partial class Form1
    {
        public bool keyStroke = true;
        public bool wtf = false;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.trackBar4 = new System.Windows.Forms.TrackBar();
            this.trackBar5 = new System.Windows.Forms.TrackBar();
            this.trackBar6 = new System.Windows.Forms.TrackBar();
            this.trackBar7 = new System.Windows.Forms.TrackBar();
            this.trackBar8 = new System.Windows.Forms.TrackBar();
            this.trackBar9 = new System.Windows.Forms.TrackBar();
            this.trackBar10 = new System.Windows.Forms.TrackBar();
            this.trackBar11 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.trackBar12 = new System.Windows.Forms.TrackBar();
            this.trackBar13 = new System.Windows.Forms.TrackBar();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar13)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(14, 42);
            this.trackBar1.Maximum = 300;
            this.trackBar1.Minimum = -300;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(45, 164);
            this.trackBar1.TabIndex = 12;
            this.trackBar1.Value = global::WASAPI_Arduino.Properties.Settings.Default.BarPreamp;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(116, 42);
            this.trackBar2.Maximum = 300;
            this.trackBar2.Minimum = -300;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar2.Size = new System.Drawing.Size(45, 164);
            this.trackBar2.TabIndex = 13;
            this.trackBar2.Value = global::WASAPI_Arduino.Properties.Settings.Default.Bar31;
            this.trackBar2.ValueChanged += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // trackBar3
            // 
            this.trackBar3.Location = new System.Drawing.Point(167, 42);
            this.trackBar3.Maximum = 300;
            this.trackBar3.Minimum = -300;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar3.Size = new System.Drawing.Size(45, 164);
            this.trackBar3.TabIndex = 14;
            this.trackBar3.Value = global::WASAPI_Arduino.Properties.Settings.Default.Bar62;
            this.trackBar3.ValueChanged += new System.EventHandler(this.trackBar3_Scroll);
            // 
            // trackBar4
            // 
            this.trackBar4.Location = new System.Drawing.Point(218, 42);
            this.trackBar4.Maximum = 300;
            this.trackBar4.Minimum = -300;
            this.trackBar4.Name = "trackBar4";
            this.trackBar4.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar4.Size = new System.Drawing.Size(45, 164);
            this.trackBar4.TabIndex = 15;
            this.trackBar4.Value = global::WASAPI_Arduino.Properties.Settings.Default.Bar125;
            this.trackBar4.ValueChanged += new System.EventHandler(this.trackBar4_Scroll);
            // 
            // trackBar5
            // 
            this.trackBar5.Location = new System.Drawing.Point(269, 42);
            this.trackBar5.Maximum = 300;
            this.trackBar5.Minimum = -300;
            this.trackBar5.Name = "trackBar5";
            this.trackBar5.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar5.Size = new System.Drawing.Size(45, 164);
            this.trackBar5.TabIndex = 16;
            this.trackBar5.Value = global::WASAPI_Arduino.Properties.Settings.Default.Bar250;
            this.trackBar5.ValueChanged += new System.EventHandler(this.trackBar5_Scroll);
            // 
            // trackBar6
            // 
            this.trackBar6.Location = new System.Drawing.Point(320, 42);
            this.trackBar6.Maximum = 300;
            this.trackBar6.Minimum = -300;
            this.trackBar6.Name = "trackBar6";
            this.trackBar6.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar6.Size = new System.Drawing.Size(45, 164);
            this.trackBar6.TabIndex = 17;
            this.trackBar6.Value = global::WASAPI_Arduino.Properties.Settings.Default.Bar500;
            this.trackBar6.ValueChanged += new System.EventHandler(this.trackBar6_Scroll);
            // 
            // trackBar7
            // 
            this.trackBar7.Location = new System.Drawing.Point(368, 42);
            this.trackBar7.Maximum = 300;
            this.trackBar7.Minimum = -300;
            this.trackBar7.Name = "trackBar7";
            this.trackBar7.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar7.Size = new System.Drawing.Size(45, 164);
            this.trackBar7.TabIndex = 18;
            this.trackBar7.Value = global::WASAPI_Arduino.Properties.Settings.Default.Bar1000;
            this.trackBar7.ValueChanged += new System.EventHandler(this.trackBar7_Scroll);
            // 
            // trackBar8
            // 
            this.trackBar8.Location = new System.Drawing.Point(422, 42);
            this.trackBar8.Maximum = 300;
            this.trackBar8.Minimum = -300;
            this.trackBar8.Name = "trackBar8";
            this.trackBar8.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar8.Size = new System.Drawing.Size(45, 164);
            this.trackBar8.TabIndex = 19;
            this.trackBar8.Value = global::WASAPI_Arduino.Properties.Settings.Default.Bar2000;
            this.trackBar8.ValueChanged += new System.EventHandler(this.trackBar8_Scroll);
            // 
            // trackBar9
            // 
            this.trackBar9.Location = new System.Drawing.Point(473, 42);
            this.trackBar9.Maximum = 300;
            this.trackBar9.Minimum = -300;
            this.trackBar9.Name = "trackBar9";
            this.trackBar9.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar9.Size = new System.Drawing.Size(45, 164);
            this.trackBar9.TabIndex = 20;
            this.trackBar9.Value = global::WASAPI_Arduino.Properties.Settings.Default.Bar4000;
            this.trackBar9.ValueChanged += new System.EventHandler(this.trackBar9_Scroll);
            // 
            // trackBar10
            // 
            this.trackBar10.Location = new System.Drawing.Point(524, 42);
            this.trackBar10.Maximum = 300;
            this.trackBar10.Minimum = -300;
            this.trackBar10.Name = "trackBar10";
            this.trackBar10.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar10.Size = new System.Drawing.Size(45, 164);
            this.trackBar10.TabIndex = 21;
            this.trackBar10.Value = global::WASAPI_Arduino.Properties.Settings.Default.Bar8000;
            this.trackBar10.ValueChanged += new System.EventHandler(this.trackBar10_Scroll);
            // 
            // trackBar11
            // 
            this.trackBar11.Location = new System.Drawing.Point(575, 42);
            this.trackBar11.Maximum = 300;
            this.trackBar11.Minimum = -300;
            this.trackBar11.Name = "trackBar11";
            this.trackBar11.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar11.Size = new System.Drawing.Size(45, 164);
            this.trackBar11.TabIndex = 22;
            this.trackBar11.Value = global::WASAPI_Arduino.Properties.Settings.Default.Bar16000;
            this.trackBar11.ValueChanged += new System.EventHandler(this.trackBar11_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(116, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "31 Hz";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 213);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "62 Hz";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(263, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "250 Hz";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(215, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "125 Hz";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(464, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "4000 Hz";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(416, 213);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "2000 Hz";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(365, 213);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "1000 Hz";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(317, 213);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "500 Hz";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(569, 213);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "16000 Hz";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(521, 213);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 32;
            this.label10.Text = "8000 Hz";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 213);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 13);
            this.label11.TabIndex = 33;
            this.label11.Text = "Preamp";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(14, 16);
            this.textBox1.MaxLength = 5;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(40, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = global::WASAPI_Arduino.Properties.Settings.Default.textPreamp;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Login_KeyPress);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(116, 16);
            this.textBox2.MaxLength = 5;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(40, 20);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = global::WASAPI_Arduino.Properties.Settings.Default.text31;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Login_KeyPress);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(167, 16);
            this.textBox3.MaxLength = 5;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(40, 20);
            this.textBox3.TabIndex = 2;
            this.textBox3.Text = global::WASAPI_Arduino.Properties.Settings.Default.text62;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            this.textBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Login_KeyPress);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(218, 16);
            this.textBox4.MaxLength = 5;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(40, 20);
            this.textBox4.TabIndex = 3;
            this.textBox4.Text = global::WASAPI_Arduino.Properties.Settings.Default.text125;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            this.textBox4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Login_KeyPress);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(269, 16);
            this.textBox5.MaxLength = 5;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(40, 20);
            this.textBox5.TabIndex = 4;
            this.textBox5.Text = global::WASAPI_Arduino.Properties.Settings.Default.text250;
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            this.textBox5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Login_KeyPress);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(320, 16);
            this.textBox6.MaxLength = 5;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(40, 20);
            this.textBox6.TabIndex = 5;
            this.textBox6.Text = global::WASAPI_Arduino.Properties.Settings.Default.text500;
            this.textBox6.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            this.textBox6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Login_KeyPress);
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(368, 16);
            this.textBox7.MaxLength = 5;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(40, 20);
            this.textBox7.TabIndex = 6;
            this.textBox7.Text = global::WASAPI_Arduino.Properties.Settings.Default.text1000;
            this.textBox7.TextChanged += new System.EventHandler(this.textBox7_TextChanged);
            this.textBox7.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Login_KeyPress);
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(422, 16);
            this.textBox8.MaxLength = 5;
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(40, 20);
            this.textBox8.TabIndex = 7;
            this.textBox8.Text = global::WASAPI_Arduino.Properties.Settings.Default.text2000;
            this.textBox8.TextChanged += new System.EventHandler(this.textBox8_TextChanged);
            this.textBox8.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Login_KeyPress);
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(473, 16);
            this.textBox9.MaxLength = 5;
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(40, 20);
            this.textBox9.TabIndex = 8;
            this.textBox9.Text = global::WASAPI_Arduino.Properties.Settings.Default.text4000;
            this.textBox9.TextChanged += new System.EventHandler(this.textBox9_TextChanged);
            this.textBox9.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Login_KeyPress);
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(524, 16);
            this.textBox10.MaxLength = 5;
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(40, 20);
            this.textBox10.TabIndex = 9;
            this.textBox10.Text = global::WASAPI_Arduino.Properties.Settings.Default.text8000;
            this.textBox10.TextChanged += new System.EventHandler(this.textBox10_TextChanged);
            this.textBox10.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Login_KeyPress);
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(575, 16);
            this.textBox11.MaxLength = 5;
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(40, 20);
            this.textBox11.TabIndex = 10;
            this.textBox11.Text = global::WASAPI_Arduino.Properties.Settings.Default.text16000;
            this.textBox11.TextChanged += new System.EventHandler(this.textBox11_TextChanged);
            this.textBox11.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Login_KeyPress);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = global::WASAPI_Arduino.Properties.Settings.Default.corrector;
            this.checkBox1.Location = new System.Drawing.Point(516, 261);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(104, 17);
            this.checkBox1.TabIndex = 34;
            this.checkBox1.Text = "Enable corrector";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // trackBar12
            // 
            this.trackBar12.Location = new System.Drawing.Point(65, 261);
            this.trackBar12.Maximum = 999;
            this.trackBar12.Name = "trackBar12";
            this.trackBar12.Size = new System.Drawing.Size(343, 45);
            this.trackBar12.TabIndex = 35;
            this.trackBar12.Value = global::WASAPI_Arduino.Properties.Settings.Default.barSmoothing;
            this.trackBar12.ValueChanged += new System.EventHandler(this.trackBar12_Scroll);
            // 
            // trackBar13
            // 
            this.trackBar13.Location = new System.Drawing.Point(65, 312);
            this.trackBar13.Maximum = 100;
            this.trackBar13.Name = "trackBar13";
            this.trackBar13.Size = new System.Drawing.Size(343, 45);
            this.trackBar13.TabIndex = 36;
            this.trackBar13.Value = global::WASAPI_Arduino.Properties.Settings.Default.height;
            this.trackBar13.ValueChanged += new System.EventHandler(this.trackBar13_Scroll);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 265);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 13);
            this.label12.TabIndex = 37;
            this.label12.Text = "Smoothing";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 321);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 13);
            this.label13.TabIndex = 38;
            this.label13.Text = "Height";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(422, 262);
            this.textBox12.MaxLength = 5;
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(40, 20);
            this.textBox12.TabIndex = 39;
            this.textBox12.Text = global::WASAPI_Arduino.Properties.Settings.Default.textSmoothing;
            this.textBox12.TextChanged += new System.EventHandler(this.textBox12_TextChanged);
            this.textBox12.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Login_KeyPress);
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(422, 318);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(40, 20);
            this.textBox13.TabIndex = 40;
            this.textBox13.Text = "100";
            this.textBox13.TextChanged += new System.EventHandler(this.textBox13_TextChanged);
            this.textBox13.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Login_KeyPress);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 356);
            this.Controls.Add(this.textBox13);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.trackBar13);
            this.Controls.Add(this.trackBar12);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.trackBar11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trackBar9);
            this.Controls.Add(this.trackBar10);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar5);
            this.Controls.Add(this.trackBar6);
            this.Controls.Add(this.trackBar7);
            this.Controls.Add(this.trackBar8);
            this.Controls.Add(this.trackBar4);
            this.Controls.Add(this.trackBar3);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.trackBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Corrector";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar13)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        // Method for keypress detection, it will trigger a keyStroke bool state change, enabling/disabling 
        // textBox text change parsing to trackBars value.
        void Login_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)45) // "-" sign detection
                keyStroke = false;

            else if (e.KeyChar == (char)8) // backspace/delete functionality enabler
                e.Handled = false;
            else if (e.KeyChar == (char)44) // detect "," sign and swap for "."
                e.KeyChar = (char)46;
            else if (e.KeyChar == (char)46) // "." sign enabler
                e.Handled = false;
            else if (!char.IsDigit(e.KeyChar)) // disable any other input
                e.Handled = true;
            else
                keyStroke = true;
        }
        #endregion

        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.TrackBar trackBar4;
        private System.Windows.Forms.TrackBar trackBar5;
        private System.Windows.Forms.TrackBar trackBar6;
        private System.Windows.Forms.TrackBar trackBar7;
        private System.Windows.Forms.TrackBar trackBar8;
        private System.Windows.Forms.TrackBar trackBar9;
        private System.Windows.Forms.TrackBar trackBar10;
        private System.Windows.Forms.TrackBar trackBar11;
        private System.Windows.Forms.TrackBar trackBar12;
        private System.Windows.Forms.TrackBar trackBar13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.CheckBox checkBox1;

    }
}
