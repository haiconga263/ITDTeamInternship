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
    
    public partial class SUP_RPT_VehicleTurn_Device
    {
        public string TableName { get; set; }
        public System.Guid ID { get; set; }
        public string MaThietBi { get; set; }
        public string LoaiThietBi { get; set; }
        public string KhachHang { get; set; }
        public Nullable<System.DateTime> NgayHieuLuc { get; set; }
        public Nullable<System.DateTime> NgayHetHan { get; set; }
        public System.DateTime CheckDate { get; set; }
        public Nullable<int> StationID { get; set; }
        public string StationName { get; set; }
        public Nullable<int> LaneID { get; set; }
        public string LaneName { get; set; }
        public Nullable<int> ShiftID { get; set; }
        public string ShiftName { get; set; }
        public Nullable<int> TicketTypeID { get; set; }
        public int MenhGia { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string SoXe { get; set; }
        public short SupervisionStatus { get; set; }
        public short PrecheckStatus { get; set; }
        public int ErrorID { get; set; }
        public string ErrorName { get; set; }
        public string ImageID { get; set; }
        public string StationCode { get; set; }
        public string ErrorNote { get; set; }
        public int Sequence { get; set; }
    }
}
