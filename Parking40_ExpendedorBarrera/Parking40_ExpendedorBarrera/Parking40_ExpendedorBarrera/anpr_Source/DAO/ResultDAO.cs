using Parking40_ExpendedorBarrera;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Parking40_ExpendedorBarrera
{
    class ResultDAO
    {
        public List<RESULTS> getAll()
        {
            List<RESULTS> list = null;
            using (var context = new ANPR())
            {
                list = (from res in context.RESULTS orderby res.ID select res).ToList();
            }
            return list;
        }

        public string getPlateByID(int id)
        {
            string plate = "";
            using (var context = new ANPR())
            {
                plate = (from res in context.RESULTS where res.INCIDENCEID == id select res.NumberPlate).FirstOrDefault();
            }
            return plate;
        }

        public List<RESULTS> getNoProcessResults(int lastProcess)
        {
            List<RESULTS> list = new List<RESULTS>();
            try
            {

                using (var context = new ANPR())
                {
                    list = (from res in context.RESULTS orderby res.ID where res.ID > lastProcess orderby res.ID ascending select res).ToList();
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
            return list;
        }
    }
}
