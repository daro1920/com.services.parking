//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Parking40_ExpendedorBarrera
{
    using System;
    using System.Collections.Generic;
    
    public partial class RESULTS
    {
        public string NumberPlate { get; set; }
        public Nullable<double> GlobalConfidence { get; set; }
        public Nullable<double> AverageCharacterHeigth { get; set; }
        public Nullable<int> ProcessingTime { get; set; }
        public Nullable<int> PlateFormat { get; set; }
        public Nullable<int> Result_Left { get; set; }
        public Nullable<int> Result_Top { get; set; }
        public Nullable<int> Result_Right { get; set; }
        public Nullable<int> Result_Bottom { get; set; }
        public int INCIDENCEID { get; set; }
        public string OriginalNumberPlate { get; set; }
        public int ID { get; set; }
        public Nullable<System.DateTime> TimeStamp { get; set; }
        public int computerID { get; set; }
        public Nullable<int> DIRECTION_VECTOR { get; set; }
        public int Send_Server { get; set; }
        public System.DateTime Date_Send_Server { get; set; }
        public int nFrame { get; set; }
        public string aviFileName { get; set; }
        public Nullable<double> Speed { get; set; }
        public Nullable<double> SpeedConfidence { get; set; }
        public Nullable<int> IdLane { get; set; }
        public Nullable<int> VehicleClass { get; set; }
        public Nullable<double> VehicleClassConfidence { get; set; }
        public string VehicleMake { get; set; }
        public Nullable<double> VehicleMakeConfidence { get; set; }
        public Nullable<int> VehicleType { get; set; }
        public string VehicleColor { get; set; }
        public Nullable<double> VehicleColorConfidence { get; set; }
    }
}