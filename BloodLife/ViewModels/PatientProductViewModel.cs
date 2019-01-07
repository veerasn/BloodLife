﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BloodLife.Models;
using System.ComponentModel.DataAnnotations;

namespace BloodLife.ViewModels
{
    public class PatientProductViewModel
    {
        //Patient variables

        public string PATNUMBER { get; set; }
        public string PATNUMBERSHORT
        {
            get { return PATNUMBER != null ? PATNUMBER.Substring(12, 8) : ""; }
        }
        public string NAME { get; set; }
        [DisplayFormat(DataFormatString = "{0: dd MMM yyyy}")]
        public Nullable<System.DateTime> BIRTHDATE { get; set; }
        public Nullable<byte> SEX { get; set; }
        public string SEXLONG
        {
            get
            {
                switch (SEX)
                {
                    case 0:
                        { return SEX != null ? "Male" : ""; }
                    case 1:
                        { return SEX != null ? "Female" : ""; }
                    case 2:
                        { return SEX != null ? "Unknown" : ""; }
                    default:
                        { return SEX != null ? "Unknown" : ""; }
                }
            }
        }
        public string ANTIBODIES { get; set; }
        public string ABSHORT
        {
            get { return ANTIBODIES != null ? ANTIBODIES.Substring(0, 5) : ""; }
        }
        public string REQUIREMENTS { get; set; }
        public string REFDOCTOR { get; set; }
        public string REFLOCATION { get; set; }
        public string PATGROUP { get; set; }
        public string ABO { get; set; }
        public string RHFACTOR { get; set; }
        public string RHPHENO { get; set; }
        public Nullable<byte> BGRPSTATUS { get; set; }
        public Nullable<System.DateTime> BGRPSTATUSDATE { get; set; }
        public Nullable<byte> MANDATORYXMATCH { get; set; }
        public Nullable<byte> SAFETYMEASURES { get; set; }
        public Nullable<byte> BGRPSTATUSTMP { get; set; }

        //Request fields
        public string ACCESSNUMBER { get; set; }
        public string LOCCODE { get; set; }
        [DisplayFormat(DataFormatString = "{0: HH:mm dd MMM yyyy}")]
        public Nullable<System.DateTime> REQDATE { get; set; }
        [DisplayFormat(DataFormatString = "{0:hh\\:mm tt}")]
        public Nullable<System.DateTime> REQTIME { get; set; }
        public Nullable<byte> REQSTATUS { get; set; }
        public Nullable<System.DateTime> STATUSDATE { get; set; }
        public Nullable<System.DateTime> REQUIREDDATE { get; set; }
        public Nullable<byte> REQURGENT { get; set; }
        public Nullable<System.DateTime> BGMISMATCHDATE { get; set; }

        //Request_product
        public Nullable<byte> PSTATUS { get; set; }
        public Nullable<byte> MSTATUS { get; set; }
        public string PRODTYPE { get; set; }
        public Nullable<System.DateTime> RESERVDATE { get; set; }
        public Nullable<System.DateTime> XMATCHDATE { get; set; }
        public string XMATCHRES { get; set; }
        public Nullable<System.DateTime> ISSUEDATE { get; set; }
        public Nullable<System.DateTime> RETURNDATE { get; set; }
        public string RETURNFROM { get; set; }
        public string TRANSREACTION { get; set; }
        public int PRODUCTID { get; set; }

        //Product
        public string PRODNUM { get; set; }
        public string PRODCODE { get; set; }
    }
}