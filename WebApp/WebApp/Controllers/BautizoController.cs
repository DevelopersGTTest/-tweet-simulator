using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using WebApp.Models.ViewModels;

namespace WebApp.Controllers
{
    public class BautizoController : Controller
    {
        // GET: Bautizo
        public ActionResult Index()
        {
            List<ListBautizoViewModel> bautizosList;
            using (PARROQUIAEntities db = new PARROQUIAEntities())
            {
                USUARIO userSession = (USUARIO)Session["User"];
                if (userSession != null)
                {
                    Session["RolId"] = userSession.id_rol;
                    ViewBag.Message = "Bienvenido: " + Convert.ToString(userSession.username);
                }

                bautizosList = (from b in db.BAUTIZOes
                                select new ListBautizoViewModel
                                {
                                    id_bautizo = b.id_bautizo,
                                    id_usuario_registro = b.id_usuario_registro,
                                    nombre_bautizado = b.nombre_bautizado,
                                    fecha_bautizo = b.fecha_bautizo,
                                    nombre_padre = b.nombre_padre,
                                    nombre_madre = b.nombre_madre,
                                    nombres_padrinos = b.nombres_padrinos,
                                    fecha_nacimiento_bautizado = b.fecha_nacimiento_bautizado
                                }).ToList();


            }
                return View(bautizosList);
        }

        public ActionResult BackPanel()
        {
            return RedirectToAction("Index", "Panel");
        }

        public ActionResult NewBautizo() {
            using (PARROQUIAEntities db = new PARROQUIAEntities())
            {
                USUARIO userSession = (USUARIO)Session["User"];
                if (userSession != null)
                {
                    Session["RolId"] = userSession.id_rol;
                    ViewBag.Message = "Bienvenido: " + Convert.ToString(userSession.username);
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult SaveBautizo(
            string nombre_bautizado, string fecha_nacimiento_bautizado,
            string nombre_padre, string nombre_madre, string nombres_padrinos, string fecha_bautizo)
        {
            using (PARROQUIAEntities db = new PARROQUIAEntities())
            {
                USUARIO userSession = (USUARIO)Session["User"];
                Session["RolId"] = userSession.id_rol;

                BAUTIZO newBautizo = new BAUTIZO();
                newBautizo.id_usuario_registro = 1;
                newBautizo.nombre_bautizado = nombre_bautizado;
                newBautizo.fecha_bautizo = fecha_bautizo;
                newBautizo.nombre_padre = nombre_padre;
                newBautizo.nombre_madre = nombre_madre;
                newBautizo.nombres_padrinos = nombres_padrinos;
                newBautizo.fecha_nacimiento_bautizado = fecha_nacimiento_bautizado;

                db.BAUTIZOes.Add(newBautizo);
                db.SaveChanges();
            }
            return Redirect("Index");
        }

        [HttpGet]
        public ActionResult DeleteBautizo(int id_bautizo)
        {
            using (PARROQUIAEntities db = new PARROQUIAEntities())
            {
                var bautizoDb = db.BAUTIZOes.Find(id_bautizo);
                db.BAUTIZOes.Remove(bautizoDb);
                db.SaveChanges();
            }
            return Redirect("Index");
        }

        [HttpGet]
        public ActionResult ReporteBautizo(int id_bautizo) {
            return View();
        }

    }
}