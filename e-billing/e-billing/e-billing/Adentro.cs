//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace e_billing
{
    using System;
    using System.Collections.Generic;
    
    public partial class Adentro
    {
        public int id { get; set; }
        public string str_fecha_entrada { get; set; }
        public string str_hora_entrada { get; set; }
        public string str_matricula { get; set; }
        public Nullable<int> id_tipo_vehiculo { get; set; }
        public string str_lugar { get; set; }
        public string str_llave { get; set; }
        public string str_observaciones { get; set; }
        public int id_convenio { get; set; }
        public int id_usuario { get; set; }
        public string prepago { get; set; }
        public string fecha_venc_prepago { get; set; }
        public string hora_venc_prepago { get; set; }
        public Nullable<decimal> importe_prepago { get; set; }
        public Nullable<int> correlativo_ticket { get; set; }
        public Nullable<bool> es_nocturno { get; set; }
    
        public virtual Convenio Convenio { get; set; }
    }
}
