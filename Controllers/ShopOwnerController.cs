using ShoppingProjectA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingProjectA.Controllers
{
    public class ShopOwnerController : Controller
    {
        
        
        public int rid;
        public int sid;
        public string sno;
        private ShoppingContext sc;
        public ShopOwnerController()
        {
            sc = new ShoppingContext();
        }
        // GET: ShopOwner
        public ActionResult ShopOwnerIndex(int Id)
        {
            Shop shop = sc.shops.Find(Id);
            TempData["shopOwnerName"] = shop.ShopOwnerName;

            TempData["shopOwnerUserId"] = shop.UserId;
            Session["sId"] = Id;

            sid = Id;
            
            return View();
        }
        public ActionResult ShopOwnerIndex2()
        {
            string n = Convert.ToString(TempData["shopOwner"]);
            TempData["shopOwnerName"] = n;
            string u = Convert.ToString(TempData["userId"]);
            TempData["shopOwnerUserId"] = u;
            Session["si"] = Session["SID"];

            return RedirectToAction("ShopOwnerIndex", new { Id = (int) Session["SID"] });
        }
        public ActionResult CreateProfile()
        {
            
            var getCategories = sc.businessCategories.ToList();
            SelectList list = new SelectList(getCategories, "Name", "Name");
            ViewData["BusinessCategories"] = list;
            
            string ui = (string)Session["userid"];
            var reg = sc.Registrations.Where(m => m.UserId == ui).FirstOrDefault();
            ViewBag.Name = reg.FirstName;
            ViewBag.ContactNumber = reg.ContactNumber;
            ViewBag.Email = reg.Email;
            ViewBag.UserId = reg.UserId;
            TempData["shopOwnerName"] = reg.FirstName;

            return View();
        }
        [HttpPost]
        public ActionResult CreateProfile(Shop shop)
        {
            sc.shops.Add(shop);
            sc.SaveChanges();
            return RedirectToAction("LoginIndex","Login");
        }

        public ActionResult EditProfile()
        {
            string n = Convert.ToString(TempData["shopOwner"]);
            TempData["shopOwnerName"] = n;
            Session["si"] = Session["SID"];
            return RedirectToAction("Edit", new { id = (int)Session["si"] });
        }
       public ActionResult Edit(int? Id)
        {
            string n = Convert.ToString(TempData["shopOwner"]);
            TempData["shopOwnerName"] = n;
            string u = Convert.ToString(TempData["userId"]);
            TempData["shopOwnerUserId"] = u;
            int rrid = Convert.ToInt32(TempData["RID"]);
            TempData["rId"] = rrid;
            Session["si"] = Session["SID"];

            if (Id == null)
            {
                return View("Error");
            }
            Shop shop = sc.shops.Find(Id);
            if (shop == null)
            {
                return HttpNotFound();
            }
            var getCategories = sc.businessCategories.ToList();
            SelectList list = new SelectList(getCategories, "Name", "Name", shop.BusinessCategory);
            ViewData["BusinessCategories"] = list;

            return View(shop);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ShopName, BusinessCategory, NoOfEmployees, WrkngHrs, Holiday, LicenseNo, LicenseExp, ShopOwnerName, ContactNumber,Email,UserId")] Shop shop)
        {
            string n = Convert.ToString(TempData["shopOwner"]);
            TempData["shopOwnerName"] = n;
            string u = Convert.ToString(TempData["userId"]);
            TempData["shopOwnerUserId"] = u;
            int rrid = Convert.ToInt32(TempData["RID"]);
            TempData["rId"] = rrid;
            Session["si"] = Session["SID"];

            
            if (ModelState.IsValid)
            {
                sc.Entry(shop).State = EntityState.Modified;
                sc.SaveChanges();
                return View("ShowData", shop);
            }
            var getCategories = sc.businessCategories.ToList();
            SelectList list = new SelectList(getCategories, "Name", "Name", shop.BusinessCategory);
            ViewData["BusinessCategories"] = list;
            return View("ShowData",shop);
        }
        public ActionResult ShowData(int id)
        {
            Session["si"] = Session["SID"];
            Shop shop = sc.shops.Find(id);
            return View(shop);
        }

        public ActionResult FilterListShopOwner()
        {
            string n = Convert.ToString(TempData["shopOwner"]);
            TempData["shopOwnerName"] = n;
            string u = Convert.ToString(TempData["userId"]);
            TempData["shopOwnerUserId"] = u;
            int rrid = Convert.ToInt32(TempData["RID"]);
            TempData["rId"] = rrid;
            Session["si"] = Session["SID"];

            return View();
        }
        [HttpPost]
        public ActionResult FilterListShopOwner(FilterList filter)
        {
            
            sc.filterLists.Add(filter);
            sc.SaveChanges();
            TempData["occ"] = filter.Occupancy;
            TempData["typ"] = filter.Type;
            TempData["loc"] = filter.Location;
            return RedirectToAction("DisplayStoreMin");
        }
        public ActionResult DisplayStoreMin()
        {
            string n = Convert.ToString(TempData["shopOwner"]);
            TempData["shopOwnerName"] = n;
            string u = Convert.ToString(TempData["userId"]);
            TempData["shopOwnerUserId"] = u;
            int rrid = Convert.ToInt32(TempData["RID"]);
            TempData["rId"] = rrid;
            Session["si"] = Session["SID"];

            string occ = (string)TempData["occ"];
            string typ = (string)TempData["typ"];
            string loc = (string)TempData["loc"];
            if (occ != null && typ != null && loc != null)
            {
                return View(from s in sc.storeDetails where s.OccupancyStatus == occ && s.Type == typ && s.StoreLocation == loc select s);
            }
            else
            {
                return View(from s in sc.storeDetails select s);
            }
        }
        public ActionResult DisplayStore()
        {
            string n = Convert.ToString(TempData["shopOwner"]);
            TempData["shopOwnerName"] = n;
            string u = Convert.ToString(TempData["userId"]);
            TempData["shopOwnerUserId"] = u;
            int rrid = Convert.ToInt32(TempData["RID"]);
            TempData["rId"] = rrid;
            Session["si"] = Session["SID"];

            
            return View(from s in sc.storeDetails select s);
        }
        public ActionResult RaiseRequest(string storen)
        {

            string n = Convert.ToString(TempData["shopOwner"]);
            TempData["shopOwnerName"] = n;
            string u = Convert.ToString(TempData["userId"]);
            TempData["shopOwnerUserId"] = u;
            int rrid = Convert.ToInt32(TempData["RID"]);
            TempData["rId"] = rrid;
            Session["si"] = Session["SID"];
            
            var store = (from s in sc.storeDetails
                         where s.StoreNo == storen
                         select s).ToList();
            var req = sc.requestTables.Where(m => m.StoreNo == storen && m.ShopOwnerName == n).FirstOrDefault();
            StoreReqVM viewmodel = new StoreReqVM();
            if(req == null)
            {
                Session["strno"] = storen;
                TempData["status"] = "Request";
            }
            else if(req.Status == "Approved" && req.StoreNo == storen && req.ShopOwnerName == n)
            {
                TempData["status"] = "Approved";
                Session["strno"] = storen;
            }
            viewmodel.storeDetails = store;
            viewmodel.requestTable = req;
            return View(viewmodel);
        }
        public ActionResult RaiseRequestForStore(string storeno)
        {
            Session["strno"] = storeno;
            string n = Convert.ToString(TempData["shopOwner"]);
            TempData["shopOwnerName"] = n;
            string u = Convert.ToString(TempData["userId"]);
            TempData["shopOwnerUserId"] = u;
            int rrid = Convert.ToInt32(TempData["RID"]);
            TempData["rId"] = rrid;
            Session["si"] = Session["SID"];

            var store = sc.storeDetails.Find(storeno);
            var shop = sc.shops.Find((int)Session["si"]);
            ViewBag.storeno = store.StoreNo;
            ViewBag.storeloc = store.StoreLocation;
            ViewBag.type = store.Type;
            ViewBag.shopownername = shop.ShopOwnerName;
            ViewBag.contactnumber = shop.ContactNumber;
            ViewBag.business = shop.BusinessCategory;
            return View();
        }
        [HttpPost]
        public ActionResult RaiseRequestForStore(RequestTable request)
        {
            Session["strno"] = request.StoreNo;
            string n = Convert.ToString(TempData["shopOwner"]);
            TempData["shopOwnerName"] = n;
            string u = Convert.ToString(TempData["userId"]);
            TempData["shopOwnerUserId"] = u;
            int rrid = Convert.ToInt32(TempData["RID"]);
            TempData["rId"] = rrid;
            Session["si"] = Session["SID"];

            request.Status = "Requested";
            sc.requestTables.Add(request);
            sc.SaveChanges();
            return RedirectToAction("RaiseRequest", "ShopOwner", new {storen = request.StoreNo });
        }

        public ActionResult ShopOwnerRequestMin(string name)
        {
            string n = Convert.ToString(TempData["shopOwner"]);
            TempData["shopOwnerName"] = n;
            string u = Convert.ToString(TempData["userId"]);
            TempData["shopOwnerUserId"] = u;
            int rrid = Convert.ToInt32(TempData["RID"]);
            TempData["rId"] = rrid;
            Session["si"] = Session["SID"];

            return View(from r in sc.requestTables where r.ShopOwnerName == name select r );
        }
        public ActionResult ShopOwnerRequest(int Id)
        {
            string n = Convert.ToString(TempData["shopOwner"]);
            TempData["shopOwnerName"] = n;
            string u = Convert.ToString(TempData["userId"]);
            TempData["shopOwnerUserId"] = u;
            int rrid = Convert.ToInt32(TempData["RID"]);
            TempData["rId"] = rrid;
            Session["si"] = Session["SID"];

            return View(from r in sc.requestTables where r.RequestId == Id select r);
        }

        public ActionResult ReviewForm()
        {
            string n = Convert.ToString(TempData["shopOwner"]);
            TempData["shopOwnerName"] = n;
            string u = Convert.ToString(TempData["userId"]);
            TempData["shopOwnerUserId"] = u;
            int rrid = Convert.ToInt32(TempData["RID"]);
            TempData["rId"] = rrid;
            Session["si"] = Session["SID"];

            string user = (string)Session["userid"];

            var present = sc.reviewTs.Where(m => m.UserId == user).FirstOrDefault();
            if (present != null)
            {
                return RedirectToAction("LogOut", "Login");
            }
            else
            {
                return RedirectToAction("CreateReview", new { userId = user });
            }
        }

        public ActionResult CreateReview(string userId)
        {
            string n = Convert.ToString(TempData["shopOwner"]);
            TempData["shopOwnerName"] = n;
            string u = Convert.ToString(TempData["userId"]);
            TempData["shopOwnerUserId"] = userId;
            int rrid = Convert.ToInt32(TempData["RID"]);
            TempData["rId"] = rrid;
            Session["si"] = Session["SID"];
            if (userId == null)
            {
                ViewBag.userid = u;
            }
            else
            {
                ViewBag.userid = userId;
            }
            
            return View();
        }
        [HttpPost]
        public ActionResult CreateReview(ReviewT review)
        {
            review.Status = "Submitted";
            sc.reviewTs.Add(review);
            sc.SaveChanges();

            return RedirectToAction("LogOut", "Login");
        }

        public ActionResult Help()
        {
            string n = Convert.ToString(TempData["shopOwner"]);
            TempData["shopOwnerName"] = n;
            string u = Convert.ToString(TempData["userId"]);
            TempData["shopOwnerUserId"] = u;
            int rrid = Convert.ToInt32(TempData["RID"]);
            TempData["rId"] = rrid;
            Session["si"] = Session["SID"];
            string user = (string)Session["userid"];

            List<SelectListItem> issue = new List<SelectListItem>();

            issue.Add(new SelectListItem { Text = "Issue1", Value = "Issue1" });

            issue.Add(new SelectListItem { Text = "Issue2", Value = "Issue2" });

            issue.Add(new SelectListItem { Text = "Issue3", Value = "Issue3" });

            issue.Add(new SelectListItem { Text = "Issue4", Value = "Issue4" });

            issue.Add(new SelectListItem { Text = "Others", Value = "Others" });

            ViewData["Issue"] = issue;
            ViewBag.userid = u;
            return View();
        }
        [HttpPost]
        public ActionResult Help(Help help)
        {
            string n = Convert.ToString(TempData["shopOwner"]);
            TempData["shopOwnerName"] = n;
            string u = Convert.ToString(TempData["userId"]);
            TempData["shopOwnerUserId"] = u;
            int rrid = Convert.ToInt32(TempData["RID"]);
            TempData["rId"] = rrid;
            Session["si"] = Session["SID"];
            string user = (string)Session["userid"];
            List<SelectListItem> issue = new List<SelectListItem>();

            issue.Add(new SelectListItem { Text = "Issue1", Value = "Issue1" });

            issue.Add(new SelectListItem { Text = "Issue2", Value = "Issue2" });

            issue.Add(new SelectListItem { Text = "Issue3", Value = "Issue3" });

            issue.Add(new SelectListItem { Text = "Issue4", Value = "Issue4" });

            issue.Add(new SelectListItem { Text = "Others", Value = "Others" });

            ViewData["Issue"] = issue;
            ViewBag.userid = u;

            help.Status = "Not Solved";
            help.Solution = "Not Provided";
            sc.helps.Add(help);
            sc.SaveChanges();
            Response.Write("<h4 style="+"text-align:center;" + ">Submitted Successfully</h4>");
            return View();
        }

        public ActionResult ShopOwnerTickets()
        {
            string n = Convert.ToString(TempData["shopOwner"]);
            TempData["shopOwnerName"] = n;
            string u = Convert.ToString(TempData["userId"]);
            TempData["shopOwnerUserId"] = u;
            int rrid = Convert.ToInt32(TempData["RID"]);
            TempData["rId"] = rrid;
            Session["si"] = Session["SID"];
            string user = (string)Session["userid"];

            return View(from s in sc.helps where s.UserId == user select s);
        }
    }
}