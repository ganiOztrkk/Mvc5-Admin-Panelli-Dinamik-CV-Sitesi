using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CVProjectMvc.Models.Entity;

namespace CVProjectMvc.Controllers
{
    public class DefaultController : Controller
    {
        DbCVProjeEntities2 db = new DbCVProjeEntities2 ();
        public ActionResult Index()
        {
            var value = db.Hakkimdas.ToList();
            return View(value);
        }

        public PartialViewResult Deneyim()
        {
            var deneyimler = db.Deneyims.ToList();
            return PartialView(deneyimler);
        }

        public PartialViewResult Egitim()
        {
            var egitim = db.Egitims.ToList();
            return PartialView(egitim);
        }

        public PartialViewResult Yetenek()
        {
            var yetenek = db.Yeteneks.ToList();
            return PartialView(yetenek);
        }
        public PartialViewResult Hobi()
        {
            var hobiList = db.Hobis.ToList();
            return PartialView(hobiList);
        }
        public PartialViewResult Sertifika()
        {
            var sertifikaList = db.Sertifikas.ToList();
            return PartialView(sertifikaList);
        }
        [HttpGet]
        public PartialViewResult Iletisim()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Iletisim(Iletisim iletisim)
        {
            iletisim.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Iletisims.Add(iletisim);
            db.SaveChanges();
            return PartialView();
        }
    }
}