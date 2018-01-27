using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotiFees.parking.dao
{
    class AdentroDAO
    {
        public void addAdentro(ref Adentro adentro) {
            
            
            try
            {
                using (var context = new ParkingDB())
                {
                    context.Adentros.Add(adentro);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Program.Escribir_Log(DateTime.Now.ToString(), "AdentroDao addAdentro" + ex);
            }
        }

        public List<string> getAll() {

            List<string> list = new List<string>();
            
            try
            {
                using (var context = new ParkingDB())
                {
                    list = (from ade in context.Adentros orderby ade.id select ade.str_matricula).ToList();
                }
            }
            catch (Exception ex)
            {
                Program.Escribir_Log(DateTime.Now.ToString(), "AdentroDao getAll" + ex);
            }
            return list;
        }
    }
}
