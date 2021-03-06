//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TollTicketManagement.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class cts_supervision_rpt_RouteView
    {
        public System.Guid STT { get; set; }
        public string RouteName { get; set; }
        public string ObjectCode { get; set; }
        public System.DateTime OutCheckDate { get; set; }
        public System.DateTime InCheckDate { get; set; }
        public string VehicleName { get; set; }
        public Nullable<int> Price { get; set; }
        public string EmployeeName { get; set; }
        public string RecogPlateNumber { get; set; }
        public string InObjectCode { get; set; }
        public string StationIn { get; set; }
        public string LaneIn { get; set; }
        public string ShiftIn { get; set; }
        public string TicketTypeIn { get; set; }
        public string VehicleTypeNameIn { get; set; }
        public string RecogPlateNumberIn { get; set; }
        public Nullable<int> PriceIn { get; set; }
        public string ImageIn { get; set; }
        public string OutObjectCode { get; set; }
        public string StationOut { get; set; }
        public string LaneOut { get; set; }
        public string ShiftOut { get; set; }
        public string TicketTypeOut { get; set; }
        public string VehicleTypeNameOut { get; set; }
        public string RecogPlateNumberOut { get; set; }
        public Nullable<int> PriceOut { get; set; }
        public string ImageOut { get; set; }
        public Nullable<int> Distance { get; set; }
        public string RouteNote { get; set; }
        public Nullable<int> In_VehicleTypeID { get; set; }
        public Nullable<int> Out_VehicleTypeID { get; set; }
    }
}
