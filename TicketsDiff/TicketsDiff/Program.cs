using System;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        // date = dd\MM\yyyy
        //return yyyyMMdd
        internal static string getFormatDate(string date)
        {

            String[] dmy = date.Split('/');

            return dmy[2]+ dmy[1]+ dmy[0];
        }
    }
}
