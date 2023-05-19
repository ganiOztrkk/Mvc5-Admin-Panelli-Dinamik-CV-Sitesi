using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CVProjectMvc.Models.Entity;

namespace CVProjectMvc.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            DbCVProjeEntities2 db = new DbCVProjeEntities2();
            var check = db.Admins.FirstOrDefault(x => x.KullaniciAdi == admin.KullaniciAdi && x.Sifre == admin.Sifre);
            if (check != null)
            {
                FormsAuthentication.SetAuthCookie(check.KullaniciAdi, false);
                Session["KullaniciAdi"] = admin.KullaniciAdi.ToString();
                return RedirectToAction("Index", "Hakkimda");
            }
            return RedirectToAction("Index", "Login");

        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}