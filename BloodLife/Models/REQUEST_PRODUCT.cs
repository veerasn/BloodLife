//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BloodLife.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class REQUEST_PRODUCT
    {
        public string ACCESSNUMBER { get; set; }
        public double REQCREATIONDATE { get; set; }
        public Nullable<byte> PSTATUS { get; set; }
        public Nullable<byte> MSTATUS { get; set; }
        public string PRODTYPE { get; set; }
        public Nullable<int> QUANTITY { get; set; }
        public string RESERVUID { get; set; }
        public Nullable<System.DateTime> RESERVDATE { get; set; }
        public string XMATCHUID { get; set; }
        public Nullable<System.DateTime> XMATCHDATE { get; set; }
        public string XMATCHRES { get; set; }
        public string ISSUEUID { get; set; }
        public Nullable<System.DateTime> ISSUEDATE { get; set; }
        public string RETURNUID { get; set; }
        public Nullable<System.DateTime> RETURNDATE { get; set; }
        public string RETURNFROM { get; set; }
        public string TRANSREACTION { get; set; }
        public string ABO { get; set; }
        public string RHFACTOR { get; set; }
        public string RHPHENO { get; set; }
        public string KELL { get; set; }
        public Nullable<int> SAMPLEID { get; set; }
        public string ISSUECOMMENT { get; set; }
        public string APPEARANCE { get; set; }
        public Nullable<byte> NOXMATCHREQUEST { get; set; }
        public string NOXMATCHREASON { get; set; }
        public Nullable<int> FRIDGEID { get; set; }
        public string RETURNCOMMENT { get; set; }
        public int PRODUCTID { get; set; }
        public byte[] SSMA_TimeStamp { get; set; }
    
        public virtual PRODUCT PRODUCT { get; set; }
        public virtual REQUEST REQUEST { get; set; }
    }
}
