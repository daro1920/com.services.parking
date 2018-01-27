using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsometro.ParkinEs.dao
{
    class AdentroDAO
    {

        public Adentro getAdentroEster(string plate, int ticket)
        {

            Adentro adentro = new Adentro();
            Program.log.Info("entra adentroDao");
            try
            {
                using (var context = new ParkingEsther())
                {
                    adentro = (from ade in context.Adentroes orderby ade. id where ade.str_matricula == plate && ade.correlativo_ticket == ticket select ade).FirstOrDefault();
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
            return adentro;
        }

    }
}
