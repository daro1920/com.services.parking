namespace NotiFees
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

        public virtual DbSet<Notificaciones> Notificaciones { get; set; }
        public virtual DbSet<Adentro> Adentros { get; set; }
        public virtual DbSet<TipoDocumentoEmision_Correlativos> TipoDocumentoEmision_Correlativos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Notificaciones_errores> Notificaciones_errores { get; set; }
        public virtual DbSet<EstadoLlavero> EstadoLlavero { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder) {

            modelBuilder.Entity<Notificaciones>()
                .Property(e => e.str_matricula)
                .IsUnicode(false);

            modelBuilder.Entity<Notificaciones>()
                .Property(e => e.str_observaciones)
                .IsUnicode(false);
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

            modelBuilder.Entity<TipoDocumentoEmision_Correlativos>()
                .Property(e => e.str_codigo)
                .IsUnicode(false);

            modelBuilder.Entity<TipoDocumentoEmision_Correlativos>()
                .Property(e => e.str_descrip)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.str_nombre_usuario)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.str_password)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.nombre1)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.nombre2)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.apellido1)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.apellido2)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.ci)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.fecha_ingreso)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.celular)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.remuneracion_nominal)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Adentroes)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.id_usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Notificaciones_errores>()
                .Property(e => e.str_matricula)
                .IsUnicode(false);

            modelBuilder.Entity<Notificaciones_errores>()
                .Property(e => e.str_observaciones)
                .IsUnicode(false);

            modelBuilder.Entity<EstadoLlavero>()
                .Property(e => e.nro_llave)
                .IsUnicode(false);

            modelBuilder.Entity<EstadoLlavero>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<EstadoLlavero>()
                .Property(e => e.matricula)
                .IsUnicode(false);
        }
    }
}
