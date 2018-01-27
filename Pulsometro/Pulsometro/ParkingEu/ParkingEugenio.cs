namespace Pulsometro
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ParkingEugenio : DbContext
    {
        public ParkingEugenio()
            : base("name=ParkingEugenio")
        {
        }

        public virtual DbSet<Adentro> AdentroEU { get; set; }
        public virtual DbSet<TipoDocumentoEmision_Correlativos> TipoDocumentoEmision_Correlativos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           

            modelBuilder.Entity<TipoDocumentoEmision_Correlativos>()
                .Property(e => e.str_codigo)
                .IsUnicode(false);

            modelBuilder.Entity<TipoDocumentoEmision_Correlativos>()
                .Property(e => e.str_descrip)
                .IsUnicode(false);
        }
    }
}
