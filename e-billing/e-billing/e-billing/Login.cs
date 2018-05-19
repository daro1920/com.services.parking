using e_billing.parking.dao;
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
    public partial class Login : Form
    {
        private UsuarioDAO userDAO = new UsuarioDAO();
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Usuario usuario = userDAO.getUserByName(user.Text);
            if (usuario != null && password.Text == usuario.str_password)
            {
                this.Hide();
                Main main = new Main();
                main.ShowDialog();
                this.Close();
            } else
            {
                errorText.Text = "El usuario y/o la contaseña son incorrectos";
                errorText.Visible = true;
            }
        }
    }
}
