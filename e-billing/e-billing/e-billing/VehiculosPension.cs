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
    
    public partial class VehiculosPension
    {
        public int id { get; set; }
        public Nullable<int> id_vehiculo_registrado { get; set; }
        public string str_lugar { get; set; }
        public string fecha_ingreso { get; set; }
        public decimal importe_convenido { get; set; }
        public string ultimo_mes_pago { get; set; }
        public Nullable<bool> inactivo { get; set; }
    
        public virtual VehiculosRegistrado VehiculosRegistrado { get; set; }
    }
}