using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Configuration;
using System.Data.SqlClient;

//using ANPR_MX_Sample;

namespace Parking40_ExpendedorBarrera
{
    public partial class Entrada_X_UI : Form
    {
        SoundPlayer simpleSound = null;
        public String numAnt = String.Empty;

        public Entrada_X_UI()
        {
            KeyPreview = true;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(KeyEvent);
            InitializeComponent();
        }

        private void textBoxCB_TextChanged(object sender, EventArgs e)
        {
            int n = 0;
            Boolean notFound = true;

            
            if ((this.textBoxCB.Text.Trim().Length == 10) && (int.TryParse(this.textBoxCB.Text.Trim().Substring(0, 8), out n)))
            {

                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PARKING"].ConnectionString;

                // Getting id,fromHour and toHour
                string insertStmt = "SELECT autorizado1_ci, autorizado2_ci,autorizado3_ci FROM [PARKING].[dbo].[VehiculosRegistrados]";

                //SqlDataReader myReader;
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(insertStmt, conn))
                {

                    // open connection, execute command, close connection
                    conn.Open();
                    var myReader = cmd.ExecuteReader();

                    var currentHour = DateTime.Now.Hour;

                    while (myReader.Read())
                    {
                        //Write logic to process data for the first result.
                        
                        if ( textBoxCB.Text.Equals(myReader.GetString(0)) )
                        {


                            int hourIn = Int32.Parse(myReader.GetString(1));
                            int hourOut = Int32.Parse(myReader.GetString(2));

                            if ( Program.isWeekEnd() || Program.isHoliday() || Program.isInTime(currentHour,hourIn,hourOut) )
                            {
                                //Playing beep
                                simpleSound = new SoundPlayer(ConfigurationManager.AppSettings["BEEP_SOUND_CARD"].ToString().Trim());
                                simpleSound.Play();

                                Program.Abrir_Barrera();

                                textBoxCB.Text = String.Empty;
                                textBoxCB.Refresh();
                                textBoxCB.Focus();
                                this.numAnt = "";

                                notFound = false;

                                break;
                            }
                        }
                    }
                    conn.Close();
                    if (notFound)
                    {

                        Console.WriteLine("Sonido error ");
                        simpleSound = new SoundPlayer(ConfigurationManager.AppSettings["BEEP_SOUND_NOT_ALLOW"].ToString().Trim());
                        simpleSound.Play();

                        textBoxCB.Text = String.Empty;
                        textBoxCB.Refresh();
                        textBoxCB.Focus();
                        this.numAnt = "";

                    }
                }
            }
        }

        


        private void KeyEvent(object sender, KeyEventArgs e) //Keyup Event 
        {
            
            if (e.KeyCode == Keys.F12)
            {
                this.KeyUp -= new System.Windows.Forms.KeyEventHandler(KeyEvent);
                timer2.Start();

                if (Program.Generar_Entrada() != 1)
                {
                    //Playing beep
                    simpleSound = new SoundPlayer(ConfigurationManager.AppSettings["BEEP_SOUND_SUCCES"].ToString().Trim());
                    simpleSound.Play();

                    Program.Abrir_Barrera();
                }
                
            }
         
        }
       

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.textBoxCB.Text.Trim().Length != 0)
            {
                if (this.numAnt.Length == 0)//si el registro anterior es vacio
                {
                    this.numAnt = this.textBoxCB.Text.Trim();
                }
                else
                    if (this.numAnt.Equals(this.textBoxCB.Text.Trim()))// si la lectura es igual al registro anterior
                    {
                        // borro todo
                        textBoxCB.Text = String.Empty;
                        textBoxCB.Refresh();
                        textBoxCB.Focus();
                        this.numAnt = "";
                    }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(KeyEvent);
            timer2.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ANPR_MX_Sample.Form1 anpr = new ANPR_MX_Sample.Form1();

            //anpr.btnCargar_Click();
        }


    }
}
