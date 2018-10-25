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
            if (Nombre == "" || Contraseña == "")
            {
                if (Nombre == "")
                {
                    ViewBag.NombreNo = "Ingrese un nombre";
                }
                if (Contraseña == "")
                {
                    ViewBag.ContraseñaNo = "Ingrese una contraseña";
                }
                return View("LoginParcial");
            }
            else
            {
                Login X = bd.Login(Nombre, Contraseña);

                if (X.Nombre != "-1")
                {
                    string getHashInputData = GetMD5HashData(Contraseña);

                    if (string.Compare(getHashInputData, storedHashData) == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    //https://stackoverflow.com/questions/8065616/asp-net-hash-password-using-md5
                    if (X.Contraseña==GetHashCode("MD5", Contraseña))
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
        }

        public ActionResult RegisterParcial()
        {
            return View();
        }

        public ActionResult Register(string Nombre, string Contraseña)
        {
            if (Nombre == "" || Contraseña == "")
            {
                if (Nombre == "")
                {
                    ViewBag.NombreNo = "Ingrese un nombre";
                }
                if (Contraseña == "")
                {
                    ViewBag.ContraseñaNo = "Ingrese una contraseña";
                }
                return View("RegisterParcial");
            }
            else
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
                    ViewBag.UserExiste = "Ese nombre de usuario ya existe";
                    return View("RegisterParcial");
                }
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