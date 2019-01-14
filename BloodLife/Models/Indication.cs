using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodLife.Models
{
    public class Indication
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public string Parameter { get; set; }
        public double Level { get; set; }
    }
}