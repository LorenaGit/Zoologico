using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZoologicoWeb.Models;
using ZoologicoWeb.Repository;

namespace ZoologicoWeb.Controllers
{
    public class AnimalController : Controller
    {
        // GET: Animal
        public ActionResult Index()
        {
            AnimalRepository ar = new AnimalRepository();

            List<Animal> animal = ar.getAnimalesAll();

            ViewBag.x = animal;

            return View();
        }

        public ActionResult FormularioNuevo()
        {

            EspecieRepository er = new EspecieRepository();

            List<Especie> especies = er.getEspeciesAll();

            ViewBag.z = especies;

            return View();
        }

        public void Insertar()
        {
            Animal x = new Animal();

            x.Nombre = Request["Nombre"].ToString();
            x.IdEspecie = Convert.ToInt32(Request["IdEspecie"].ToString());

            AnimalRepository ar = new AnimalRepository();

            int filasAfectadas = ar.insertAnimal(x);

            Response.Redirect("/Animal/Index");
        }

    }
}