using System.Windows.Forms;

namespace WASAPI_Arduino
{
    static class Program

    {
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SamplerAppContext app = new SamplerAppContext();
            Application.ApplicationExit += app.OnApplicationExit;
            Application.Run(app);
        }   
    }
}
