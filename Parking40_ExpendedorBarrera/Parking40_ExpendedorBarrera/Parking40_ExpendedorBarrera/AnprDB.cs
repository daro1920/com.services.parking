namespace Parking40_PlateReader
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AnprDB : DbContext
    {
        public AnprDB()
            : base("name=ANPRDB")
        {
        }

        public virtual DbSet<Result> Results { get; set; }
        public virtual DbSet<Incidence> Incidences { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Incidence>()
                .Property(e => e.SourcePath)
                .IsFixedLength();

            modelBuilder.Entity<Incidence>()
                .Property(e => e.ImagePath)
                .IsFixedLength();

            modelBuilder.Entity<Incidence>()
                .Property(e => e.Result_Send)
                .IsFixedLength();
        }
    }
}
