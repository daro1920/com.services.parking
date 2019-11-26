using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;

namespace Parking40_PlateReader.anpr.dao
{
    class IncidenceDao
    {
        internal int getCam(int id)
        {
            int cam = 0;

            try
            {
                using (var context = new AnprDB())
                {
                    cam = (from ind in context.Incidences orderby ind.ID where ind.ID == id select ind.camera_id).FirstOrDefault();
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
