//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CollegeYak
{
    using System;
    using System.Collections.Generic;
    
    public partial class ALERT
    {
        public decimal ALERT_ID { get; set; }
        public string ALERT_TYPE { get; set; }
        public string ALERTED_USERNAME { get; set; }
        public Nullable<System.DateTime> ALERT_DATE { get; set; }
        public Nullable<decimal> POST_ID { get; set; }
    
        public virtual VOTE VOTE { get; set; }
        public virtual REPORT REPORT { get; set; }
        public virtual MEMBER MEMBER { get; set; }
        public virtual POST POST { get; set; }
        public virtual MEMBER MEMBER1 { get; set; }
    }
}
