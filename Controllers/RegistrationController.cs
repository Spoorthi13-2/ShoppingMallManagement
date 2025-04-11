using ShoppingProjectA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingProjectA.Controllers
{
    public class RegistrationController : Controller
    {
        private ShoppingContext sc;
        public RegistrationController()
        {
            sc = new ShoppingContext();
        }
        // GET: Registration
        public ActionResult Index()
        {
            var getCategories = sc.Categories.ToList();
            SelectList list = new SelectList(getCategories, "Name", "Name");
            ViewBag.listOfCategories = list;
            List<SelectListItem> gender = new List<SelectListItem>();

            gender.Add(new SelectListItem { Text = "Male", Value = "Male" });

            gender.Add(new SelectListItem { Text = "Female", Value = "Female" });

            gender.Add(new SelectListItem { Text = "Others", Value = "Others" });

            ViewData["GenderType"] = gender;
            return View();
        }

        [HttpPost]
        public ActionResult Index(Registration regis)
        {
            var getCategories = sc.Categories.ToList();
            SelectList list = new SelectList(getCategories, "Name", "Name");
            ViewBag.listOfCategories = list;
            List<SelectListItem> gender = new List<SelectListItem>();

            gender.Add(new SelectListItem { Text = "Male", Value = "Male" });

            gender.Add(new SelectListItem { Text = "Female", Value = "Female" });

            gender.Add(new SelectListItem { Text = "Others", Value = "Others" });

            ViewData["GenderType"] = gender;
            bool mem = IsMember(regis.UserId);
            if (!mem)
            {
                sc.Registrations.Add(regis);
                sc.SaveChanges();
                ViewBag.Name = regis.FirstName;
                return RedirectToAction("LoginIndex", "Login");
            }
            else
            {
                regis.ErrorMesssage = "UserId already exists, Please select other";
                return View(regis);
            }
                
        }
        public ActionResult termsAndConditions()
        {
            return View();
        }

        public bool IsMember(string UserID)
        {
            // This will return if a given user exists
            return sc.Registrations.Any(u => u.UserId == UserID);
        }
    }
}