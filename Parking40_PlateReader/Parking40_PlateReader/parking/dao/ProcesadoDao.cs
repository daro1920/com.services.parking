using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;

namespace Parking40_PlateReader.parking.dao
{
    class ProcesadoDao
    {

        public List<Procesado> getAll()
        {
            List<Procesado> list = null;
            
            try
            {
                using (var context = new ParkingDB())
                {
                    list = (from pro in context.Procesados orderby pro.id select pro).ToList();
                }
            }
            catch (EntityException ex)
            {
                Program.log.Error("Error obteniendo procesados" + ex);
            }
            catch (Exception ex)
            {
                Program.log.Error("Error obteniendo procesados" + ex);
            }
            return list;
        }

        public int getLastProcess() {
            int lastProcess = 0;
            try { 
                using (var context = new ParkingDB())
                {
                    lastProcess = (from pro in context.Procesados where pro.id == 1 select pro.ultimo_procesado).FirstOrDefault();
                }
            } catch (EntityException ex) {
                Program.log.Error("Error obteniendo el ultimo procesado" + ex);
            } catch (Exception ex) {
                Program.log.Error("Error obteniendo el ultimo procesado" + ex);
            }
            return lastProcess;
        }

        public void updateProcess(int lastProcess)
        {
            
            try
            {
                using (var context = new ParkingDB())
                {
                    var processRes = (from pro in context.Procesados where pro.id == 1 select pro).FirstOrDefault();

                    if(processRes.ultimo_procesado < lastProcess)
                    {
                        processRes.ultimo_procesado = lastProcess;
                        // Submit the changes to the database.
                        context.SaveChanges();
                    }
                }
            }
            catch (EntityException ex)
            {
                Program.log.Error("Error al actualizar la tabla de procesados" + ex);
            }
            catch (Exception ex)
            {
                Program.log.Error("Error al actualizar la tabla de procesados" + ex);
            }
        }
    }
}
