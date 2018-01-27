using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotiFees.parking.dao
{
    class EstadoLlaveroDao
    {
        private string free = "LIBRE";
        private string full = "OCUPADO";
        public EstadoLlavero getFreeEstadoLlavero(string plate,int ticket)
        {
            EstadoLlavero freeKey = new EstadoLlavero();
            using (var context = new ParkingDB())
            {

                freeKey = (from key in context.EstadoLlavero where key.estado == free select key).FirstOrDefault();

                // Submit the changes to the database.
                try
                {
                    freeKey.estado = full;
                    freeKey.matricula = plate;
                    freeKey.ticket = ticket ;
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Program.Escribir_Log(DateTime.Now.ToString(), "Error al actualizar EstadoLlavero: "+ ex);
                }

            }
            return freeKey;
        }
    }
}
