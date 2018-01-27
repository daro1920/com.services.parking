namespace Parking40_PlateReader
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ParkingDB : DbContext
    {
        public ParkingDB()
            : base("name=ParkingDB")
        {
        }

        public virtual DbSet<Adentro> Adentroes { get; set; }
        public virtual DbSet<MovimientoParking> MovimientoParkings { get; set; }
        public virtual DbSet<Procesado> Procesados { get; set; }
        public virtual DbSet<Notificacione> Notificaciones { get; set; }
        public virtual DbSet<VehiculosRegistrado> VehiculosRegistrados { get; set; }

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

            modelBuilder.Entity<MovimientoParking>()
                .Property(e => e.str_fecha_entrada)
                .IsUnicode(false);

            modelBuilder.Entity<MovimientoParking>()
                .Property(e => e.str_fecha_salida)
                .IsUnicode(false);

            modelBuilder.Entity<MovimientoParking>()
                .Property(e => e.str_hora_entrada)
                .IsUnicode(false);

            modelBuilder.Entity<MovimientoParking>()
                .Property(e => e.str_hora_salida)
                .IsUnicode(false);

            modelBuilder.Entity<MovimientoParking>()
                .Property(e => e.str_matricula)
                .IsUnicode(false);

            modelBuilder.Entity<MovimientoParking>()
                .Property(e => e.str_observaciones)
                .IsUnicode(false);

            modelBuilder.Entity<MovimientoParking>()
                .Property(e => e.str_desde_fecha_pension)
                .IsUnicode(false);

            modelBuilder.Entity<MovimientoParking>()
                .Property(e => e.str_hasta_fecha_pension)
                .IsUnicode(false);

            modelBuilder.Entity<Procesado>()
                .Property(e => e.str_observaciones)
                .IsUnicode(false);

            modelBuilder.Entity<Notificacione>()
                .Property(e => e.str_matricula)
                .IsUnicode(false);

            modelBuilder.Entity<Notificacione>()
                .Property(e => e.str_observaciones)
                .IsUnicode(false);

            modelBuilder.Entity<VehiculosRegistrado>()
                .Property(e => e.str_matricula)
                .IsUnicode(false);

            modelBuilder.Entity<VehiculosRegistrado>()
                .Property(e => e.str_marca_modelo)
                .IsUnicode(false);

            modelBuilder.Entity<VehiculosRegistrado>()
                .Property(e => e.nombre_cliente)
                .IsUnicode(false);

            modelBuilder.Entity<VehiculosRegistrado>()
                .Property(e => e.rut)
                .IsUnicode(false);

            modelBuilder.Entity<VehiculosRegistrado>()
                .Property(e => e.razon_social)
                .IsUnicode(false);

            modelBuilder.Entity<VehiculosRegistrado>()
                .Property(e => e.ci)
                .IsUnicode(false);

            modelBuilder.Entity<VehiculosRegistrado>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<VehiculosRegistrado>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<VehiculosRegistrado>()
                .Property(e => e.tel1)
                .IsUnicode(false);

            modelBuilder.Entity<VehiculosRegistrado>()
                .Property(e => e.tel2)
                .IsUnicode(false);

            modelBuilder.Entity<VehiculosRegistrado>()
                .Property(e => e.cel1)
                .IsUnicode(false);

            modelBuilder.Entity<VehiculosRegistrado>()
                .Property(e => e.cel2)
                .IsUnicode(false);

            modelBuilder.Entity<VehiculosRegistrado>()
                .Property(e => e.observaciones)
                .IsUnicode(false);

            modelBuilder.Entity<VehiculosRegistrado>()
                .Property(e => e.autorizado1_ci)
                .IsUnicode(false);

            modelBuilder.Entity<VehiculosRegistrado>()
                .Property(e => e.autorizado2_ci)
                .IsUnicode(false);

            modelBuilder.Entity<VehiculosRegistrado>()
                .Property(e => e.autorizado3_ci)
                .IsUnicode(false);

            modelBuilder.Entity<VehiculosRegistrado>()
                .Property(e => e.autorizado1_nombres)
                .IsUnicode(false);

            modelBuilder.Entity<VehiculosRegistrado>()
                .Property(e => e.autorizado2_nombres)
                .IsUnicode(false);

            modelBuilder.Entity<VehiculosRegistrado>()
                .Property(e => e.autorizado3_nombres)
                .IsUnicode(false);

            modelBuilder.Entity<VehiculosRegistrado>()
                .Property(e => e.autorizado1_apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<VehiculosRegistrado>()
                .Property(e => e.autorizado2_apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<VehiculosRegistrado>()
                .Property(e => e.autorizado3_apellidos)
                .IsUnicode(false);
        }
    }
}
