using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;

namespace Parking40_PlateReader.parking.dao
{
    class VehiculosRegistradosDao
    {

        public VehiculosRegistrado getVehiculosRegistrado(string plate)
        {
            VehiculosRegistrado vehReg = new VehiculosRegistrado();
            using (var context = new ParkingDB())
            {
                vehReg = (from veh in context.VehiculosRegistrados orderby veh.id where veh.str_matricula == plate select veh).FirstOrDefault();
            }
            return vehReg;
        }

        public VehiculosRegistrado getVehiculoMensual(string plate)
        {
            VehiculosRegistrado vehReg = new VehiculosRegistrado();
            using (var context = new ParkingDB())
            {
                vehReg = (from veh in context.VehiculosRegistrados
                          orderby veh.id
                          where veh.str_matricula == plate && veh.observaciones != "Agregado por sistema en salida con RUT"
                          select veh).FirstOrDefault();
            }
            if (vehReg == null)
            {
                vehReg = getVehiculoMensualContainPlate(plate);
            }
            return vehReg;
        }

        public VehiculosRegistrado getVehiculoMensualContainPlate(string plate)
        {

            List<VehiculosRegistrado> vehRegs = new List<VehiculosRegistrado>();
            VehiculosRegistrado vehReg = null;

            try
            {
                using (var context = new ParkingDB())
                {

                    vehRegs = (from veh in context.VehiculosRegistrados orderby veh.id where veh.observaciones != "Agregado por sistema en salida con RUT" select veh).ToList();

                }


                foreach (VehiculosRegistrado veh in vehRegs)
                {
                    if (Program.getEquivalent(veh.str_matricula, plate))
                    {
                        vehReg = veh;
                        break;
                    }
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

            return vehReg;
        }
    }
}
