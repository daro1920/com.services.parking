namespace Pulsometro
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TipoDocumentoEmision_Correlativos
    {
        public int id { get; set; }

        [Required]
        [StringLength(5)]
        public string str_codigo { get; set; }

        [Required]
        [StringLength(50)]
        public string str_descrip { get; set; }

        public int int_correlativo_prox { get; set; }
    }
}
