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
        internal static string getFormatDate(string date,string minute)
        {

            String[] dateHour = date.Split(' ');
            String[] dmy = dateHour[0].Split('/');

            TimeSpan s1 = TimeSpan.Parse("00:"+ minute);
            TimeSpan s2 = TimeSpan.Parse(dateHour[1]);
            TimeSpan s3 = s1 + s2;

            return dmy[2]+dmy[1]+dmy[0]+' '+ s3.ToString();
        }
    }
}
