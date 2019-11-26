namespace Parking40_PlateReader
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RESULTS")]
    public partial class Result
    {
        [StringLength(250)]
        public string NumberPlate { get; set; }

        public double? GlobalConfidence { get; set; }

        public double? AverageCharacterHeigth { get; set; }

        public int? ProcessingTime { get; set; }

        public int? PlateFormat { get; set; }

        public int? Result_Left { get; set; }

        public int? Result_Top { get; set; }

        public int? Result_Right { get; set; }

        public int? Result_Bottom { get; set; }

        public int INCIDENCEID { get; set; }

        [StringLength(250)]
        public string OriginalNumberPlate { get; set; }

        [Key]
        [Column(Order = 0)]
        public int ID { get; set; }

        public DateTime? TimeStamp { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int computerID { get; set; }

        public int? DIRECTION_VECTOR { get; set; }

        public int Send_Server { get; set; }

        public DateTime Date_Send_Server { get; set; }

        public int nFrame { get; set; }

        [StringLength(250)]
        public string aviFileName { get; set; }

        public double? Speed { get; set; }
    }
}
