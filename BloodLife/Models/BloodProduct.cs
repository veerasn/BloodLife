using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodLife.Models
{
    public class BloodProduct
    {
        public string Id { get; set;}
        public string Name { get; set; }
        public double Charge { get; set; }
        public int Leucodeplete { get; set; }
        public int Irradiate { get; set; }
        public int Upperage { get; set; }
        public int Lowerage { get; set; }
        public string Filelocation { get; set; }
        public string Comments { get; set; }
        public int Quantity { get; set; }
    }
}