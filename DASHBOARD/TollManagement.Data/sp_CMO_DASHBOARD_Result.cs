//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TollManagement.Data
{
    using System;
    
    public partial class sp_CMO_DASHBOARD_Result
    {
        public string StationName { get; set; }
        public string LaneCode { get; set; }
        public Nullable<decimal> Vol { get; set; }
        public string StatusVol { get; set; }
        public Nullable<short> LaneStatus { get; set; }
        public Nullable<int> IsAlarm { get; set; }
        public bool IsUsed { get; set; }
        public Nullable<int> IsProblem { get; set; }
    }
}
