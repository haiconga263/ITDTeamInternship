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
    
    public partial class SUP_RPT_TicketCategory
    {
        public int TicketCategoryID { get; set; }
        public string TicketCategoryCode { get; set; }
        public string Name { get; set; }
        public Nullable<bool> IsPeriodTicket { get; set; }
        public Nullable<int> Duration { get; set; }
        public string Note { get; set; }
        public bool IsUsed { get; set; }
    }
}
