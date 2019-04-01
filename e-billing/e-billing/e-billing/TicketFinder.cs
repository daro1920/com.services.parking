using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_billing
{
    public partial class TicketFinder : Form
    {
        private Main mainForm;
        private DataGridView adentroModDataGridView;


        public TicketFinder()
        {
            InitializeComponent();
        }

        public TicketFinder(DataGridView adentroModDataGridView,Main main)
        {
            this.adentroModDataGridView = adentroModDataGridView;
            this.mainForm = main;
            InitializeComponent();
        }

        private void TicketFinder_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'parkingDataSet1.Convenios' table. You can move, or remove it, as needed.
            this.conveniosTableAdapter.Fill(this.parkingDataSet1.Convenios);

        }
        
        private async void textBoxCB_TextChangedAsync(object sender, EventArgs e)
        {
            if (this.textBoxCB.Text.Trim().Length > 4)
            {
                if ((this.textBoxCB.Text.Trim().Substring(0, 3) == "BAR") &&
                (this.textBoxCB.Text.Trim().Substring(this.textBoxCB.Text.Trim().Length - 1, 1) == "Z"))
                {
                    string ticket = this.textBoxCB.Text.Trim().Substring(3, this.textBoxCB.Text.Trim().Length - 4);

                    int rowIndex = -1;
                    foreach (DataGridViewRow row in adentroModDataGridView.Rows)
                    {
                        var ticketId = row.Cells[0].Value != null ? row.Cells[0].Value.ToString() : "";
                        if (ticketId.Equals(ticket))
                        {
                            rowIndex = row.Index;
                            break;
                        }
                    }
                    if (rowIndex >= 0)
                    {
                        int conv = Int32.Parse(vehConv.SelectedValue.ToString());
                        await Task.Delay(1000);
                        mainForm.salida(rowIndex, conv);
                        this.Close();
                    }
                    else
                    {
                        //ticket not found message
                        this.errorMessage.Visible = true;
                    }

                }
            }
        }
    }
}
