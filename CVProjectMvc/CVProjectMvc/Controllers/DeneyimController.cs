using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CVProjectMvc.Models.Entity;
using CVProjectMvc.Repositories;

namespace CVProjectMvc.Controllers
{
    public class DeneyimController : Controller
    {
        private readonly DeneyimRepository _repository = new DeneyimRepository();
        public ActionResult Index()
        {
            var deneyimList = _repository.List();
            return View(deneyimList);
        }

        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeneyimEkle(Deneyim deneyim)
        {
            _repository.Add(deneyim);
            return RedirectToAction("Index");
        }

        public ActionResult DeneyimSil(int id)
        {
            var deneyim = _repository.Get(id);
            _repository.Delete(deneyim);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeneyimGuncelle(int id)
        {
            var deneyim = _repository.Get(id);
            return View(deneyim);
        }
        [HttpPost]
        public ActionResult DeneyimGuncelle(Deneyim deneyim)
        {
            var value = _repository.Get(deneyim.ID);
            value.Baslik = deneyim.Baslik;
            value.AltBaslik = deneyim.AltBaslik;
            value.Tarih = deneyim.Tarih;
            value.Aciklama = deneyim.Aciklama;
            _repository.Update(value);
            return RedirectToAction("Index");
        }
    }
}