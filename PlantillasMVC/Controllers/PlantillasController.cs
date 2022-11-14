using Microsoft.AspNetCore.Mvc;
using plantillasDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rotativa.AspNetCore;
using Newtonsoft.Json;


namespace PlantillasMVC.Controllers
{
    public class PlantillasController : Controller
    {
        private Administrador miAdmin = Administrador.Instancia;

       
        public IActionResult IndexAltaPlantilla()
        {
            string strJson = "[";
            ViewBag.Equipos = miAdmin.Equipos;
            ViewBag.Formaciones = miAdmin.Formaciones;
            int i = 0;
            foreach (Formacion miFormacion in miAdmin.Formaciones)
            {
                if (i == miAdmin.Formaciones.Count - 1)
                {
                    strJson += JsonConvert.SerializeObject(miFormacion);

                }
                else
                {
                    strJson += JsonConvert.SerializeObject(miFormacion) + ",";
                    i++;
                }

            }
            strJson += "]";
            ViewBag.Formaciones = strJson;
            string strJsonf = "[";
            int j = 0;
            foreach (Equipo miEquipo in miAdmin.Equipos)
            {
                if (j == miAdmin.Equipos.Count - 1)
                {
                    strJsonf += JsonConvert.SerializeObject(miEquipo);

                }
                else
                {
                    strJsonf += JsonConvert.SerializeObject(miEquipo) + ",";
                    j++;
                }

            }
            strJsonf += "]";
            ViewBag.Equipos = strJsonf;
            return View();
            //return new ViewAsPdf("IndexAltaPlantilla");
        }
        public IActionResult IndexVerAlineacion()
        {
            string strJsonf = "[";
            int j = 0;
            foreach (Equipo miEquipo in miAdmin.Equipos)
            {
                if (j == miAdmin.Equipos.Count - 1)
                {
                    strJsonf += JsonConvert.SerializeObject(miEquipo);

                }
                else
                {
                    strJsonf += JsonConvert.SerializeObject(miEquipo) + ",";
                    j++;
                }

            }
            strJsonf += "]";
            ViewBag.Equipos = strJsonf;
            return View();
        }
        public IActionResult VerAlineacion(string equipo, string rival)
        {
            Alineacion miAlineacion = miAdmin.AlineacionPorEquipoYRival(equipo, rival);
            ViewBag.Alineacion = JsonConvert.SerializeObject(miAlineacion);

            return View("IndexVerAlineacion");
        }
       
    }
}
