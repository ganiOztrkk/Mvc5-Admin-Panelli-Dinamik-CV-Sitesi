using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CVProjectMvc.Models.Entity;
using CVProjectMvc.Repositories;

namespace CVProjectMvc.Controllers
{
    public class YetenekController : Controller
    {
        private readonly YetenekRepository _repository = new YetenekRepository();
        public ActionResult Index()
        {
            var yetenekList = _repository.List();
            return View(yetenekList);
        }
        [HttpGet]
        public ActionResult YetenekEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YetenekEkle(Yetenek yetenek)
        {
            _repository.Add(yetenek);
            return RedirectToAction("Index");
        }

        public ActionResult YetenekSil(int id)
        {
            var yetenek = _repository.Get(id);
            _repository.Delete(yetenek);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult YetenekGuncelle(int id)
        {
            var yetenek = _repository.Get(id);
            return View(yetenek);
        }
        [HttpPost]
        public ActionResult YetenekGuncelle(Yetenek yetenek)
        {
            var value = _repository.Get(yetenek.ID);
            value.Yetenek1 = yetenek.Yetenek1;
            value.Oran = yetenek.Oran;
            _repository.Update(value);
            return RedirectToAction("Index");
        }
    }
}