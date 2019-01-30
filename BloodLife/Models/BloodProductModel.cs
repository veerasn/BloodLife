using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodLife.Models
{
    public class BloodProductModel
    {
        private List<BloodProduct> bloodproducts;
        private List<Indication> indications;

        public BloodProductModel()
        {
            this.bloodproducts = new List<BloodProduct>()
            {
                new BloodProduct{
                    Id = "RCWB",
                    Name = "Whole Blood",
                    Charge = 230,
                    Leucodeplete = 0,
                    Irradiate = 0,
                    Upperage = 99999,
                    Lowerage = 0,
                    Filelocation = "a",
                    Comments = ""
                },
                new BloodProduct{
                    Id = "RCSAG",
                    Name = "Red Cells in Additive Solution (SAGM)",
                    Charge = 230,
                    Leucodeplete = 0,
                    Irradiate = 0,
                    Upperage = 99999,
                    Lowerage = 120,
                    Filelocation = "RCSAG.pdf",
                    Comments = ""
                },
                new BloodProduct{
                    Id = "RCSAG-LD",
                    Name = "Red Cells in Additive Solution (SAGM), Leucodepleted",
                    Charge = 230,
                    Leucodeplete = 1,
                    Irradiate = 0,
                    Upperage = 99999,
                    Lowerage = 120,
                    Filelocation = "a",
                    Comments = ""
                },
                new BloodProduct{
                    Id = "RCSAG-PP",
                    Name = "Pedi-pack for Neonatal Transfusion",
                    Charge = 230,
                    Leucodeplete = 1,
                    Irradiate = 0,
                    Upperage = 120,
                    Lowerage = 0,
                    Filelocation = "none",
                    Comments = ""
                },
                new BloodProduct{
                    Id = "RCWB-ET",
                    Name = "Red Cells for Exchange Transfusion, Leucodepleted, Irradiated",
                    Charge = 230,
                    Leucodeplete = 1,
                    Irradiate = 1,
                    Upperage = 30,
                    Lowerage = 0,
                    Filelocation = "none",
                    Comments = ""
                },
                new BloodProduct{
                    Id = "RCWB-LV",
                    Name = "Red Cells for Large Volume Neonatal Transfusion, Leucodepleted",
                    Charge = 230,
                    Leucodeplete = 1,
                    Irradiate = 0,
                    Upperage = 120,
                    Lowerage = 0,
                    Filelocation = "none",
                    Comments = ""
                },
                new BloodProduct{
                    Id = "PLTRD",
                    Name = "Platelet from Random Donors, Unpooled",
                    Charge = 230,
                    Leucodeplete = 0,
                    Irradiate = 0,
                    Upperage = 99999,
                    Lowerage = 0,
                    Filelocation = "a",
                    Comments = ""
                },
                new BloodProduct{
                    Id = "HLA-PLRD",
                    Name = "HLA-compatible Platelet from Random Donors, Unpooled",
                    Charge = 230,
                    Leucodeplete = 1,
                    Irradiate = 1,
                    Upperage = 99999,
                    Lowerage = 0,
                    Filelocation = "a",
                    Comments = ""
                },
                new BloodProduct{
                    Id = "PLTPL-LD",
                    Name = "Random Donor Platelet, Pooled, Leucodepleted",
                    Charge = 230,
                    Leucodeplete = 1,
                    Irradiate = 0,
                    Upperage = 99999,
                    Lowerage = 120,
                    Filelocation = "a"
                },
                new BloodProduct{
                    Id = "PLTLR",
                    Name = "Single Donor Apheresis Platelet, Leucodepleted",
                    Charge = 230,
                    Leucodeplete = 1,
                    Irradiate = 0,
                    Upperage = 99999,
                    Lowerage = 120,
                    Filelocation = "a",
                    Comments = ""
                },
                new BloodProduct{
                    Id = "HLA-PLLR",
                    Name = "HLA-compatible Single Donor Apheresis Platelet, Leucodepleted",
                    Charge = 230,
                    Leucodeplete = 1,
                    Irradiate = 1,
                    Upperage = 99999,
                    Lowerage = 120,
                    Filelocation = "a",
                    Comments = ""
                },
                new BloodProduct{
                    Id = "PLTLR-PP",
                    Name = "Pedi-pack, Single Donor Apheresis Platelet, Leucodepleted",
                    Charge = 230,
                    Leucodeplete = 1,
                    Irradiate = 0,
                    Upperage = 365,
                    Lowerage = 0,
                    Filelocation = "a",
                    Comments = ""
                },
                new BloodProduct{
                    Id = "HLA-PLLR-PP",
                    Name = "HLA-compatible Pedi-pack, Single Donor Apheresis Platelet, Leucodepleted",
                    Charge = 230,
                    Leucodeplete = 1,
                    Irradiate = 1,
                    Upperage = 365,
                    Lowerage = 0,
                    Filelocation = "a",
                    Comments = ""
                },
                new BloodProduct{
                    Id = "PPFFP",
                    Name = "Fresh Frozen Plasma, Random Donor",
                    Charge = 230,
                    Leucodeplete = 0,
                    Irradiate = 0,
                    Upperage = 99999,
                    Lowerage = 0,
                    Filelocation = "a",
                    Comments = ""
                },
                new BloodProduct{
                    Id = "PPCPT",
                    Name = "Cryoprecipitate, Random Donor, Unpooled",
                    Charge = 230,
                    Leucodeplete = 0,
                    Irradiate = 0,
                    Upperage = 99999,
                    Lowerage = 0,
                    Filelocation = "a",
                    Comments = ""
                },
                new BloodProduct{
                    Id = "PPCSP",
                    Name = "Cryo-poor Plasma,Random Donor, Unpooled",
                    Charge = 230,
                    Leucodeplete = 0,
                    Irradiate = 0,
                    Upperage = 99999,
                    Lowerage = 0,
                    Filelocation = "a",
                    Comments = ""
                },
                new BloodProduct{
                    Id = "RHD",
                    Name = "Anti-D Immunoglobulin (WinRho)",
                    Charge = 230,
                    Leucodeplete = 0,
                    Irradiate = 0,
                    Upperage = 99999,
                    Lowerage = 0,
                    Filelocation = "a",
                    Comments = ""
                },
                new BloodProduct{
                    Id = "PDCC3",
                    Name = "Prothrombin Complex Concentrate, 3-Factor (Prothrombinex)",
                    Charge = 230,
                    Leucodeplete = 0,
                    Irradiate = 0,
                    Upperage = 99999,
                    Lowerage = 0,
                    Filelocation = "a",
                    Comments = ""
                },
                new BloodProduct{
                    Id = "PDCC4",
                    Name = "Prothrombin Complex Concentrate, 4-Factor (Octaplex)",
                    Charge = 230,
                    Leucodeplete = 0,
                    Irradiate = 0,
                    Upperage = 99999,
                    Lowerage = 0,
                    Filelocation = "a",
                    Comments = ""
                },
                new BloodProduct{
                    Id = "PDF8",
                    Name = "Factor 8 Concentrate, Plasma-derived, Intermediate Purity",
                    Charge = 230,
                    Leucodeplete = 0,
                    Irradiate = 0,
                    Upperage = 99999,
                    Lowerage = 0,
                    Filelocation = "a",
                    Comments = ""
                },
                new BloodProduct{
                    Id = "PDF7a",
                    Name = "Recombinant Factor VIIa (NovoSeven)",
                    Charge = 230,
                    Leucodeplete = 0,
                    Irradiate = 0,
                    Upperage = 99999,
                    Lowerage = 0,
                    Filelocation = "a",
                    Comments = ""
                },
            };


            this.indications = new List<Indication>()
            {
                new Indication
                {
                    Id= 1001,
                    Caption = "Hb < 70g/L and/or Hct <22% in a hemodynamically stable ICU patient.",
                    Parameter = "Hb",
                    Level = 70
                },
                new Indication
                {
                    Id= 1002,
                    Caption = "Hb < 80g/L and/or Hct <24% in a non- ICU patient with symptomatic anaemia.",
                    Parameter = "Hb",
                    Level = 80
                },
                new Indication
                {
                    Id= 1003,
                    Caption = "Hb < 100g/L and/or Hct <30% in a patient experiencing acute ischaemiac cardiovascular disease (e.g. angina pectoris, acute myocardial infarction).",
                    Parameter = "Hb",
                    Level = 100
                },
                new Indication
                {
                    Id= 1004,
                    Caption = "Acute bleeding with hemodynamic instability requiring urgent RBC transfusion.",
                    Parameter = "Hb",
                    Level = 140
                },
                new Indication
                {
                    Id= 1009,
                    Caption = "Other",
                    Parameter = "Hb",
                    Level = 140
                },
                new Indication
                {
                    Id= 2001,
                    Caption = "Prophylactic transfusion to prevent spontaneous bleeding in a stable patient with platelet count <10 x 10^9/L",
                    Parameter = "Plt",
                    Level = 10
                },
                new Indication
                {
                    Id= 2002,
                    Caption = "Prophylactic transfusion to prevent spontaneous bleeding in patient with consumptive state (e.g. high fever, sepsis, DIC, splenomegaly) and platelet count <20 x 10^9/L",
                    Parameter = "Plt",
                    Level = 20
                },
                new Indication
                {
                    Id= 2003,
                    Caption = "Active bleeding or pre-procedure with platelet count <50 x 10^9/L",
                    Parameter = "Plt",
                    Level = 50
                },
                new Indication
                {
                    Id= 2004,
                    Caption = "Active bleeding or pre-procedure involving an enclosed space (e.g. intracranial, opthalmic) with platelet count <100 x 10^9/L",
                    Parameter = "Plt",
                    Level = 100
                },
                new Indication
                {
                    Id= 2005,
                    Caption = "Pre-procedure or bleeding patient who has taken a recent dose of anti-platelet medications, or with documented platelet dysfunction.",
                    Parameter = "Plt",
                    Level = 150
                },
                new Indication
                {
                    Id= 2006,
                    Caption = "Massive bleeding requiring multiple blood transfusions",
                    Parameter = "Plt",
                    Level = 150
                },
                new Indication
                {
                    Id= 2009,
                    Caption = "Other",
                    Parameter = "Plt",
                    Level = 150
                },
                new Indication
                {
                    Id= 3001,
                    Caption = "INR >1.6 and the patient is currently bleeding or pre-procedure and NOT a candidate for vitamin K",
                    Parameter = "INR",
                    Level = 1.6
                },
                new Indication
                {
                    Id= 3002,
                    Caption = "Massive bleeding requiring multiple RBC transfusion",
                    Parameter = "INR",
                    Level = 0.9
                },
                new Indication
                {
                    Id= 3003,
                    Caption = "Plasma required for therapeutic plasma exchange",
                    Parameter = "INR",
                    Level = 0.9
                },
                new Indication
                {
                    Id= 3004,
                    Caption = "Congenital deficiency of coagulation factor not routinely replaceable with factor concentrates (e.g. FXI)",
                    Parameter = "INR",
                    Level = 0.9
                },
                new Indication
                {
                    Id= 3009,
                    Caption = "Other",
                    Parameter = "INR",
                    Level = 0.9
                },
                new Indication
                {
                    Id= 4001,
                    Caption = "Fibrinogen < 1.5g/L and active bleeding or pre-procedure",
                    Parameter = "FBG",
                    Level = 1.5
                },
                new Indication
                {
                    Id= 4002,
                    Caption = "Congenital deficiency of von Willebrand Factor, Fibrinogen or FXIII",
                    Parameter = "FBG",
                    Level = 6
                },
                new Indication
                {
                    Id= 4009,
                    Caption = "Other",
                    Parameter = "FBG",
                    Level = 6
                },
                new Indication
                {
                    Id= 5001,
                    Caption = "Thrombotic thrombocytopenic purpara. Cryo-poor plasma required for therapeutic plasma exchange",
                    Parameter = "INR",
                    Level = 0.9
                },
                new Indication
                {
                    Id= 5009,
                    Caption = "Other",
                    Parameter = "INR",
                    Level = 0.9
                }
            };




        }

        public List<BloodProduct> findAll()
        {
            return this.bloodproducts;
        }

        public List<Indication> IndicationAll()
        {
            return this.indications;
        }
    }
}