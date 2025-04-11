using ShoppingProjectA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingProjectA.Controllers
{
    public class ForgotIdController : Controller
    {
        private ShoppingContext sc;
        public ForgotIdController()
        {
            sc = new ShoppingContext();
        }
        // GET: ForgotId
        public ActionResult ForgotIdIndex()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotIdIndex(ForgotId forgotId)
        {
            var reg = sc.Registrations.Where(m => m.ContactNumber == forgotId.ContactNumber && m.Email == forgotId.Email).FirstOrDefault();
            if (reg != null)
            {
                if (reg.BirthCity == forgotId.BirthCity && reg.Strength == forgotId.Strength && reg.BestFriendName == forgotId.BestFriend)
                {
                    forgotId.Message = reg.UserId + "is your userid";
                }
                else
                {
                    forgotId.Message = "You entered wrong details!";
                }
            }
            else
            {
                forgotId.Message = "You entered wrong details!";
            }
            return View(forgotId);
        }
        public ActionResult ForgotPwIndex()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPwIndex(ForgotPw forgotPw)
        {
            var reg = sc.Registrations.Where(m => m.UserId == forgotPw.UserId).FirstOrDefault();
            if (reg != null)
            {
                if (reg.BirthCity == forgotPw.BirthCity && reg.Strength == forgotPw.Strength && reg.BestFriendName == forgotPw.BestFriend)
                {
                    return RedirectToAction("PwReset",new { userid = forgotPw.UserId });
                }
                else
                {
                    forgotPw.Message = "You entered wrong details!";
                }
                
            }
            else
            {
                forgotPw.Message = "You entered wrong details!";
            }
            return View(forgotPw);


        }
        public ActionResult PwReset(string userid)
        {
            Session["userid"] = userid;
            return View();
        }
        [HttpPost]
        public ActionResult PwReset(PwReset pw)
        {
            string user = (string)Session["userid"];

            var reg = sc.Registrations.SingleOrDefault(m => m.UserId == user);
            if(reg != null)
            {
                reg.Password = pw.Password;
                reg.RePassword = pw.RePassword;
                sc.SaveChanges();
                pw.Message = "Password changed successfully, please login again!";

            }

            return View(pw);
        }
    }
}