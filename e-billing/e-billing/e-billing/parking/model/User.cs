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

        public int ID { get => id; set => id = value; }

        public User(int id) {
            ID = id;
        }
    }
}
