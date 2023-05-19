using CVProjectMvc.Models.Entity;
using CVProjectMvc.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVProjectMvc.Controllers
{
    public class HakkimdaController : Controller
    {
        private readonly HakkimdaRepository _repository = new HakkimdaRepository();
        [HttpGet]
        public ActionResult Index()
        {
            var hakkimda = _repository.Get(1);
            return View(hakkimda);
        }
        [HttpPost]
        public ActionResult Index(Hakkimda hakkimda)
        {
            var hakkim = _repository.Get(1);
            hakkim.Ad = hakkimda.Ad;
            hakkim.Soyad = hakkimda.Soyad;
            hakkim.Adres = hakkimda.Adres;
            hakkim.Telefon = hakkimda.Telefon;
            hakkim.Mail = hakkimda.Mail;
            hakkim.Aciklama = hakkimda.Aciklama;
            hakkim.Resim = hakkimda.Resim;
            _repository.Update(hakkim);
            return RedirectToAction("Index");
        }
    }
}