//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PHASE_END_PROJECT_3.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CustLogInfo
    {
        public int LogId { get; set; }
        public string CustEmail { get; set; }
        public string CustName { get; set; }
        public string LogStatus { get; set; }
        public Nullable<int> UserId { get; set; }
        public string Description { get; set; }
    
        public virtual UserInfo UserInfo { get; set; }
    }
}
