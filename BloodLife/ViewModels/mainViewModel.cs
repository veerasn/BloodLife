using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BloodLife.Models;

namespace BloodLife.ViewModels
{
    public class MainViewModel
    {
        public PATIENT Patients { get; set; } 
        public REQUEST Requests { get; set; }
        public REQUEST_PRODUCT RequestProducts { get; set; }
    }
}