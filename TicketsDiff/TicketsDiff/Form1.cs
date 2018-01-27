using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private static Font printFont;
        private static String xrLabel_Total;
        private static String xrLabel_supuesto;
        private static String xrLabel_diferencia;
        private static String fDate;
        private static String tDate;

        public Form1()
        {
            InitializeComponent();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e){


        }
        private void Form1_Load(object sender, EventArgs e){}
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e){}
        private void panel2_Paint(object sender, PaintEventArgs e) {}


        private void button1_Click(object sender, EventArgs e)
        {

            fDate = this.fromDate.Text;
            tDate = this.toDate.Text;

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PARKING"].ConnectionString;

            // Getting id,fromHour and toHour
            string insertStmt = "SELECT (max([correlativo_documento_emision]) -min([correlativo_documento_emision]))+1, "+
                                "count([correlativo_documento_emision]),(max([correlativo_documento_emision]) - "+
                                "min([correlativo_documento_emision]))-count([correlativo_documento_emision])+1 as diferencia "+
                                "FROM[Parking].[dbo].[MovimientosCaja]  where id_tipo_movimiento in (1,3,5,6,7) "+
                                "and (str_fecha >= '" + Program.getFormatDate(fDate) + "' and str_fecha <= '" + Program.getFormatDate(tDate) + "' )";

            //SqlDataReader myReader;
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(insertStmt, conn))
            {

                // open connection, execute command, close connection
                conn.Open();
                var myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    if (myReader[0] != DBNull.Value)
                    {
                        xrLabel_supuesto = myReader.GetInt32(0).ToString();
                    } else
                    {
                        xrLabel_supuesto = "0";
                    }
                    if (myReader[1] != DBNull.Value)
                    {
                        xrLabel_Total  = myReader.GetInt32(1).ToString();
                    } else
                    {
                        xrLabel_Total = "0";
                    }
                    if (myReader[2] != DBNull.Value)
                    {
                        xrLabel_diferencia = myReader.GetInt32(2).ToString();
                    } else
                    {
                        xrLabel_diferencia = "0";
                    }

                    
                    
                    
                }

                this.totalResult.Text = xrLabel_Total;
                this.supuestoResult.Text = xrLabel_supuesto;
                this.difResult.Text = xrLabel_diferencia;
                
                this.print.Visible = true;

                conn.Close();
               
            }
       

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Open the print dialog
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1;
            printDialog.UseEXDialog = true;

            //Show Print Dialog Print
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                //Print the page
                printFont = new Font("Arial", 10);
                printDocument1.PrintPage += new PrintPageEventHandler(ticket_PrintPage);
                printDocument1.Print();
            }
        }

        // The PrintPage event is raised for each page to be printed. 
        private static void ticket_PrintPage(object sender, PrintPageEventArgs ev)
        {
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;


            // Print each line of the file. 
            Point p = new Point(0, 0);
            //int n;

            int margen_der = 50;

            ev.Graphics.DrawString("Diferencia de Tickets", printFont, Brushes.Black, 5, printFont.GetHeight(ev.Graphics), new StringFormat());

            ev.Graphics.DrawString("Desde " + fDate, printFont, Brushes.Black, 5, 3 * printFont.GetHeight(ev.Graphics), new StringFormat());
            ev.Graphics.DrawString("Hasta " + tDate, printFont, Brushes.Black, 5, 4 * printFont.GetHeight(ev.Graphics), new StringFormat());

            ev.Graphics.DrawString("Total =", printFont, Brushes.Black, 5, 5 * printFont.GetHeight(ev.Graphics), new StringFormat());
            ev.Graphics.DrawString(xrLabel_Total, printFont, Brushes.Black, margen_der,5 * printFont.GetHeight(ev.Graphics), new StringFormat());

            ev.Graphics.DrawString("Supuesto =", printFont, Brushes.Black, 5, 6 * printFont.GetHeight(ev.Graphics), new StringFormat());
            ev.Graphics.DrawString(xrLabel_supuesto, printFont, Brushes.Black, margen_der+30, 6 * printFont.GetHeight(ev.Graphics), new StringFormat());

            ev.Graphics.DrawString("Diferencia =", printFont, Brushes.Black, 5, 7 * printFont.GetHeight(ev.Graphics), new StringFormat());
            ev.Graphics.DrawString(xrLabel_diferencia, printFont, Brushes.Black, margen_der+40, 7 * printFont.GetHeight(ev.Graphics), new StringFormat());

        }
    }
}
