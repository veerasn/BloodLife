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
    
    public partial class PRODUCT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCT()
        {
            this.REQUEST_PRODUCT = new HashSet<REQUEST_PRODUCT>();
        }
    
        public string PRODNUM { get; set; }
        public string PRODCODE { get; set; }
        public Nullable<double> PRODCREDATE { get; set; }
        public string PRODGROUP { get; set; }
        public string PRODTYPE { get; set; }
        public Nullable<byte> PSTATUS { get; set; }
        public Nullable<byte> MSTATUS { get; set; }
        public Nullable<System.DateTime> EXPDATE { get; set; }
        public string SCREENING { get; set; }
        public Nullable<int> QTEINIT { get; set; }
        public Nullable<int> QTEDISP { get; set; }
        public Nullable<int> NBRES { get; set; }
        public string INVOICENUMIN { get; set; }
        public Nullable<byte> INVOICETYPEIN { get; set; }
        public string INVOICENUMOUT { get; set; }
        public Nullable<byte> INVOICETYPEOUT { get; set; }
        public string PATNUMBER { get; set; }
        public string ABO { get; set; }
        public string RHFACTOR { get; set; }
        public string RHPHENO { get; set; }
        public string KELL { get; set; }
        public Nullable<System.DateTime> DATETRANS { get; set; }
        public string ENTEREDUID { get; set; }
        public Nullable<System.DateTime> ENTEREDDATE { get; set; }
        public string RETURNUID { get; set; }
        public Nullable<System.DateTime> RETURNDATE { get; set; }
        public Nullable<byte> EXCLUDETYPE { get; set; }
        public Nullable<int> FRIDGEID { get; set; }
        public Nullable<byte> INTENDEDUSE { get; set; }
        public string STRENGTH { get; set; }
        public Nullable<byte> FODREPORTPSTATUS { get; set; }
        public Nullable<System.DateTime> FODREPORTDATE { get; set; }
        public string REASONFORDELETION { get; set; }
        public Nullable<byte> PACKENTRYMODE { get; set; }
        public int PRODUCTID { get; set; }
        public Nullable<System.DateTime> LOGDATE { get; set; }
        public string LOGUSERID { get; set; }
        public Nullable<byte> REMOTEALLOCATION { get; set; }
        public byte[] SSMA_TimeStamp { get; set; }
    
        public virtual DICT_PRODUCTS DICT_PRODUCTS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REQUEST_PRODUCT> REQUEST_PRODUCT { get; set; }
    }
}
