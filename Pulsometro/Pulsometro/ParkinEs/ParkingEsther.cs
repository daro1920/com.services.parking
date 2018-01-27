namespace Pulsometro
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ParkingEsther : DbContext
    {
        public ParkingEsther()
            : base("name=ParkingEsther")
        {
        }

        public virtual DbSet<Adentro> Adentroes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adentro>()
                .Property(e => e.str_fecha_entrada)
                .IsUnicode(false);

            modelBuilder.Entity<Adentro>()
                .Property(e => e.str_hora_entrada)
                .IsUnicode(false);

            modelBuilder.Entity<Adentro>()
                .Property(e => e.str_matricula)
                .IsUnicode(false);

            modelBuilder.Entity<Adentro>()
                .Property(e => e.str_lugar)
                .IsUnicode(false);

            modelBuilder.Entity<Adentro>()
                .Property(e => e.str_llave)
                .IsUnicode(false);

            modelBuilder.Entity<Adentro>()
                .Property(e => e.str_observaciones)
                .IsUnicode(false);

            modelBuilder.Entity<Adentro>()
                .Property(e => e.prepago)
                .IsUnicode(false);

            modelBuilder.Entity<Adentro>()
                .Property(e => e.fecha_venc_prepago)
                .IsUnicode(false);

            modelBuilder.Entity<Adentro>()
                .Property(e => e.hora_venc_prepago)
                .IsUnicode(false);

            modelBuilder.Entity<Adentro>()
                .Property(e => e.importe_prepago)
                .HasPrecision(18, 0);
        }
    }
}
