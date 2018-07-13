using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_billing.parking.dao
{
    class EstadoLlaveroDAO
    {

        public EstadoLlavero getKeyState(string plate, int ticket)
        {
            EstadoLlavero esLl = new EstadoLlavero();
            Program.log.Info("entra EstadoLlaveroDAO");
            try
            {
                using (var context = new ParkingEntities2())
                {
                    esLl = (from el in context.EstadoLlaveroes
                            where el.matricula == plate && el.ticket == ticket select el).FirstOrDefault();
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
            return esLl;
        }
        private string free = "LIBRE";
        private string full = "OCUPADO";
        public void assignFreeEstadoLlavero(string plate, int ticket)
        {
            EstadoLlavero freeKey = new EstadoLlavero();
            using (var context = new ParkingEntities2())
            {

                freeKey = (from key in context.EstadoLlaveroes where key.estado == free select key).FirstOrDefault();

                // Submit the changes to the database.
                try
                {
                    freeKey.estado = full;
                    freeKey.matricula = plate;
                    freeKey.ticket = ticket;
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Program.log.Error(DateTime.Now.ToString()+ " Error al actualizar EstadoLlavero: " + ex);
                }

            }
        }
        public void setFreeEstadoLlavero(string plate, int ticket)
        {
            EstadoLlavero freeKey = new EstadoLlavero();
            using (var context = new ParkingEntities2())
            {

                freeKey = (from key in context.EstadoLlaveroes where key.estado == full && key.ticket == ticket && key.matricula ==  plate  select key).FirstOrDefault();

                // Submit the changes to the database.
                if (freeKey!=null) {
                    try
                    {
                        freeKey.estado = free;
                        freeKey.matricula = "";
                        freeKey.ticket = 0;
                        context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        Program.log.Error(DateTime.Now.ToString() + " Error al actualizar EstadoLlavero: " + ex);
                    }
                }
            }
        }
    }
}
