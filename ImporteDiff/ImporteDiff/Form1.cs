using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        #region Member Variables
        const string strConnectionString = "data source=localhost;Integrated Security=SSPI;Initial Catalog=Northwind;";
        StringFormat strFormat; //Used to format the grid rows.
        ArrayList arrColumnLefts = new ArrayList();//Used to save left coordinates of columns
        ArrayList arrColumnWidths = new ArrayList();//Used to save column widths
        int iCellHeight = 0; //Used to get/set the datagridview cell height
        int iTotalWidth = 0; //
        int iRow = 0;//Used as counter
        bool bFirstPage = false; //Used to check whether we are printing first page
        bool bNewPage = false;// Used to check whether we are printing a new page
        int iHeaderHeight = 0; //Used for the header height
        string docTitle = "Diferencia de Importes";
        #endregion

        private BindingSource bindingSource1 = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();

        public Form1()
        {
            InitializeComponent();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {


        }
        private void Form1_Load(object sender, EventArgs e) {

            try
            {
                strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Near;
                strFormat.LineAlignment = StringAlignment.Center;
                strFormat.Trimming = StringTrimming.EllipsisCharacter;

                arrColumnLefts.Clear();
                arrColumnWidths.Clear();
                iCellHeight = 0;
                iRow = 0;
                bFirstPage = true;
                bNewPage = true;

                // Calculating Total Widths
                iTotalWidth = 0;
                foreach (DataGridViewColumn dgvGridCol in dataGridView1.Columns)
                {
                    iTotalWidth += dgvGridCol.Width;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) { }
        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }


        private void button1_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            SqlDataReader sqlReader = null;

            //dataGridView1.DataSource = bindingSource1;
            
            try
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PARKING"].ConnectionString;

                // Getting id,fromHour and toHour
                string strQuery = "SELECT  correlativo_documento_emision as Correlativo,importe_calculado as Calculado, " +
                                    "importe as Importe ,str_observaciones as Obs,(str_fecha +' '+str_hora) hora,minutos " +
                                    "FROM[Parking].[dbo].[MovimientosCaja] " +
                                    "WHERE importe_calculado <> importe and id_tipo_movimiento = 1 ";

                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                sqlCommand = new SqlCommand(strQuery, sqlConnection);
                sqlReader = sqlCommand.ExecuteReader();
                
                while (sqlReader.Read())
                {

                    if (String.Compare(sqlReader[4].ToString() ,Program.getFormatDate(this.fromDate.Text, sqlReader[5].ToString())) > 0 &&
                        String.Compare(sqlReader[4].ToString(), Program.getFormatDate(this.toDate.Text, sqlReader[5].ToString())) < 0)
                    {
                        object[] row = { sqlReader[0], sqlReader[1], sqlReader[2], sqlReader[3] };
                        dataGridView1.Rows.Add(row);
                    }
                    
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                sqlConnection.Close();
                if (sqlReader != null)
                {
                    sqlReader.Dispose();
                    sqlReader = null;
                }
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                    sqlCommand = null;
                }
            }

            this.print.Visible = true;

        }
        
        private void print_Click(object sender, EventArgs e)
        {
            //Open the print dialog
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1;
            printDialog.UseEXDialog = true;

            //Get the document
            if (DialogResult.OK == printDialog.ShowDialog())
            {
                printDocument1.DocumentName = docTitle;
                printDocument1.Print();
            }
            
        }

        

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                //Set the left margin
                int iLeftMargin = 5;
                //Set the top margin
                int iTopMargin = e.MarginBounds.Top;
                //Whether more pages have to print or not
                bool bMorePagesToPrint = false;
                int iTmpWidth = 0;

                //For the first page to print set the cell width and header height
                if (bFirstPage)
                {
                    foreach (DataGridViewColumn GridCol in dataGridView1.Columns)
                    {
                        //iTmpWidth = (int)(Math.Floor((double)((double)GridCol.Width /
                        //               (double)iTotalWidth * (double)iTotalWidth *
                        //               ((double)e.MarginBounds.Width / (double)iTotalWidth))));

                        //iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText,
                        //            GridCol.InheritedStyle.Font, iTmpWidth).Height) + 11;
                        iTmpWidth = 70;
                        iHeaderHeight = 25;
                        // Save width and height of headres
                        arrColumnLefts.Add(iLeftMargin);
                        arrColumnWidths.Add(iTmpWidth);
                        iLeftMargin += iTmpWidth;
                    }
                }
                //Loop till all the grid rows not get printed
                while (iRow <= dataGridView1.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = dataGridView1.Rows[iRow];
                    //Set the cell height
                    iCellHeight = GridRow.Height + 5;
                    int iCount = 0;
                    //Check whether the current page settings allows more rows to print
                    if (iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        bNewPage = true;
                        bFirstPage = false;
                        bMorePagesToPrint = true;
                        break;
                    }
                    else
                    {
                        if (bNewPage)
                        {
                            //Draw Header
                            e.Graphics.DrawString(docTitle, new Font(dataGridView1.Font, FontStyle.Bold),
                                    Brushes.Black, 5, e.MarginBounds.Top -
                                    e.Graphics.MeasureString(docTitle, new Font(dataGridView1.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            String strDate = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
                            //Draw Date
                            e.Graphics.DrawString("Desde " + this.fromDate.Text, new Font(dataGridView1.Font, FontStyle.Bold),
                                    Brushes.Black,5, e.MarginBounds.Top -
                                    e.Graphics.MeasureString(docTitle, new Font(new Font(dataGridView1.Font,
                                    FontStyle.Bold), FontStyle.Bold), e.MarginBounds.Width).Height);
                            //Draw Date
                            e.Graphics.DrawString("Hasta " + this.toDate.Text, new Font(dataGridView1.Font, FontStyle.Bold),
                                    Brushes.Black, 150, e.MarginBounds.Top -
                                    e.Graphics.MeasureString(docTitle, new Font(new Font(dataGridView1.Font,
                                    FontStyle.Bold), FontStyle.Bold), e.MarginBounds.Width).Height );

                            //Draw Columns                 
                            iTopMargin = e.MarginBounds.Top;
                            foreach (DataGridViewColumn GridCol in dataGridView1.Columns)
                            {
                                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawRectangle(Pens.Black,
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawString(GridCol.HeaderText, GridCol.InheritedStyle.Font,
                                    new SolidBrush(GridCol.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight), strFormat);
                                iCount++;
                            }
                            bNewPage = false;
                            iTopMargin += iHeaderHeight;
                        }
                        iCount = 0;
                        //Draw Columns Contents                
                        foreach (DataGridViewCell Cel in GridRow.Cells)
                        {
                            if (Cel.Value != null)
                            {
                                e.Graphics.DrawString(Cel.Value.ToString(), Cel.InheritedStyle.Font,
                                            new SolidBrush(Cel.InheritedStyle.ForeColor),
                                            new RectangleF((int)arrColumnLefts[iCount], (float)iTopMargin,
                                            (int)arrColumnWidths[iCount], (float)iCellHeight), strFormat);
                            }
                            //Drawing Cells Borders 
                            e.Graphics.DrawRectangle(Pens.Black, new Rectangle((int)arrColumnLefts[iCount],
                                    iTopMargin, (int)arrColumnWidths[iCount], iCellHeight));

                            iCount++;
                        }
                    }
                    iRow++;
                    iTopMargin += iCellHeight;
                }

                //If more lines exist, print another page.
                if (bMorePagesToPrint)
                    e.HasMorePages = true;
                else
                    e.HasMorePages = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
