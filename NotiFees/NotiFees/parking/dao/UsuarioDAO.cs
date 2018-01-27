using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotiFees.parking.dao
{
    class UsuarioDAO
    {
        public List<Usuario> getAll() {

            List<Usuario> list = new List<Usuario>();
            
            try
            {
                using (var context = new ParkingDB())
                {
                    list = (from usu in context.Usuarios orderby usu.id select usu).ToList();
                }
            }
            catch (Exception ex)
            {
                Program.Escribir_Log(DateTime.Now.ToString(), "UsuarioDao getAll" + ex);
            }
            return list;
        }
    }
}
