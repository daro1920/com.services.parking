using System;
using System.Collections.Generic;
using System.Linq;

namespace e_billing.parking.dao
{
    class AdentroDAO
    {

        public void addAdentro(ref Adentro adentro)
        {
            try
            {
                using (var context = new ParkingEntities2())
                {
                    context.Adentroes.Add(adentro);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Program.log.Error(DateTime.Now.ToString()+" AdentroDao addAdentro" + ex);
            }
        }

        public List<string> getAll()
        {

            List<string> list = new List<string>();

            try
            {
                using (var context = new ParkingEntities2())
                {
                    list = (from ade in context.Adentroes orderby ade.id select ade.str_matricula).ToList();
                }
            }
            catch (Exception ex)
            {
                Program.log.Error(DateTime.Now.ToString()+" AdentroDao getAll " + ex);
            }
            return list;
        }

        public int getTotalRecord()
        {

            int total = 0;


            try
            {
                using (var context = new ParkingEntities2())
                {

                    total = (from ade in context.Adentroes select ade).Count();

                }
            }
            catch (Exception ex)
            {
                Program.log.Error(DateTime.Now.ToString()+ "NotificacionesDao getTotalRecord" + ex);
            }
            return total;
        }
    }
}
