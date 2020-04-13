using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_billing.parking.dao
{
    class TipoMovimientoDAO
    {

        public String getMovDescById(int movId)
        {
            String type = "";
            Program.log.Info("entra TipoMovimientoDAO");
            try
            {
                using (var context = new ParkingEntities2())
                {
                    type = (from tmc in context.TipoMovimientoCajas where tmc.id == movId select tmc.str_descrip).FirstOrDefault();
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
            return type;
        }

        public String getMovTypeById(int movId)
        {
            String type = "";
            Program.log.Info("entra TipoMovimientoDAO");
            try
            {
                using (var context = new ParkingEntities2())
                {
                    type = (from tmc in context.TipoMovimientoCajas where tmc.id == movId select tmc.str_tipo).FirstOrDefault();
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
            return type;
        }
    }
}
