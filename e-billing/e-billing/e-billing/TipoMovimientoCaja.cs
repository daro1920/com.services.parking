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
    
    public partial class TipoMovimientoCaja
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoMovimientoCaja()
        {
            this.MovimientosCajas = new HashSet<MovimientosCaja>();
        }
    
        public int id { get; set; }
        public string str_codigo { get; set; }
        public string str_descrip { get; set; }
        public string str_tipo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MovimientosCaja> MovimientosCajas { get; set; }
    }
}
