namespace NotiFees
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Notificaciones
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string str_matricula { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime fecha { get; set; }

        [Key]
        [Column(Order = 3)]
        public int result_id { get; set; }

        [Key]
        [Column(Order = 4)]
        public int id_tipo_vehiculo { get; set; }

        [StringLength(100)]
        public string str_observaciones { get; set; }
    }
}
