namespace Parking40_PlateReader
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MovimientoParking")]
    public partial class MovimientoParking
    {
        public int id { get; set; }

        [Required]
        [StringLength(8)]
        public string str_fecha_entrada { get; set; }

        [Required]
        [StringLength(8)]
        public string str_fecha_salida { get; set; }

        [Required]
        [StringLength(5)]
        public string str_hora_entrada { get; set; }

        [Required]
        [StringLength(5)]
        public string str_hora_salida { get; set; }

        public int id_tipo_movimiento { get; set; }

        public int? id_tipo_vehiculo { get; set; }

        public int? id_cliente { get; set; }

        [Column(TypeName = "numeric")]
        public decimal dob_importe { get; set; }

        public int? id_vehiculo_registrado { get; set; }

        [StringLength(20)]
        public string str_matricula { get; set; }

        [StringLength(200)]
        public string str_observaciones { get; set; }

        public int? id_convenio { get; set; }

        public int? id_pension { get; set; }

        [StringLength(8)]
        public string str_desde_fecha_pension { get; set; }

        [StringLength(8)]
        public string str_hasta_fecha_pension { get; set; }

        public int? id_servicio { get; set; }

        public int id_usuario { get; set; }

        public int? id_movimiento_caja { get; set; }

        public int? creditos_generados { get; set; }

        public bool? creditos_usados { get; set; }
    }
}
