﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace e_billing
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ParkingEntities2 : DbContext
    {
        public ParkingEntities2()
            : base("name=ParkingEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Adentro> Adentroes { get; set; }
        public virtual DbSet<EstadoLlavero> EstadoLlaveroes { get; set; }
        public virtual DbSet<TipoVehiculo> TipoVehiculoes { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Tarifa> Tarifas { get; set; }
        public virtual DbSet<TipoDocumentoEmision_Correlativos> TipoDocumentoEmision_Correlativos { get; set; }
        public virtual DbSet<MovimientoParking> MovimientoParkings { get; set; }
        public virtual DbSet<MovimientosCaja> MovimientosCajas { get; set; }
        public virtual DbSet<VehiculosRegistrado> VehiculosRegistrados { get; set; }
    }
}
