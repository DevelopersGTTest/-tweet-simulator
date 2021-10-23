using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using WebApp.Models.ViewModels;

namespace WebApp.Controllers
{
    public class MatrimonioController : Controller
    {
        // GET: Matrimonio
        public ActionResult Index()
        {
            List<ListMatrimonioViewModel> matrimoniosList;
            using (PARROQUIAEntities db = new PARROQUIAEntities())
            {
                USUARIO userSession = (USUARIO)Session["User"];
                if (userSession != null)
                {
                    Session["RolId"] = userSession.id_rol;
                    ViewBag.Message = "Bienvenido: " + Convert.ToString(userSession.username);
                }

                matrimoniosList = (from m in db.MATRIMONIOs
                                select new ListMatrimonioViewModel
                                {
                                    id_matrimonio = m.id_matrimonio,
                                    id_usuario_registro = m.id_usuario_registro,
                                    nombre_esposo = m.nombre_esposo,
                                    fecha_nacimiento_esposo = m.fecha_nacimiento_esposo,
                                    profesion_esposo = m.profesion_esposo,
                                    nombre_esposa = m.nombre_esposa,
                                    fecha_nacimiento_esposa = m.fecha_nacimiento_esposa,
                                    presion_esposa = m.presion_esposa,
                                    fecha_matrimonio = m.fecha_matrimonio,
                                    nombre_padrinos = m.nombre_padrinos
                                }).ToList();


            }
            return View(matrimoniosList);
        }

        public ActionResult BackPanel()
        {
            return RedirectToAction("Index", "Panel");
        }


        // DeleteMatrimonio?id_matrimonio=@m.id_matrimonio

        [HttpGet]
        public ActionResult DeleteMatrimonio(int id_matrimonio)
        {
            using (PARROQUIAEntities db = new PARROQUIAEntities())
            {
                var matrimonioDb = db.MATRIMONIOs.Find(id_matrimonio);
                db.MATRIMONIOs.Remove(matrimonioDb);
                db.SaveChanges();
            }
            return Redirect("Index");
        }


    }
}