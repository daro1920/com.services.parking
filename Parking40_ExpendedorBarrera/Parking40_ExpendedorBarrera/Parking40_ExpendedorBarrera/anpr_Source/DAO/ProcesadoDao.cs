using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking40_ExpendedorBarrera.anpr_Source.DAO
{
    class ProcesadoDao
    {

        public List<ProcesadosCam> getAll()
        {
            List<ProcesadosCam> list = null;

            try
            {
                using (var context = new ParkingEntities())
                {
                    list = (from pro in context.ProcesadosCam orderby pro.id select pro).ToList();
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

        public int getLastProcess(int camID)
        {
            int lastProcess = 0;
            try
            {
                using (var context = new ParkingEntities())
                {
                    lastProcess = (from pro in context.ProcesadosCam where pro.camID == camID select pro.ultimo_procesado).FirstOrDefault();
                }
            }
            catch (EntityException ex)
            {
                Program.log.Error("Error obteniendo el ultimo procesado" + ex);
            }
            catch (Exception ex)
            {
                Program.log.Error("Error obteniendo el ultimo procesado" + ex);
            }
            return lastProcess;
        }

        public void updateProcess(int camID, int lastProcess)
        {

            try
            {
                using (var context = new ParkingEntities())
                {
                    var processRes = (from pro in context.ProcesadosCam where pro.camID == camID select pro).FirstOrDefault();

                    Program.log.Debug("Procesado en base antes de actualizar" + processRes.ultimo_procesado);
                    Program.log.Debug("Nuevo Procesado a actualizar" + lastProcess);
                    if (processRes.ultimo_procesado < lastProcess)
                    {
                        processRes.ultimo_procesado = lastProcess;
                        //processRes.fecha = DateTime.Now;
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