using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CVProjectMvc.Models.Entity;
using CVProjectMvc.Repositories;

namespace CVProjectMvc.Controllers
{
    public class SertifikaController : Controller
    {
        private readonly SertifikaRepository _repository = new SertifikaRepository();
        public ActionResult Index()
        {
            var sertifikaList = _repository.List();
            return View(sertifikaList);
        }

        [HttpGet]
        public ActionResult SertifikaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SertifikaEkle(Sertifika sertifika)
        {
            _repository.Add(sertifika);
            return RedirectToAction("Index");
        }

        public ActionResult SertifikaSil(int id)
        {
            var sertifika = _repository.Get(id);
            _repository.Delete(sertifika);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SertifikaGuncelle(int id)
        {
            var sertifika = _repository.Get(id);
            return View(sertifika);
        }
        [HttpPost]
        public ActionResult SertifikaGuncelle(Sertifika sertifika)
        {
            var getSertifika = _repository.Get(sertifika.ID);
            getSertifika.Sertifika1 = sertifika.Sertifika1;
            _repository.Update(getSertifika);
            return RedirectToAction("Index");
        }
    }
}