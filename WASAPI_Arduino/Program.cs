using System.Windows.Forms;
using System;

namespace WASAPI_Arduino
{
    static class Program

    {
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                SamplerAppContext app = new SamplerAppContext();
                Application.ApplicationExit += app.OnApplicationExit;
                Application.Run(app);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            }
    }
}
