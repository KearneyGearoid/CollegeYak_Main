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
    
    public partial class VOTE
    {
        public decimal VOTE_ID { get; set; }
        public Nullable<decimal> POST_ID { get; set; }
        public string USERNAME_VOTER { get; set; }
        public string USERNAME_POSTER { get; set; }
        public string VOTE_TYPE { get; set; }
        public Nullable<System.DateTime> VOTE_DATE { get; set; }
    
        public virtual ALERT ALERT { get; set; }
        public virtual MEMBER MEMBER { get; set; }
        public virtual MEMBER MEMBER1 { get; set; }
        public virtual POST POST { get; set; }
    }
}
