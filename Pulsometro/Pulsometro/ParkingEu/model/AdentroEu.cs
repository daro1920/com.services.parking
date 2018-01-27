namespace Pulsometro
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Adentro")]
    public partial class AdentroEu
    {
        public int id { get; set; }

        [Required]
        [StringLength(8)]
        public string str_fecha_entrada { get; set; }

        [Required]
        [StringLength(5)]
        public string str_hora_entrada { get; set; }

        [Required]
        [StringLength(20)]
        public string str_matricula { get; set; }

        public int? id_tipo_vehiculo { get; set; }

        [StringLength(20)]
        public string str_lugar { get; set; }

        [StringLength(20)]
        public string str_llave { get; set; }

        [StringLength(100)]
        public string str_observaciones { get; set; }

        public int id_convenio { get; set; }

        public int id_usuario { get; set; }

        [Required]
        [StringLength(2)]
        public string prepago { get; set; }

        [StringLength(8)]
        public string fecha_venc_prepago { get; set; }

        [StringLength(5)]
        public string hora_venc_prepago { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? importe_prepago { get; set; }

        public int? correlativo_ticket { get; set; }

        public bool? es_nocturno { get; set; }
    }
}
