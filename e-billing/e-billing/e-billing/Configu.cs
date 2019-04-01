//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Configu
    {
        public string impresora_ticket { get; set; }
        public string impresora_factura { get; set; }
        public string impresora_factura_pension { get; set; }
        public string impresora_reportes { get; set; }
        public bool modificar_importe { get; set; }
        public int rollo_actual { get; set; }
        public string path_reader { get; set; }
        public Nullable<bool> permitir_modificar_importe { get; set; }
        public string nombre_parking { get; set; }
        public Nullable<bool> mostrar_columnas_full_adentro { get; set; }
        public Nullable<bool> mantenimiento_usuarios { get; set; }
        public Nullable<int> tamano_letra_adentro { get; set; }
        public Nullable<decimal> comision_general { get; set; }
        public Nullable<decimal> comision_diurnos { get; set; }
        public Nullable<decimal> comision_nocturnos { get; set; }
        public Nullable<decimal> comision_pensiones { get; set; }
        public string hora_comienzo_diurno { get; set; }
        public string hora_fin_diurno { get; set; }
        public Nullable<decimal> val_maximo_com_comun { get; set; }
        public Nullable<bool> no_mostrar_principa { get; set; }
        public Nullable<bool> usar_cc_para_pensionistas { get; set; }
        public string tipo_letra_standard { get; set; }
        public string tipo_letra_matriculas { get; set; }
        public string tipo_letra_nro_ticket { get; set; }
        public Nullable<bool> resaltar_prepagos_vencidos { get; set; }
        public Nullable<bool> mostrar_pensionistas_adentro { get; set; }
        public Nullable<bool> imprimir_cod_barras { get; set; }
        public Nullable<bool> imprimir_nro_ticket { get; set; }
        public Nullable<bool> permitir_acceso_barras_pensionistas { get; set; }
        public Nullable<bool> levantar_barreras_pensionistas { get; set; }
        public Nullable<bool> acumular_creditos_frecuente { get; set; }
        public Nullable<int> frecuente_cant_creditos { get; set; }
        public Nullable<int> frecuente_cada_cant_min { get; set; }
        public Nullable<bool> activar_grabacion_remota { get; set; }
        public Nullable<bool> backup_automatico { get; set; }
        public Nullable<int> backup_cada_dias { get; set; }
        public Nullable<bool> generar_pdf_facturas { get; set; }
        public Nullable<bool> generar_pdf_recibos { get; set; }
        public string path_respaldos { get; set; }
        public string path_recibos { get; set; }
        public string path_facturas { get; set; }
        public string path_exportacion_caja { get; set; }
        public string path_exportacion_pensionistas { get; set; }
        public string path_reportes_pdf { get; set; }
        public Nullable<bool> calcular_comisiones { get; set; }
        public Nullable<bool> generar_retiro_comision_cierre { get; set; }
        public Nullable<bool> login_al_cerrar_caja { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string mensaje_cabezal_ticket { get; set; }
        public string mensaje_pie_ticket { get; set; }
        public Nullable<int> plazas_totales { get; set; }
        public Nullable<int> plazas_pensionistas { get; set; }
        public string orden_inicial_adentro { get; set; }
        public string rut { get; set; }
        public string bps { get; set; }
        public string bse { get; set; }
        public string mtss { get; set; }
        public string planilla_mtss { get; set; }
        public string grupo_actividad { get; set; }
        public string subgrupo_actividad { get; set; }
        public string serie_estadisticas { get; set; }
        public string serie_sueldos { get; set; }
    }
}
