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


        public ActionResult Categorias()
        {
            if (Convert.ToBoolean(Session["AdminNow"]) == true)
            {
                List<Categorias> Categoria = new List<Categorias>();
                Conexion MiConexion = new Conexion();

                Categoria = MiConexion.ListarCategorias();

                ViewBag.Lista = Categoria;
                return View("ABM_Categorias");

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult EdicionCategoria(string Accion, int ID = 0)
        {
            if (Convert.ToBoolean(Session["AdminNow"]) == true)
            {
                Conexion MiConexion1 = new Conexion();
                ViewBag.Accion = Accion;
                if (Accion == "Modificar")
                {
                    Categorias C = MiConexion1.ObtenerCategoria(ID);
                    ViewBag.Id = ID;
                    return View("FormTrabajador", C);
                }
                if (Accion == "Ver")
                {
                    Categorias C = MiConexion1.ObtenerCategoria(ID);
                    return View("FormTrabajador", C);
                }
                if (Accion == "Eliminar")
                {

                    MiConexion1.EliminarTrabajador(ID);
                    List<Categorias> Categoria = new List<Categorias>();
                    Categoria = MiConexion1.ListarCategorias();

                    ViewBag.Lista = Categoria;
                    return View("ABM_Categorias");
                }
                if (Accion == "Insertar")
                {
                    return View("FormTrabajador");
                }

                return View("FormTrabajador");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult CosasATrabajador (Categorias x, string Accion, int Id)
        {
            x.IdCategoria = Id;
            if (Convert.ToBoolean(Session["AdminNow"]) == true)
            {
                Conexion MiConexion2 = new Conexion();
                if (Accion == "Insertar")
                {
                    MiConexion2.InsertarCategoria(x);
                }
                if (Accion == "Modificar")
                {
                    MiConexion2.ModificarCategoria(x);
                }
                List<Categorias> MiCateforia = new List<Categorias>();
                MiCateforia = MiConexion2.ListarCategorias();

                ViewBag.Lista = MiCateforia;
                return View("ABM_Categorias");


            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
    }
