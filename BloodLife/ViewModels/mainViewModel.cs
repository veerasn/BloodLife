using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BloodLife.Models;

namespace BloodLife.ViewModels
{
    public class MainViewModel
    {
        public BBSPATIENT Patients { get; set; } 
        public BBSREQUEST Requests { get; set; }
        public REQUEST_PRODUCT RequestProducts { get; set; }
    }
}