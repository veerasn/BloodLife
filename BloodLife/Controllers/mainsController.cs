using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;using System.Web.Mvc;
using BloodLife.Models;
using BloodLife.ViewModels;

namespace BloodLife.Controllers
{
    public class mainsController : Controller
    {
        private BBSEntitiesNew db = new BBSEntitiesNew();

        // GET: mains
        public ActionResult Index(string searchString)
        {
            var patients = from p in db.PATIENTS
                           select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                if(System.Text.RegularExpressions.Regex.IsMatch(searchString, "^[0-9 ]+$"))
                {
                    patients = patients.Where(p => p.PATNUMBER.Contains(searchString));
                }
                else
                {
                    patients = patients.Where(p => p.NAME.Contains(searchString));
                }   
            }

            else
            {
                patients = patients.Where(p => p.PATNUMBER.Contains("00777"));
            }

            return View(patients);
        }

        // GET: mains/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PATIENT Patient  = db.PATIENTS.Find(id);

            if (Patient == null)
            {
                return HttpNotFound();
            }

            //Test requests
            var testrequests = (
                from rq in db.REQUESTS
                join test in db.TESTS
                on rq.ACCESSNUMBER equals test.ACCESSNUMBER
                where rq.PATNUMBER == id
                orderby rq.REQDATE descending
                select new
                {
                    RequestDate = rq.REQDATE,
                    AccessNumber = rq.ACCESSNUMBER,
                    TestCode = test.TESTCODE,
                    TestResult = test.RESULT, 
                }
                ).ToList();

            ViewBag.TestCount = testrequests.Count();

            //Product requests

            var prodrequests = (

                from p in db.PATIENTS
                join r in db.REQUESTS on p.PATNUMBER equals r.PATNUMBER into List1
                from r in List1.DefaultIfEmpty()
                join rp in db.REQUEST_PRODUCT on r.ACCESSNUMBER equals rp.ACCESSNUMBER into List2
                from rp in List2.DefaultIfEmpty()
                join pr in db.PRODUCTS on rp.PRODUCTID equals pr.PRODUCTID into List3
                from pr in List3.DefaultIfEmpty()
                where p.PATNUMBER == id
                orderby r.REQDATE descending
                select new
                {
                    Patnumber = p.PATNUMBER,
                    PatName = p.NAME,
                    BirthDate = p.BIRTHDATE,
                    Sex = p.SEX,
                    Patgroup = p.PATGROUP,
                    Abo = p.ABO,
                    Rh = p.RHFACTOR,
                    Rhpheno = p.RHPHENO,
                    Ab = p.ANTIBODIES, 
                    Accessno = r.ACCESSNUMBER,
                    Reqdate = r.REQDATE,
                    Prodcode = pr.PRODCODE,
                    Prodnum = pr.PRODNUM

                }).ToList()

                .Select(x => new PatientProductViewModel()
                {
                    PATNUMBER = x.Patnumber,
                    NAME = x.PatName,
                    BIRTHDATE = x.BirthDate,
                    SEX = x.Sex,
                    PATGROUP = x.Patgroup,
                    ABO = x.Abo, 
                    RHFACTOR = x.Rh,
                    RHPHENO = x.Rhpheno,
                    ANTIBODIES = x.Ab,
                    ACCESSNUMBER = x.Accessno,
                    REQDATE = x.Reqdate,
                    PRODCODE = x.Prodcode,
                    PRODNUM = x.Prodnum
                    
                });

            ViewBag.Rccount = prodrequests.Count(x => x.PRODNUM != null && x.PRODCODE.Substring(0,2)== "RC");
            ViewBag.Plcount = prodrequests.Count(x => x.PRODNUM != null && x.PRODCODE.Substring(0, 2) == "PL");
            ViewBag.Fpcount = prodrequests.Count(x => x.PRODNUM != null && (x.PRODCODE.Substring(0, 2) == "FF"|| x.PRODCODE.Substring(0, 2) == "CR"));

            ViewBag.Tcount = prodrequests.Count();

            //Populate dropdown boxes
            #region ViewBag
            List<SelectListItem> rbcProducts = new List<SelectListItem>()
            {
                new SelectListItem {Text="Whole Blood (RCWB)    ", Value = "1"},
                new SelectListItem {Text="Red Cells in Additive Solution (RCSAG)    ", Value = "2"},
            };
            ViewBag.RbcProducts = rbcProducts;

            List<SelectListItem> unitQuantity = new List<SelectListItem>()
            {
                new SelectListItem {Text="1 unit", Value = "1"},
                new SelectListItem {Text="2 units", Value = "2"},
                new SelectListItem {Text="3 units", Value = "3"},
                new SelectListItem {Text="4 units", Value = "4"},
            };
            ViewBag.UnitQuantity = unitQuantity;

            List<SelectListItem> secondProcess = new List<SelectListItem>()
            {
                new SelectListItem {Text="No additional processing", Value = "0"},
                new SelectListItem {Text="Irradiated", Value = "1"},
                new SelectListItem {Text="Washed", Value = "2"},
            };
            ViewBag.SecondProcess = secondProcess;

            List<SelectListItem> rbcIndication = new List<SelectListItem>()
            {
                new SelectListItem {Text="Hb equals or below 70g/L in a haemodynamically stable ICU patient.", Value = "1"},
                new SelectListItem {Text="Hb equals or below 80g/L in a non-ICU patient with symptomatic anaemia.", Value = "2"},
                new SelectListItem {Text="Hb equals or below 100g/L in a patient experiencing cardiac ischaemia (angina pectoris, acute myocardial infacrction).", Value = "3"},
                new SelectListItem {Text="Acute bleeding with haemodynamic instability requiring urgent RBC transfusion", Value = "4"},
                new SelectListItem {Text="Pre-operative request and reservation for an elective or semi-elective scheduled procedure/surgical operation ", Value = "5"},
                new SelectListItem {Text="Others", Value = "6"},
            };
            ViewBag.RbcIndication = rbcIndication;
            #endregion

            //return View("Details",Patient);
            return View("Details", prodrequests);
        }
    

        // GET: PATIENTs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PATIENTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PATNUMBER,PATCREATIONDATE,HOSPNUMBER,BENNUMBER,INTNUM,NAME,MAIDENNAME,FIRSTNAME,PATTITLE,BIRTHDATE,SEX,PATGROUP,ANTIBODIES,REQUIREMENTS,ADDRESS1,ADDRESS2,ADDRESS3,TELEPHON,REFDOCTOR,REFLOCATION,RECBYCNX,LINKNUMBER,LINKTYPE,ABO,RHFACTOR,RHPHENO,KELL,BGRPSTATUS,BGRPSTATUSDATE,BGRPSTATUSUID,ETHNICORIGIN,RELIGION,MOPATNUMBER,ANID,MANDATORYXMATCH,SAFETYMEASURES,BGRPSTATUSTMP,LOGUSERID,LOGDATE,ADDITIONALDATA,SSMA_TimeStamp")] PATIENT pATIENT)
        {
            if (ModelState.IsValid)
            {
                db.PATIENTS.Add(pATIENT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pATIENT);
        }

        // GET: PATIENTs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PATIENT pATIENT = db.PATIENTS.Find(id);
            if (pATIENT == null)
            {
                return HttpNotFound();
            }
            return View(pATIENT);
        }

        // POST: PATIENTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PATNUMBER,PATCREATIONDATE,HOSPNUMBER,BENNUMBER,INTNUM,NAME,MAIDENNAME,FIRSTNAME,PATTITLE,BIRTHDATE,SEX,PATGROUP,ANTIBODIES,REQUIREMENTS,ADDRESS1,ADDRESS2,ADDRESS3,TELEPHON,REFDOCTOR,REFLOCATION,RECBYCNX,LINKNUMBER,LINKTYPE,ABO,RHFACTOR,RHPHENO,KELL,BGRPSTATUS,BGRPSTATUSDATE,BGRPSTATUSUID,ETHNICORIGIN,RELIGION,MOPATNUMBER,ANID,MANDATORYXMATCH,SAFETYMEASURES,BGRPSTATUSTMP,LOGUSERID,LOGDATE,ADDITIONALDATA,SSMA_TimeStamp")] PATIENT pATIENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pATIENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pATIENT);
        }

        // GET: PATIENTs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PATIENT pATIENT = db.PATIENTS.Find(id);
            if (pATIENT == null)
            {
                return HttpNotFound();
            }
            return View(pATIENT);
        }

        // POST: PATIENTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PATIENT pATIENT = db.PATIENTS.Find(id);
            db.PATIENTS.Remove(pATIENT);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // EVENTS:
        public ActionResult Events()
        {
            return View();
        }

    }

}

