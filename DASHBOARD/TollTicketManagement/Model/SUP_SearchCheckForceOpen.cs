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
    
    public partial class SUP_SearchCheckForceOpen
    {
        public System.Guid ID { get; set; }
        public string TableName { get; set; }
        public string CodeVehicle { get; set; }
        public string RecogPlate { get; set; }
        public Nullable<int> Price { get; set; }
        public string Counter { get; set; }
        public System.DateTime CheckDate { get; set; }
        public Nullable<int> LaneName { get; set; }
        public Nullable<int> ShiftName { get; set; }
        public Nullable<int> StationName { get; set; }
        public Nullable<int> TestEmp { get; set; }
        public Nullable<int> VehicleTypeID { get; set; }
        public int PriceOut { get; set; }
        public Nullable<int> ErrorID { get; set; }
        public string ImageID { get; set; }
        public Nullable<short> Precheck { get; set; }
        public Nullable<short> Presuper { get; set; }
        public Nullable<short> Super { get; set; }
        public Nullable<System.Guid> InCheckID { get; set; }
        public int EmployeeID { get; set; }
        public int Sequence { get; set; }
        public string RouteName { get; set; }
        public System.DateTime CloseDate { get; set; }
        public Nullable<int> Turn { get; set; }
    }
}
