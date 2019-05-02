using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BJL.DVDCentral.BL;

namespace BJL.DVDCentral.MVCUI.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Create(string returnurl)
        {
            ViewBag.PageType = "Public";
            ViewBag.ReturnUrl = returnurl;
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user, string returnurl)
        {
            try
            {
                if (user.Login())
                {
                    HttpContext.Session["user"] = user;
                    if (string.IsNullOrEmpty(returnurl))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return Redirect(returnurl);
                    }
                }
                else
                {
                    return View(user);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View(user);
            }

        }


        public ActionResult Logout()
        {
            ViewBag.PageType = "Public";
            Session["user"] = null;
            return View();
        }
    }
}