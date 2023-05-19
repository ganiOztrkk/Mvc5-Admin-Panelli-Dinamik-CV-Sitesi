using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CVProjectMvc.Models.Entity;
using CVProjectMvc.Repositories;

namespace CVProjectMvc.Controllers
{
    public class HobiController : Controller
    {
        private readonly HobiRepository _repository = new HobiRepository();
        [HttpGet]
        public ActionResult Index()
        {
            var hobi = _repository.List();
            return View(hobi);
        }
        [HttpPost]
        public ActionResult Index(Hobi hobi)
        {
            var hobim = _repository.Get(1);
            hobim.Aciklama1 = hobi.Aciklama1;
            hobim.Aciklama2 = hobi.Aciklama2;
            _repository.Update(hobim);
            return RedirectToAction("Index");
        }
    }
}