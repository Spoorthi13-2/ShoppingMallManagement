using ShoppingProjectA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaptchaMvc.HtmlHelpers;
using System.Web.Security;

namespace ShoppingProjectA.Controllers
{
    
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult LoginIndex()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginIndex(Registration reg)
        {
            using (ShoppingContext sc = new ShoppingContext())
            {
                var logus = sc.Registrations.Where(m => m.UserId == reg.UserId).FirstOrDefault();
                var logpw = sc.Registrations.Where(m => m.Password == reg.Password).FirstOrDefault();
                    if (logus == null )
                    {
                        reg.ErrorMesssage = reg.UserId + " user id is not registered! please register.";
                        return View("LoginIndex", reg);
                    }
                    else if (logpw == null)
                    {
                        reg.ErrorMesssage = "Wrong password!";
                        return View("LoginIndex", reg);
                    }
                    else if (!(this.IsCaptchaValid("Captcha is not valid")))
                    {
                        reg.ErrorMesssage = "Invalid captcha";
                        return View("LoginIndex", reg);
                    }
                
                    else
                    {
                        if (logus.Category == "Admin")
                        {
                        Session["userid"] = logus.UserId;
                            string Name = logus.FirstName;
                            return RedirectToAction("AdminIndex", "Admin", new { name = Name });
                        }
                        else
                        {
                        Session["userid"] = logus.UserId;
                        var shop = (from s in sc.shops where s.UserId == logus.UserId select s).FirstOrDefault();
                            if (shop == null)
                            {
                                Session["userid"] = logus.UserId;
                                return RedirectToAction("CreateProfile", "ShopOwner");
                            }
                            else
                            {
                                Session["Sid"] = shop.Id;
                                Session["Sownername"] = shop.ShopOwnerName;
                                Session["Suserid"] = shop.UserId;
                                string Name = logus.FirstName;
                                string Userid = logus.UserId;
                                return RedirectToAction("ShopOwnerIndex", "ShopOwner", new { Id = (int)Session["Sid"] });
                            }
                        }
                    }
            }
        }
         public ActionResult Logout()
         {
            

            Session.Clear();
            return RedirectToAction("LoginIndex","Login");
         }

    }
}