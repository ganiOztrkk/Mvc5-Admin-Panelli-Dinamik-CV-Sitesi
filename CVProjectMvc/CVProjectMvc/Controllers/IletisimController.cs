using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CVProjectMvc.Repositories;

namespace CVProjectMvc.Controllers
{
    public class IletisimController : Controller
    {
        private readonly IletisimRepository _repository = new IletisimRepository();
        public ActionResult Index()
        {
            var iletisim = _repository.List();
            return View(iletisim);
        }
    }
}