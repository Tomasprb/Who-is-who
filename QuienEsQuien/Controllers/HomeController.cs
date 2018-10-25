using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuienesQuien.Models;
using QuienEsQuien.Models;

namespace QuienesQuien.Controllers
{
    public class HomeController : Controller
    {
        Conexion bd = new Conexion();

        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Nosotros()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult LoginParcial()
        {
            return View();
        }

        public ActionResult Login(string Nombre, string Contraseña)
        {
            Login X = bd.Login(Nombre, Contraseña);

            Session["NombeUser"] = X.Nombre;

            if (X.Nombre != "-1")
            {
                Session["NombreNow"] = X.Nombre;
                Session["AdminNow"] = X.Admin;
                return View("Index");
            }
            else
            {
                ViewBag.NoUserLogin = "El usuario ingresado no existe";
                Session["NombreNow"] = null;
                Session["AdminNow"] = false;
                return View("LoginParcial");
            }
        }

        public ActionResult RegisterParcial()
        {
            return View();
        }

        public ActionResult Register(string Nombre, string Contraseña)
        {
            int x = bd.Register(Nombre, Contraseña);
            if (x == 1)
            {
                Session["NombreNow"] = Nombre;
                Session["AdminNow"] = false;
                return View("RegisterDone");
            }
            else
            {
                return View("RegisterNo");
            }
        }

        public ActionResult Logout()
        {
            Session["NombreNow"] = null;
            Session["AdminNow"] = false;

            return View("Index");
        }

        public ActionResult Perfil()
        {
            return View();
        }
    }
}