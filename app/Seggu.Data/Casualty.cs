//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Seggu.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Casualty
    {
        public Casualty()
        {
            this.AttachedFiles = new HashSet<AttachedFile>();
        }
    
        public System.Guid Id { get; set; }
        public System.Guid PolicyId { get; set; }
        public short Number { get; set; }
        public System.Guid CasualtyTypeId { get; set; }
        public bool OurCharge { get; set; }
        public System.DateTime OccurredDate { get; set; }
        public System.DateTime ReceiveDate { get; set; }
        public Nullable<System.DateTime> PoliceReportDate { get; set; }
        public decimal EstimatedCompensation { get; set; }
        public decimal DefinedCompensation { get; set; }
        public string Notes { get; set; }
    
        public virtual CasualtyType CasualtyType { get; set; }
        public virtual Policy Policy { get; set; }
        public virtual ICollection<AttachedFile> AttachedFiles { get; set; }
    }
}