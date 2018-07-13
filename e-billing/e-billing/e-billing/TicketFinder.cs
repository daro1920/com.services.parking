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
        

        private async void textBoxCB_TextChanged(object sender, EventArgs e)
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
                        var ticketId = row.Cells[0].Value != null ? row.Cells[0].Value.ToString(): "";
                        if (ticketId.Equals(ticket))
                        {
                            rowIndex = row.Index;
                            break;
                        }
                    }
                    if (rowIndex >= 0)
                    {
                        await Task.Delay(1000);
                        mainForm.salida(rowIndex);
                        this.Close();
                    } else
                    {
                        //ticket not found message
                        this.errorMessage.Visible = true;
                    }
                    
                }
            }
        }
        
    }
}
