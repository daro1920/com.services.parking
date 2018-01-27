namespace NotiFees
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EstadoLlavero")]
    public partial class EstadoLlavero
    {
        public int id { get; set; }

        [StringLength(3)]
        public string nro_llave { get; set; }

        [StringLength(15)]
        public string estado { get; set; }

        public int? ticket { get; set; }

        [StringLength(10)]
        public string matricula { get; set; }
    }
}
