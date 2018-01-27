namespace Parking40_PlateReader
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VehiculosRegistrados")]
    public partial class VehiculosRegistrado
    {
        public int id { get; set; }

        public int id_modelo { get; set; }

        public int? id_cliente { get; set; }

        [Required]
        [StringLength(50)]
        public string str_matricula { get; set; }

        [StringLength(50)]
        public string str_marca_modelo { get; set; }

        [StringLength(100)]
        public string nombre_cliente { get; set; }

        [StringLength(30)]
        public string rut { get; set; }

        [StringLength(50)]
        public string razon_social { get; set; }

        [StringLength(20)]
        public string ci { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(100)]
        public string direccion { get; set; }

        [StringLength(20)]
        public string tel1 { get; set; }

        [StringLength(20)]
        public string tel2 { get; set; }

        [StringLength(20)]
        public string cel1 { get; set; }

        [StringLength(20)]
        public string cel2 { get; set; }

        [StringLength(200)]
        public string observaciones { get; set; }

        [StringLength(20)]
        public string autorizado1_ci { get; set; }

        [StringLength(20)]
        public string autorizado2_ci { get; set; }

        [StringLength(20)]
        public string autorizado3_ci { get; set; }

        [StringLength(50)]
        public string autorizado1_nombres { get; set; }

        [StringLength(50)]
        public string autorizado2_nombres { get; set; }

        [StringLength(50)]
        public string autorizado3_nombres { get; set; }

        [StringLength(50)]
        public string autorizado1_apellidos { get; set; }

        [StringLength(50)]
        public string autorizado2_apellidos { get; set; }

        [StringLength(50)]
        public string autorizado3_apellidos { get; set; }
    }
}
