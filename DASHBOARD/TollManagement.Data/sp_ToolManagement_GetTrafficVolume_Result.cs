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
    
    public partial class sp_ToolManagement_GetTrafficVolume_Result
    {
        public Nullable<System.DateTime> REG_DATE { get; set; }
        public Nullable<System.DateTime> COLLECT_DATE { get; set; }
        public Nullable<int> Tollgate_ID { get; set; }
        public string Lane_ID { get; set; }
        public Nullable<long> VOLUME { get; set; }
    }
}
