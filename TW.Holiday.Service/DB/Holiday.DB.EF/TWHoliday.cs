//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Holiday.DB.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class TWHoliday
    {
        public long Id { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public bool IsHoliday { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
    }
}
