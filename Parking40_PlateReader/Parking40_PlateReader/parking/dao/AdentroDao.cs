using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;

namespace Parking40_PlateReader.parking.dao
{
    class AdentroDao
    {

        public Adentro getAdentro(string plate)
        {
            Adentro adentro = new Adentro();
            Program.log.Info("entra adentroDao");
            try { 
                using (var context = new ParkingDB())
                {
                    adentro = (from ade in context.Adentroes orderby ade.id where ade.str_matricula == plate select ade).FirstOrDefault();
                }
            } catch (EntityException ex) {
                Program.log.Error("EntityException" + ex);
            } catch (Exception ex) {
                Program.log.Error("Exception" + ex);
            }
            return adentro;
        }

    }
}
