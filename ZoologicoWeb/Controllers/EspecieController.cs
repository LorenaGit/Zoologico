using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZoologicoWeb.Models;
using ZoologicoWeb.Repository;

namespace ZoologicoWeb.Controllers
{
    public class EspecieController : Controller
    {
        // GET: Especie
        public ActionResult Index()
        {
            EspecieRepository er = new EspecieRepository();

            List<Especie> especie = er.getEspeciesAll();

            ViewBag.x = especie;
            return View();
        }
    }
}