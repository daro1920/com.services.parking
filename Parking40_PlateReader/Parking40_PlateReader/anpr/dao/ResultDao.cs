using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;

namespace Parking40_PlateReader
{
    class ResultDao
    {
        public List<Result> getAll()
        {
            List<Result> list = null;
            using (var context = new AnprDB())
            {
                list = (from res in context.Results orderby res.ID select res).ToList();
            }
            return list;
        }

        public List<Result> getNoProcessResults(int lastProcess)
        {
            List<Result> list = new List<Result>();
            try { 
                
                using (var context = new AnprDB())
                {
                    list = (from res in context.Results orderby res.ID  where res.ID > lastProcess orderby res.ID ascending select res).ToList();
                }
            } catch (EntityException ex) {
                Program.log.Error("EntityException" + ex);
            } catch (Exception ex) {
                Program.log.Error("Exception" + ex);
            }
            return list;
        }
    }
}
