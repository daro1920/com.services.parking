namespace NotiFees
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            Adentroes = new HashSet<Adentro>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string str_nombre_usuario { get; set; }

        [Required]
        [StringLength(50)]
        public string str_password { get; set; }

        public int id_rol { get; set; }

        [StringLength(20)]
        public string nombre1 { get; set; }

        [StringLength(20)]
        public string nombre2 { get; set; }

        [StringLength(20)]
        public string apellido1 { get; set; }

        [StringLength(20)]
        public string apellido2 { get; set; }

        [StringLength(20)]
        public string ci { get; set; }

        [StringLength(8)]
        public string fecha_ingreso { get; set; }

        [StringLength(100)]
        public string direccion { get; set; }

        [StringLength(20)]
        public string telefono { get; set; }

        [StringLength(20)]
        public string celular { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? remuneracion_nominal { get; set; }

        public bool? permiso_principa { get; set; }

        public bool? permiso_es { get; set; }

        public bool? permiso_agregar_mov_caja { get; set; }

        public bool? permiso_nota_credito { get; set; }

        public bool? permiso_pensionistas { get; set; }

        public bool? permiso_cc { get; set; }

        public bool? permiso_agregar_mov_cc { get; set; }

        public bool? permiso_cobrar_pensiones { get; set; }

        public bool? permiso_emitir_facturacion_mensual { get; set; }

        public bool? permiso_parametricas { get; set; }

        public bool? permiso_usuarios { get; set; }

        public bool? permiso_configurador { get; set; }

        public bool? permiso_respaldo { get; set; }

        public bool? permiso_reportes { get; set; }

        public bool? permiso_estadisticas { get; set; }

        public bool? permiso_obligar_login_cierre_caja { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Adentro> Adentroes { get; set; }
    }
}
