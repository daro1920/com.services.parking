using System;
using System.Windows.Forms;
using Parking40_PlateReader.parking.dao;

namespace Parking40_PlateReader {

    static class Program {

        private static VehiculosRegistradosDao vehDao = new VehiculosRegistradosDao();
        private static AdentroDao adeDao = new AdentroDao();

        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }


        internal static Boolean notifyIn(string plate) {

            Boolean notify = false;

            Program.log.Info("Revisando en mesuales y en tabla adtentro");
            if (isMensualPlate(plate) || isPrePay(plate)) {
                
                VehiculosRegistrado vehicule= vehDao.getVehiculosRegistrado(plate);
                Program.log.Debug(plate+" Es mensual");
                if (vehicule != null) {
                    var currentHour = DateTime.Now.Hour;
                    int hourIn  = vehicule.autorizado2_ci == null || vehicule.autorizado2_ci== "" ? 0 : Int32.Parse(vehicule.autorizado2_ci);
                    int hourOut = vehicule.autorizado3_ci == null || vehicule.autorizado3_ci == "" ? 0 : Int32.Parse(vehicule.autorizado3_ci);
                    
                    if (!isWeekEnd() && !isHoliday() && !isOnTime(currentHour, hourIn, hourOut))
                    {
                        Program.log.Debug(plate + " Esta fuera de horario");
                        notify = true;
                    }
                }
                
            } else if (!isInPark(plate)) {
                Program.log.Debug(plate + " No esta en el parking");
                notify = true;
            }
            
            return notify;
        }

        private static bool isHoliday()
        {
            bool holiday = false;

            // Days
            int first = 1;
            int eighteenth = 18;
            int nineteenth = 19;
            int twentyfifth = 25;

            // Month
            int jan = 1;
            int may = 5;
            int jun = 6;
            int jul = 7;
            int agu = 8;
            int dec = 12;

            DateTime date = DateTime.Today;

            int day = date.Day;
            int month = date.Month;

            // 1-jan 1-may 18-may 19-jun 18-jul 25-agu 25-dec
            if ((day == first && month == jan) || (day == first && month == may) ||
                (day == eighteenth && month == may) || (day == nineteenth && month == jun) ||
                (day == eighteenth && month == jul) || (day == twentyfifth && month == agu) ||
                (day == twentyfifth && month == dec))
            {
                holiday = true;
            }

            return holiday;
        }

        // return true if it's saturday or sunday
        private static bool isWeekEnd()
        {

            bool week = false;

            int day = (int)DateTime.Now.DayOfWeek;
            if ((day == 6 || day == 0))
            {
                week = true;
            }

            return week;
        }

        internal static Boolean notifyOut(string plate) {

            Boolean notify = false;
            
            return notify;
        }


        private static bool isInPark(string plate) {

            Boolean isInPark =false;
            Program.log.Info("busca en tabla adentro");
            Adentro adentro = adeDao.getAdentro(plate);

            if (adentro != null) {

                isInPark = true;
            }

            return isInPark;
            
        }

        internal static bool getEquivalent(string dbPlate, string plate)
        {
            int diff = 0;
            int rest = 0;
            if (plate.Length == dbPlate.Length)
            {

                diff = getNumDiff(plate,dbPlate);
                
            } else if (dbPlate.Length< plate.Length)
            {
                rest = dbPlate.Length - plate.Length;
                if (rest <= 1)
                {
                    diff = getNumDiff(plate, dbPlate);
                    if (diff > 2)
                    {
                        diff = getNumDiff(plate.Substring(1), dbPlate);
                    }
                } else
                {
                    diff = rest;
                }
                
            } else
            {
                rest = plate.Length - dbPlate.Length;
                if (rest <= 1)
                {
                    diff = getNumDiff(dbPlate, plate);
                    if (diff > 2)
                    {
                        diff = getNumDiff(dbPlate.Substring(1), plate);
                    }
                }
                else
                {
                    diff = rest;
                }
            }
            Program.log.Debug("El diff devuelto es  " + diff);
            return (diff <= 1);
        }
        internal static int getNumDiff(string graterPlate, string minPlate)
        {
            Program.log.Debug("Comparando chapa 1 " + graterPlate + " y chapa 2 " + minPlate);
            int diff = 0;
            if((graterPlate.Length - minPlate.Length)>1)
            {
                diff = graterPlate.Length - minPlate.Length;
            } else
            {
                for (int i = 0; i < minPlate.Length; i++)
                {
                    if (graterPlate[i] != minPlate[i]) { diff++; }
                }
            }
            
            Program.log.Debug("La diferencia de caracteres es de " + diff);
            return diff;
        }


        private static bool isOnTime(int currentHour, int hourIn, int hourOut) {

            bool inTime = false;
            var currentMin = DateTime.Now.Minute;
            if (hourIn < hourOut) {
                inTime = ((currentHour >= hourIn && currentHour < hourOut) || (currentHour >= hourIn && currentHour == hourOut && (currentMin <= 10)));
            } else if (hourIn > hourOut) {
                inTime = ((currentHour >= hourIn || currentHour < hourOut) || (currentHour >= hourIn || currentHour == hourOut && (currentMin <= 10)));
            } else if (hourIn == hourOut) {
                inTime = true;
            }
            return inTime;
        }

        private static bool isPrePay(string plate)
        {
            return false;
        }

        private static bool isMensualPlate(string plate) {
            bool mensual = false;
            VehiculosRegistrado vehi = vehDao.getVehiculoMensual(plate);
            if (vehi != null) {
                mensual = true;
            }
            return mensual;
        }
        
    }


}
