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
    using System.Collections.Generic;
    
    public partial class LS_Route
    {
        public int RouteID { get; set; }
        public string RouteCode { get; set; }
        public string Name { get; set; }
        public int FromStationID { get; set; }
        public int ToStationID { get; set; }
        public Nullable<int> Length { get; set; }
        public string Note { get; set; }
        public Nullable<bool> IsMaxLength { get; set; }
        public bool IsUsed { get; set; }
    
        public virtual LS_Station LS_Station { get; set; }
        public virtual LS_Station LS_Station1 { get; set; }
    }
}
