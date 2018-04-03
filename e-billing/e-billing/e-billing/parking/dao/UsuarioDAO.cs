using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_billing.parking.dao
{
    class UsuarioDAO
    {

        public Usuario getUser(string userName)
        {
            Usuario user = new Usuario();
            Program.log.Info("entra usuarioDAO");
            try
            {
                using (var context = new ParkingEntities2())
                {
                    user = (from usu in context.Usuarios where usu.str_nombre_usuario == userName   select usu).FirstOrDefault();
                }
            }
            catch (EntityException ex)
            {
                Program.log.Error("EntityException" + ex);
            }
            catch (Exception ex)
            {
                Program.log.Error("Exception" + ex);
            }
            return user;
        }

    }
}


