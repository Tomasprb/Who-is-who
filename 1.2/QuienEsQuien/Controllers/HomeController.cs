using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuienesQuien.Models;

namespace QuienesQuien.Controllers
{
    public class HomeController : Controller
    {
        Conexion bd = new Conexion();

        public ActionResult Index(Session UserNow)
        {
            if (UserNow.NombreUser == null)
            {

            }
            else
            {
                ViewBag.UserNow = UserNow;
            }
            return View();
        }

        public ActionResult Nosotros(Session UserNow)
        {
            ViewBag.Message = "Your application description page.";
            if (UserNow.NombreUser == null)
            {

            }
            else
            {
                ViewBag.UserNow = UserNow;
            }
            return View();
        }

        public ActionResult LoginParcial()
        {
            return View();
        }

        public ActionResult Login(string Nombre, string Contraseña)
        {
            Session X = bd.Login(Nombre, Contraseña);

            if (X.NombreUser != "-1")
            {
                ViewBag.UserNow = X;
                return View("Index");
            }
            else
            {
                ViewBag.NoUserLogin = "El usuario ingresado no existe";
                ViewBag.UserNow = null;
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
                Session f = new Session(Nombre, false);
                ViewBag.UserNow = f;
                return View("RegisterDone");
            }
            else
            {
                return View("RegisterNo");
            }
        }

        public ActionResult Logout()
        {
            ViewBag.UserNow = null;

            return View("Index");
        }

        public ActionResult BackOffice(Session UserNow)
        {
            if (UserNow.NombreUser == null)
            {

            }
            else
            {
                ViewBag.UserNow = UserNow;
            }
            return View("MenuBackoffice");
        }//mandar bien el viewbag usernow
    }
}