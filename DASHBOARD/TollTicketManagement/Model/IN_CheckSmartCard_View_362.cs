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
    
    public partial class IN_CheckSmartCard_View_362
    {
        public System.Guid InCheckSmartCardID { get; set; }
        public string TransactionID { get; set; }
        public string SmartCardID { get; set; }
        public System.DateTime CheckDate { get; set; }
        public Nullable<int> TicketTypeID { get; set; }
        public Nullable<int> VehicleTypeID { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public Nullable<int> ShiftID { get; set; }
        public Nullable<int> LaneID { get; set; }
        public Nullable<int> StationID { get; set; }
        public string ImageID { get; set; }
        public string RecogPlateNumber { get; set; }
        public Nullable<short> RecogResultType { get; set; }
        public Nullable<short> TransactionStatus { get; set; }
        public Nullable<short> PrecheckStatus { get; set; }
        public Nullable<short> PreSupervisionStatus { get; set; }
        public Nullable<short> SupervisionStatus { get; set; }
        public Nullable<int> ErrorID { get; set; }
        public Nullable<System.Guid> WIMID { get; set; }
        public string Note { get; set; }
        public Nullable<bool> IsVehicleInfoManual { get; set; }
    }
}
