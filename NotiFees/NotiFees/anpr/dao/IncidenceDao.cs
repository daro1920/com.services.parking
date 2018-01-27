using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotiFees.anpr.dao
{
    class IncidenceDao
    {

        internal string getImage(int id)
        {
            string img = "";

            

            try
            {
                using (var context = new AnprDB())
                {
                    img = (from ind in context.Incidence where ind.ID == id select ind.ImagePath).FirstOrDefault();
                }
            } catch (Exception ex)
            {
                Program.Escribir_Log(DateTime.Now.ToString(), "Error obteniendo la url de la imagen id: "+id+" " + ex);
            }

            Program.Escribir_Log(DateTime.Now.ToString(), "Imagen Obtenida " + img);
            return img;
        }
    }
}
