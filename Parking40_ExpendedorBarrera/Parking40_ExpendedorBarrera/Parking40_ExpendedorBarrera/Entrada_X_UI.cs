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
using System.IO;

//using openalprnet;

//;using ANPR_MX_Sampl;

namespace Parking40_ExpendedorBarrera
{
    public partial class Entrada_X_UI : Form
    {

        SoundPlayer simpleSound = null;
        public String numAnt = String.Empty;
        //private ANPR_MX.MainControl.ImageProcessing tratImg = null;

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
                string insertStmt = "SELECT autorizado1_ci, autorizado2_ci,autorizado3_ci FROM [Parking_ester].[dbo].[VehiculosRegistrados]";

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
                Program.log.Debug("Boton precionado ");
                this.KeyUp -= new System.Windows.Forms.KeyEventHandler(KeyEvent);
                timer2.Start();

                Program.log.Debug("Generando entrada");
                if (Program.Generar_Entrada() != 1)
                {
                    Program.log.Debug("Entrada generada");
                    //Playing beep
                    simpleSound = new SoundPlayer(ConfigurationManager.AppSettings["BEEP_SOUND_SUCCES"].ToString().Trim());
                    simpleSound.Play();

                    Program.log.Debug("Abriendo Barrera");
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


        private void timer3_Tick(object sender, EventArgs e)
        {

            //var alpr = new AlprNet("us", "openalpr.conf", "runtime_data");
            //if (!alpr.IsLoaded())
            //{
            //    Console.WriteLine("OpenAlpr failed to load!");
            //    return;
            //}
            //// Optionally apply pattern matching for a particular region
            //alpr.DefaultRegion = "md";

            //var results = alpr.Recognize("c:/work/freelanceprojects/parking_img_sounds/images/fotos_parking/foto1.jpg");
            //int i = 0;
            //foreach (var result in results.Plates)
            //{
            //    Console.WriteLine("Plate {0}: {1} result(s)", i++, result.TopNPlates.Count);
            //    Console.WriteLine("  Processing Time: {0} msec(s)", result.ProcessingTimeMs);
            //    foreach (var plate in result.TopNPlates)
            //    {
            //        Console.WriteLine("  - {0}\t Confidence: {1}\tMatches Template: {2}", plate.Characters,
            //                          plate.OverallConfidence, plate.MatchesTemplate);
            //    }
            //}

            //tratImg = new ANPR_MX.MainControl.ImageProcessing();

            //string[] plates;
            //string query = "";
            //string reading = "";
            //List<string> lstplacas = new List<string>();



            //string pic = "c:/work/freelanceprojects/parking_img_sounds/images/fotos_parking/foto1.jpg";

            //string path = "c:/work/freelanceprojects/parking_img_sounds/images/fotos_parking/";
            //DirectoryInfo di = new DirectoryInfo(path);
            //FileInfo[] rgfiles = di.GetFiles("foto1.jpg");

            //foreach (FileInfo fi in rgfiles)
            //{
            //    if (null != fi)
            //    {
            //        Bitmap fullimage = tratImg.GetFullImage(fi.FullName);
            //        tratImg.ProcessImage(fi.FullName, out plates);
            //        if (plates != null)
            //        {
            //            foreach (string plate in plates)
            //            {
            //                if (plate != null && plate.Length == ANPR_MX.Globals.Constants.LIST_PLATE_MIN_CHARS)
            //                {
            //                    lstplacas.Add(plate);
            //                }

            //            }
            //        }
            //    }

            //    List<string> lstplacastotal = Program.getPossiblesPlates(lstplacas);
            //    if (lstplacastotal.Count > 0)
            //    {
            //        foreach (string plate in lstplacastotal)
            //        {
            //            query = query + " '" + plate + "' , ";
            //            reading = reading + " '" + plate + "'-";
            //        }
            //        query = query + " 'true' ";

            //        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["PARKING"].ConnectionString;
            //        // getting matricula
            //        string insertstmt = "select str_matricula from [PARKING].[dbo].[vehiculosregistrados] where str_matricula in(" + query + ") ";

            //        //sqldatareader myreader;
            //        using (SqlConnection conn = new SqlConnection(connectionstring))
            //        using (SqlCommand cmd = new SqlCommand(insertstmt, conn))
            //        {

            //            // open connection, execute command, close connection
            //            conn.Open();
            //            var myreader = cmd.ExecuteReader();
            //            if (myreader.HasRows)
            //            {
            //                while (myreader.Read())
            //                {
            //                    if (myreader.GetString(0) != null && !myreader.GetString(0).Equals(""))
            //                    {
            //                        //playing beep
            //                        simpleSound = new SoundPlayer(ConfigurationManager.AppSettings["beep_sound_succes"].ToString().Trim());
            //                        simpleSound.Play();

            //                        System.IO.File.Move(pic, "c:/work/freelanceprojects/parking_img_sounds/images/fotos_parking/" + myreader.GetString(0) + ".jpg");
            //                    }

            //                }
            //            }
            //            else
            //            {
            //                System.IO.File.Move(pic, "c:/work/freelanceprojects/parking_img_sounds/images/fotos_parking/" + reading + ".jpg");
            //            }

            //            conn.Close();

            //        }

            //    }
            //}

        }

                        
        
    }
}
