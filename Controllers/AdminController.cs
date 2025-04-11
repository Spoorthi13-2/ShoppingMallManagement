using ShoppingProjectA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingProjectA.Controllers
{
    
    public class AdminController : Controller
    {
        public string bc;
        private ShoppingContext sc;
        public AdminController()
        {
            sc = new ShoppingContext();
        }
        
        // GET: Admin
        public ActionResult AdminIndex(string name)
        {
            TempData["adminName"] = name;
            return View();
        }
        public ActionResult AdminIndex2()
        {
            
            string n = Convert.ToString(TempData["admin"]);
            TempData["adminName"] = n;
            return View("AdminIndex",new { name = TempData["adminName"]});
        }
        public ActionResult AddStore()
        {
            string n = Convert.ToString(TempData["admin"]);
            TempData["adminName"] = n;
            var getCategories = sc.businessCategories.ToList();
            SelectList list = new SelectList(getCategories, "Name", "Name");
            ViewData["BusinessCategories"] = list;
            return View();
        }
       [HttpPost]
       public ActionResult AddStore(StoreDetails store)
        {
            string n = Convert.ToString(TempData["admin"]);
            TempData["adminName"] = n;

            sc.storeDetails.Add(store);
                sc.SaveChanges();

            return RedirectToAction("AddStore");
        }
        public ActionResult Store(string storeNo)
        {
           
            string n = Convert.ToString(TempData["admin"]);
            TempData["adminName"] = n;
            return View(from sd in sc.storeDetails where sd.StoreNo == storeNo select sd);
        }
        public ActionResult StoreMin()
        {
            
            string n = Convert.ToString(TempData["admin"]);
            TempData["adminName"] = n;
            return View(from sd in sc.storeDetails select sd);
        }
        public ActionResult UpdateStoreDetails(string storeNo)
        {
            string n = Convert.ToString(TempData["admin"]);
            TempData["adminName"] = n;


            if (storeNo == null)
                {
                    return View("Error");
                }
                StoreDetails sd = sc.storeDetails.Find(storeNo);
            sd.BusinessCategory = bc;
                if (sd == null)
                {
                    return HttpNotFound();
                }
                var getCategories = sc.businessCategories.ToList();
                SelectList list = new SelectList(getCategories, "Name", "Name");
                ViewData["BusinessCategories"] = list;
            
            return View(sd);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateStoreDetails([Bind(Include = "StoreNo, StoreSize, StoreLocation, Area, OccupancyStatus, Type, Amount, ShopName, BusinessCategory, AgreementTenure")] StoreDetails sd)
        {
            string n = Convert.ToString(TempData["admin"]);
            TempData["adminName"] = n;

            if (ModelState.IsValid)
            {
                if(sd.BusinessCategory == "NA") { sd.BusinessCategory = "NA"; }
                if(sd.AgreementTenure == 0) { sd.AgreementTenure = 0; }
                sc.Entry(sd).State = EntityState.Modified;
                sc.SaveChanges();

            }
            var getCategories = sc.businessCategories.ToList();
            SelectList list = new SelectList(getCategories, "Name", "Name");
            ViewData["BusinessCategories"] = list;
            return RedirectToAction("StoreMin");
        }
        public ActionResult ViewRequestsMin()
        {
            string n = Convert.ToString(TempData["admin"]);
            TempData["adminName"] = n;
            
            return View(from r in sc.requestTables where r.Status == "Requested" select r);
        }
        public ActionResult ViewRequests()
        {
            string n = Convert.ToString(TempData["admin"]);
            TempData["adminName"] = n;
            return View(from r in sc.requestTables where r.Status == "Requested" select r);
        }
        public ActionResult ApproveReq(string name, string storeno)
        {
            string n = Convert.ToString(TempData["admin"]);
            TempData["adminName"] = n;

            var requs = (from r in sc.requestTables where r.StoreNo == storeno && r.ShopOwnerName == name select r.RequestId).FirstOrDefault();
            var requser = sc.requestTables.Find(requs);
            requser.Status = "Approved";
            sc.Entry(requser).State = EntityState.Modified;
            sc.SaveChanges();
            
            return RedirectToAction("ViewRequestsMin" );
        }
        public ActionResult RejectReq(string name, string storeno)
        {
            string n = Convert.ToString(TempData["admin"]);
            TempData["adminName"] = n;

            var requs = (from r in sc.requestTables where r.StoreNo == storeno && r.ShopOwnerName == name select r.RequestId).FirstOrDefault();
            var requser = sc.requestTables.Find(requs);
            sc.requestTables.Remove(requser);
            sc.SaveChanges();
            return RedirectToAction("ViewRequestsMin");
        }

       public ActionResult ViewFeedbacks()
        {
            string n = Convert.ToString(TempData["admin"]);
            TempData["adminName"] = n;

            return View(from s in sc.reviewTs where s.Status == "Submitted" select s);
        }
        public ActionResult HelpRequest()
        {
            string n = Convert.ToString(TempData["admin"]);
            TempData["adminName"] = n;

            return View(from s in sc.helps select s);
        }

        public ActionResult SaveRequest(int Id)
        {
            string n = Convert.ToString(TempData["admin"]);
            TempData["adminName"] = n;
            var save = sc.helps.Find(Id);
            save.Status = "Solved";
            sc.Entry(save).State = EntityState.Modified;
            sc.SaveChanges();

            return RedirectToAction("HelpRequest");
        }

        public ActionResult ReplyToTicket(Help help, int id)
        {
            string n = Convert.ToString(TempData["admin"]);
            TempData["adminName"] = n;

            var view = sc.helps.Where(s => s.RequestId == id).FirstOrDefault();
            view.Solution = help.Solution;
            string status = "Solved";
            view.Status = status;
            sc.SaveChanges();
            if (view.Solution != null)
            {
                return RedirectToAction("Replied");
            }


            return View();
        }
        public ActionResult Replied()
        {
            string n = Convert.ToString(TempData["admin"]);
            TempData["adminName"] = n;

            ViewBag.Msg = "You replied successfully";
            return View();
        }

        public ActionResult Reports()
        {
            string n = Convert.ToString(TempData["admin"]);
            TempData["adminName"] = n;

            ReportsVM reportsvm = new ReportsVM();

            var storedetailsocc = sc.storeDetails.Where(m => m.OccupancyStatus == "Occupied").ToList();
            reportsvm.storeDetailsOcc = storedetailsocc;

            var storedetailsvac = sc.storeDetails.Where(m => m.OccupancyStatus != "Occupied").ToList();
            reportsvm.storeDetailsVac = storedetailsvac;

            return View(reportsvm);
        }

    }
}