using e_billing.parking.dao;
using e_billing.parking.model;
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
    public partial class AddMove : Form
    {

        private MovimientosCajaDAO movCajaDAO = new MovimientosCajaDAO();
        private TipoMovimientoDAO movTypeDao = new TipoMovimientoDAO();

        public AddMove()
        {
            InitializeComponent();
        }

        private void AddMove_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'parkingDataSet2.TipoMovimientoCaja' table. You can move, or remove it, as needed.
            this.tipoMovimientoCajaTableAdapter.Fill(this.parkingDataSet2.TipoMovimientoCaja);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            User user = Login.logUser;
            MovimientosCaja movCaja = new MovimientosCaja();

            int idMovCaja = Int32.Parse(vehType.SelectedValue.ToString());
            String movDesc = movTypeDao.getMovDescById(idMovCaja);
            String movType = movTypeDao.getMovTypeById(idMovCaja);
            int imp =  Int32.Parse(this.strImp.Text);

            //movCaja.str_fecha = this.strFecha.Text;
            //movCaja.str_hora = this.strHora.Text;
            movCaja.str_fecha = Program.getFormatDate(this.strFecha.Text);
            movCaja.str_hora = Program.getFormatHour(this.strHora.Text);
            movCaja.id_tipo_movimiento = idMovCaja;
            movCaja.importe = movType.Equals("DEBITO") ? -imp : imp;
            movCaja.str_eliminado = "NO";
            movCaja.str_observaciones = this.strObs.Text;
            movCaja.id_usuario = user.ID;

            movCajaDAO.addMovCaja(ref movCaja);

            Program.generateMove(movCaja, movDesc, this.strFecha.Text, this.strHora.Text);
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
