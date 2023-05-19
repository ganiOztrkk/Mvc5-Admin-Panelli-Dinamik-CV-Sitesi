using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CVProjectMvc.Models.Entity;
using CVProjectMvc.Repositories;

namespace CVProjectMvc.Controllers
{
    public class AdminController : Controller
    {
        private readonly GenericRepository<Admin> _repository = new GenericRepository<Admin>();
        public ActionResult Index()
        {
            var admin = _repository.List();
            return View(admin);
        }

        [HttpGet]
        public ActionResult AdminEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminEkle(Admin admin)
        {
            _repository.Add(admin);
            return RedirectToAction("Index");
        }

        public ActionResult AdminSil(int id)
        {
            var admin = _repository.Get(id);
            _repository.Delete(admin);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AdminGuncelle(int id)
        {
            var admin = _repository.Get(id);
            return View(admin);
        }
        [HttpPost]
        public ActionResult AdminGuncelle(Admin admin)
        {
            var value = _repository.Get(admin.ID);
            value.KullaniciAdi = admin.KullaniciAdi;
            value.Sifre = admin.Sifre;
            _repository.Update(value);
            return RedirectToAction("Index");
        }
    }
}