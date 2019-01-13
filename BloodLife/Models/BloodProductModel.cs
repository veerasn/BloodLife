using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodLife.Models
{
    public class BloodProductModel
    {
        private List<BloodProduct> bloodproducts;

        public BloodProductModel()
        {
            this.bloodproducts = new List<BloodProduct>()
            {
                new BloodProduct{
                    Id = "RCWB",
                    Name = "Whole Blood",
                    Charge = 230,
                    Filelocation = "a",
                    Comments = ""
                },
                new BloodProduct{
                    Id = "RCSAG",
                    Name = "Red Cells in Additive Solution (SAGM)",
                    Charge = 230,
                    Filelocation = "a",
                    Comments = ""
                },
                new BloodProduct{
                    Id = "RCWB-ET",
                    Name = "Whole Blood for Exchange Transfusion",
                    Charge = 230,
                    Filelocation = "none",
                    Comments = ""
                },
                new BloodProduct{
                    Id = "PLTRD",
                    Name = "Platelets from random donors, unpooled",
                    Charge = 230,
                    Filelocation = "a",
                    Comments = ""
                },
                new BloodProduct{
                    Id = "PLTPL",
                    Name = "Platelets from random donors, pooled, leucodepleted",
                    Charge = 230,
                    Filelocation = "a"
                },
                new BloodProduct{
                    Id = "PLLR",
                    Name = "Apheresis Platelets from single donors, leucodepleted",
                    Charge = 230,
                    Filelocation = "a",
                    Comments = ""

                },
                new BloodProduct{
                    Id = "FFPRD",
                    Name = "Fresh Frozen Plasma",
                    Charge = 230,
                    Filelocation = "a",
                    Comments = ""
                },
                new BloodProduct{
                    Id = "CRYPP",
                    Name = "Cryoprecipitate",
                    Charge = 230,
                    Filelocation = "a",
                    Comments = ""
                },
                new BloodProduct{
                    Id = "CRYSP",
                    Name = "Cryosupernatant/ Cryo-poor Plasma",
                    Charge = 230,
                    Filelocation = "a",
                    Comments = ""
                }
            };
        }

        public List<BloodProduct> findAll()
        {
            return this.bloodproducts;
        }
    }
}