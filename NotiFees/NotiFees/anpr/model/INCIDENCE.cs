namespace NotiFees
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("INCIDENCE")]
    public partial class Incidence
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int? LOCATIONID { get; set; }

        public DateTime? Date { get; set; }

        [StringLength(255)]
        public string SourcePath { get; set; }

        [StringLength(255)]
        public string ImagePath { get; set; }

        public int? Recognition_Left { get; set; }

        public int? Recognition_Top { get; set; }

        public int? Recognition_Width { get; set; }

        public int? Recognition_Height { get; set; }

        public int? NumSteps { get; set; }

        public int? MinStep { get; set; }

        public int? MaxStep { get; set; }

        public double? DistanceCoeff { get; set; }

        public double? HorizontalCoeff { get; set; }

        public double? VerticalCoeff { get; set; }

        public double? AngleCoeff { get; set; }

        public int? CharacterSize { get; set; }

        public int? OperatorID { get; set; }

        public double? GpsLatitude { get; set; }

        public double? GpsLongitude { get; set; }

        public int? ApplyCorrection { get; set; }

        public int? STATUSID { get; set; }

        public int? TYPEINCIDENCEID { get; set; }

        public int? Sent { get; set; }

        public DateTime? TimeStamp { get; set; }

        [StringLength(50)]
        public string Class { get; set; }

        [StringLength(50)]
        public string Brand { get; set; }

        [StringLength(50)]
        public string Color { get; set; }

        [StringLength(50)]
        public string Cause_N_Notification { get; set; }

        public int? NName { get; set; }

        [StringLength(50)]
        public string Agent { get; set; }

        [StringLength(50)]
        public string Precept { get; set; }

        public double? IMP_REDUCED { get; set; }

        public double? IMP_NOT_REDUCED { get; set; }

        public int Export { get; set; }

        public int ExportImages { get; set; }

        [Required]
        [StringLength(50)]
        public string IDGestPol { get; set; }

        public DateTime? DateValidation { get; set; }

        public int camera_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int computerID { get; set; }

        [StringLength(1)]
        public string Result_Send { get; set; }

        public int Send_Server { get; set; }

        public DateTime Date_Send_Server { get; set; }
    }
}
