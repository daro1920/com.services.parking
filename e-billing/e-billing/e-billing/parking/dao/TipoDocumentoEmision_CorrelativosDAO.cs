using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_billing.parking.dao
{
    class TipoDocumentoEmision_CorrelativosDAO
    {

        public TipoDocumentoEmision_Correlativos SelectByStr_codigo(string v)
        {

            TipoDocumentoEmision_Correlativos tde_cor = new TipoDocumentoEmision_Correlativos();

            try
            {
                using (var context = new ParkingEntities2())
                {
                    tde_cor = (from tde in context.TipoDocumentoEmision_Correlativos where tde.str_codigo == v select tde).FirstOrDefault();

                }
            }
            catch (Exception ex)
            {
                Program.log.Error(DateTime.Now.ToString() +" TipoDocumento_emision SelectByStr_codigo " + ex);
            }
            return tde_cor;
        }

        public void updateByStr_codigo(TipoDocumentoEmision_Correlativos tdec)
        {


            try
            {
                using (var context = new ParkingEntities2())
                {

                    TipoDocumentoEmision_Correlativos tde_cor = (from tde in context.TipoDocumentoEmision_Correlativos where tde.str_codigo == tdec.str_codigo select tde).FirstOrDefault();
                    //context.TipoDocumentoEmision_Correlativos.Add(tdec);
                    tde_cor.int_correlativo_prox = tdec.int_correlativo_prox;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Program.log.Error(DateTime.Now.ToString()+" TipoDocumento_emision updateByStr_codigo " + ex);
            }
        }


    }
}
