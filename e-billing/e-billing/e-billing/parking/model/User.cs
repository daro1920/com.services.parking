using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_billing.parking.model
{
    public class User
    {
        private int id;
        private String nombre;
        private String apellido;

        public int ID { get => id; set => id = value; }
        public String NOMBRE { get => nombre; set => nombre = value; }
        public String APELLIDO { get => apellido; set => apellido = value; }

        public User(int id) {
            ID = id;
            NOMBRE = nombre;
            APELLIDO = apellido;
        }
    }
}
