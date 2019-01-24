using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;using System.Web.Mvc;
using BloodLife.Models;
using BloodLife.ViewModels;
using Newtonsoft.Json;


namespace BloodLife.Controllers
{
    public class mainsController : Controller
    {
        private BBSEntitiesNew db = new BBSEntitiesNew();
        private LMDLABEntities dl = new LMDLABEntities();

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

            BBSPATIENT Patient = db.PATIENTS.Find(id);

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
                    TestResult = test.RESULT
                }
                ).ToList();

            //Create array for populating results table
            int ireq = testrequests.Select(x => x.AccessNumber).Distinct().Count();
            ViewBag.TestCount = ireq;

            string abo = "", rh = "", reqvaliddate = "none";
            int aboerr = 0, rherr = 0, abserr = 0, abonum = 0, reqvalid = 0;

            if (ireq > 0)
            {
                int j = 0;
                string[,] res = new string[ireq, 8];
                string accnum = testrequests.First().AccessNumber;

                for (int i = 0; i < testrequests.Count(); i++)
                {
                    if (accnum != testrequests[i].AccessNumber)
                    {
                        j = j + 1;
                        accnum = testrequests[i].AccessNumber;
                    }

                    res[j, 0] = testrequests[i].AccessNumber;
                    res[j, 1] = testrequests[i].RequestDate.Value.ToString("HH:mm dd MMM yyyy");

                    switch (testrequests[i].TestCode)
                    {
                        case "RJ":
                            res[j, 2] = testrequests[i].TestResult;
                            break;
                        case "GROUP":
                        case "ABO":
                            res[j, 3] = testrequests[i].TestResult;
                            //Check for any abo discrepancies
                            if (abo == "" && testrequests[i].TestResult != null)
                            {
                                abo = testrequests[i].TestResult;
                                abonum = abonum + 1;
                            }
                            else
                            {
                                abonum = abonum + 1;
                            }
                            if (testrequests[i].TestResult != abo && testrequests[i].TestResult != null)
                            {
                                aboerr = 1;
                            }
                            //Check if any sample with ABO determination within last 3 days
                            if (testrequests[i].RequestDate != null && (DateTime.Today - testrequests[i].RequestDate).Value.Days < 180)
                            {
                                reqvalid = reqvalid + 1;
                                reqvaliddate = testrequests[i].RequestDate.ToString();
                            } 
                            break;
                        case "RH":
                            res[j, 4] = testrequests[i].TestResult;
                            //Check for any rh discrepancies
                            if (rh == "" && testrequests[i].TestResult != null)
                            {
                                rh = testrequests[i].TestResult;
                            }
                            if (testrequests[i].TestResult != rh && testrequests[i].TestResult != null)
                            {
                                rherr = 1;
                            }
                            break;
                        case "DAT":
                            res[j, 5] = testrequests[i].TestResult;
                            break;
                        case "ABS":
                            res[j, 6] = testrequests[i].TestResult;
                            //Check for any abs positives
                            if (testrequests[i].TestResult != null && testrequests[i].TestResult.Contains("POS"))
                            {
                                abserr = abserr + 1;
                            }
                            break;
                        case "ABID":
                            res[j, 7] = testrequests[i].TestResult;
                            break;
                    }
                }
                ViewData["TestResults"] = res;
                ViewBag.AboErr = aboerr; ViewBag.RhErr = rherr; ViewBag.AbsErr = abserr; ViewBag.Abonum = abonum;
                ViewBag.ReqValid = reqvalid; ViewBag.ReqValidDate = reqvaliddate;
            }

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
                    Prodnum = pr.PRODNUM,
                    Mstatus = rp.MSTATUS,
                    Pstatus = rp.PSTATUS,
                    Reservdate = rp.RESERVDATE,
                    Xmatchdate = rp.XMATCHDATE, 
                    Issuedate = rp.ISSUEDATE,
                    Returndate = rp.RETURNDATE, 
                    Transreaction = rp.TRANSREACTION

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
                    PRODNUM = x.Prodnum,
                    MSTATUS = x.Mstatus,
                    PSTATUS = x.Pstatus,
                    RESERVDATE = x.Reservdate,
                    XMATCHDATE = x.Xmatchdate,
                    ISSUEDATE = x.Issuedate,
                    RETURNDATE = x.Returndate, 
                    TRANSREACTION = x.Transreaction
                });

            if(prodrequests.Count(x => x.PRODNUM != null) > 0)
            {
                ViewBag.Rccount = prodrequests.Count(x => x.PRODNUM != null && x.PRODCODE.Substring(0,2)== "RC");
                ViewBag.Xm = prodrequests.Count(x => x.PRODNUM != null && x.PRODCODE.Substring(0, 2) == "RC" && x.MSTATUS == 2);

                ViewBag.Reserved = prodrequests.Count(x => x.PRODNUM != null && x.PRODCODE.Substring(0, 2) == "RC" && x.PSTATUS == 2);
                ViewBag.Issued = prodrequests.Count(x => x.PRODNUM != null && x.PRODCODE.Substring(0, 2) == "RC" && x.PSTATUS == 3);
                ViewBag.Transfused = prodrequests.Count(x => x.PRODNUM != null && x.PRODCODE.Substring(0, 2) == "RC" && x.PSTATUS == 4);
                ViewBag.Returned = prodrequests.Count(x => x.PRODNUM != null && x.PRODCODE.Substring(0, 2) == "RC" && x.PSTATUS == 6);
                ViewBag.Reaction = prodrequests.Count(x => x.PRODNUM != null && x.PRODCODE.Substring(0, 2) == "RC" && x.PSTATUS == 9);

                ViewBag.InReserve = prodrequests.Count(x => x.PRODNUM != null && x.PRODCODE.Substring(0, 2) == "RC" && x.PSTATUS == 2 && (DateTime.Today - x.XMATCHDATE).Value.Days < 3);

                ViewBag.Plcount = prodrequests.Count(x => x.PRODNUM != null && x.PRODCODE.Substring(0, 2) == "PL");
                ViewBag.PlIssued = prodrequests.Count(x => x.PRODNUM != null && x.PRODCODE.Substring(0, 2) == "PL" && x.PSTATUS == 3);
                ViewBag.PlTransfused = prodrequests.Count(x => x.PRODNUM != null && x.PRODCODE.Substring(0, 2) == "PL" && x.PSTATUS == 4);
                ViewBag.PlReturned = prodrequests.Count(x => x.PRODNUM != null && x.PRODCODE.Substring(0, 2) == "PL" && x.PSTATUS == 6);

                ViewBag.Fpcount = prodrequests.Count(x => x.PRODNUM != null && (x.PRODCODE.Substring(0, 2) == "FF"|| x.PRODCODE.Substring(0, 2) == "CR"));
                ViewBag.FpIssued = prodrequests.Count(x => x.PRODNUM != null && (x.PRODCODE.Substring(0, 2) == "FF" || x.PRODCODE.Substring(0, 2) == "CR") && x.PSTATUS == 3);
                ViewBag.FpTransfused = prodrequests.Count(x => x.PRODNUM != null && (x.PRODCODE.Substring(0, 2) == "FF" || x.PRODCODE.Substring(0, 2) == "CR") && x.PSTATUS == 4);
                ViewBag.FpReturned = prodrequests.Count(x => x.PRODNUM != null && (x.PRODCODE.Substring(0, 2) == "FF" || x.PRODCODE.Substring(0, 2) == "CR") && x.PSTATUS == 6);
            }
            else
            {
                ViewBag.Rccount = 0;
                ViewBag.Plcount = 0;
                ViewBag.Fpcount = 0;
            }
            

            ViewBag.Tcount = prodrequests.Count();

            //LMD results for chart
            var result = (
                    from tst in dl.TESTS
                    join rq in dl.REQUESTS
                    on tst.REQUESTID equals rq.REQUESTID
                    join pt in dl.PATIENTS
                    on rq.PATID equals pt.PATID
                    where pt.PATNUMBER == id && tst.TESTID == 2719 
                        && tst.RESVALUE !=null && rq.COLLECTIONDATE != null
                    orderby rq.COLLECTIONDATE descending
                    select new
                    {
                        Interval = DbFunctions.DiffDays(DateTime.Now, rq.COLLECTIONDATE),
                        Resvalue = tst.RESVALUE
                    }
                    ).ToList();

            int iRes = 0;
            iRes = result.Select(x => x.Resvalue).Count();
            ViewBag.iRes = iRes;

            if (iRes > 0)
            {
                double[] y = new double[iRes];
                string[] x = new string[iRes];
                double temp;
                for(int i = 0; i < iRes; i++)
                {
                    if (double.TryParse(result[i].Resvalue, out temp))
                    {
                        y[i] = temp;
                        x[i] = result[i].Interval.ToString();
                    }
                }

                ViewBag.xHb = x;
                ViewBag.yHb = y;
            }

            //Create table for choosing blood products
            BloodProductModel bloodProductModel = new BloodProductModel();
            ViewBag.bloodProducts = bloodProductModel.findAll();

            //Create dropdown for indications
            BloodProductModel IndicationModel = new BloodProductModel();
            ViewBag.Indications = new SelectList(IndicationModel.IndicationAll(), "Id", "Caption");

            //return View("Details",Patient);
            return View("Details", prodrequests);
        }
    
        //GET: mains/GetHb
        public ContentResult GetHb(string id)
        {
            using (var dl = new LMDLABEntities())
            {
                var result = (
                    from tst in dl.TESTS
                    join rq in dl.REQUESTS
                    on tst.REQUESTID equals rq.REQUESTID
                    join pt in dl.PATIENTS
                    on rq.PATID equals pt.PATID
                    where pt.PATNUMBER == id && tst.TESTID == 2719 && DbFunctions.DiffDays(rq.COLLECTIONDATE, DateTime.Now) < 365 
                    orderby rq.COLLECTIONDATE descending
                    select new
                    {
                        rq.COLLECTIONDATE,
                        tst.TESTID,
                        tst.RESVALUE,
                        tst.VALIDATIONSTATUS
                    }
                    ).ToList();
                return Content(JsonConvert.SerializeObject(result));
            }
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
        public ActionResult Create([Bind(Include = "PATNUMBER,PATCREATIONDATE,HOSPNUMBER,BENNUMBER,INTNUM,NAME,MAIDENNAME,FIRSTNAME,PATTITLE,BIRTHDATE,SEX,PATGROUP,ANTIBODIES,REQUIREMENTS,ADDRESS1,ADDRESS2,ADDRESS3,TELEPHON,REFDOCTOR,REFLOCATION,RECBYCNX,LINKNUMBER,LINKTYPE,ABO,RHFACTOR,RHPHENO,KELL,BGRPSTATUS,BGRPSTATUSDATE,BGRPSTATUSUID,ETHNICORIGIN,RELIGION,MOPATNUMBER,ANID,MANDATORYXMATCH,SAFETYMEASURES,BGRPSTATUSTMP,LOGUSERID,LOGDATE,ADDITIONALDATA,SSMA_TimeStamp")] BBSPATIENT pATIENT)
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
            BBSPATIENT pATIENT = db.PATIENTS.Find(id);
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
        public ActionResult Edit([Bind(Include = "PATNUMBER,PATCREATIONDATE,HOSPNUMBER,BENNUMBER,INTNUM,NAME,MAIDENNAME,FIRSTNAME,PATTITLE,BIRTHDATE,SEX,PATGROUP,ANTIBODIES,REQUIREMENTS,ADDRESS1,ADDRESS2,ADDRESS3,TELEPHON,REFDOCTOR,REFLOCATION,RECBYCNX,LINKNUMBER,LINKTYPE,ABO,RHFACTOR,RHPHENO,KELL,BGRPSTATUS,BGRPSTATUSDATE,BGRPSTATUSUID,ETHNICORIGIN,RELIGION,MOPATNUMBER,ANID,MANDATORYXMATCH,SAFETYMEASURES,BGRPSTATUSTMP,LOGUSERID,LOGDATE,ADDITIONALDATA,SSMA_TimeStamp")] BBSPATIENT pATIENT)
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
            BBSPATIENT pATIENT = db.PATIENTS.Find(id);
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
            BBSPATIENT pATIENT = db.PATIENTS.Find(id);
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

