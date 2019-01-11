using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodLife.Models
{
    public class CartItem
    {
        public BloodProduct BloodProduct { get; set; }
        public int Quantity { get; set; }
        public int Volume { get; set; }
        public string SecondProcess { get; set; }
    }
}