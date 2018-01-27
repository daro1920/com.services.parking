namespace Parking40_PlateReader
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Procesados")]
    public partial class Procesado
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int ultimo_procesado { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime fecha { get; set; }

        [StringLength(100)]
        public string str_observaciones { get; set; }
    }
}
