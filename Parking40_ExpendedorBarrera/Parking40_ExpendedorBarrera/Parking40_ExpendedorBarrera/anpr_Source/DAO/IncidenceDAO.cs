using System;
using System.Data;
using System.Linq;

namespace Parking40_ExpendedorBarrera
{
    class IncidenceDao
    {
        internal int getCam(int id)
        {
            int cam = 0;

            try
            {
                using (var context = new ANPR())
                {
                    cam = (from ind in context.INCIDENCE orderby ind.ID where ind.ID == id select ind.camera_id).FirstOrDefault();
                }
            }
            catch (EntityException ex)
            {
                Program.log.Error("Error obteniendo camara " + ex);
            }
            catch (Exception ex)
            {
                Program.log.Error("Error obteniendo camara" + ex);
            }
            return cam;
        }

    }
}
