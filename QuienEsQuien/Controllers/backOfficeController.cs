using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuienesQuien.Models;
using QuienEsQuien.Models;

namespace QuienEsQuien.Controllers
{
    public class BackOfficeController : Controller
    {
        // GET: backOffice

        Conexion bd = new Conexion();

        public ActionResult Index()
        {
            if (Convert.ToBoolean(Session["AdminNow"]) == true)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult AltaCategorias()
        {
            
            return View();
        }
        public ActionResult Categorias()
        {
            List<Categorias> Categoria = new List<Categorias>();
            Conexion MiConexion = new Conexion();

            Categoria = MiConexion.ListarCategorias();

            ViewBag.Lista = Categoria;
            return View("ABM_Categorias");

            
        }
    }
}