using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZoologicoWeb.Models
{
    public class Animal
    {
        public int IdAnimal { get; set; }
        public string Nombre { get; set; }
        public int IdEspecie { get; set; }

        //adicionales
        public string NombreEspecie { get; set; }
    }
}