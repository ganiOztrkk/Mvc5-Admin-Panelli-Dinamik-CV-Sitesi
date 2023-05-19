using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CVProjectMvc.Models.Entity;
using CVProjectMvc.Repositories;

namespace CVProjectMvc.Controllers
{
    public class EgitimController : Controller
    {
        private readonly EgitimRepository _repository = new EgitimRepository();
        public ActionResult Index()
        {
            var egitimler = _repository.List();
            return View(egitimler);
        }

        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EgitimEkle(Egitim egitim)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("EgitimEkle");
            }
            _repository.Add(egitim);
            return RedirectToAction("Index");
        }

        public ActionResult EgitimSil(int id)
        {
            var egitim = _repository.Get(id);
            _repository.Delete(egitim);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EgitimGuncelle(int id)
        {
            var value = _repository.Get(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult EgitimGuncelle(Egitim egitim)
        {
            var value = _repository.Get(egitim.ID);
            value.Baslik = egitim.Baslik;
            value.AltBaslik1 = egitim.AltBaslik1;
            value.AltBaslik2 = egitim.AltBaslik2;
            value.GNO = egitim.GNO;
            value.Tarih = egitim.Tarih;
            _repository.Update(value);
            return RedirectToAction("Index");
        }
    }
}