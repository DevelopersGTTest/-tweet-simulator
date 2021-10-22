using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using WebApp.Models.ViewModels;

namespace WebApp.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<ListUserViewModel> userList;
            using (PARROQUIAEntities db = new PARROQUIAEntities())
            {

                USUARIO userSession = (USUARIO)Session["User"];
                if (userSession != null)
                {
                    ViewBag.Message = "Bienvenido: " + Convert.ToString(userSession.username);
                }

                userList  = (from u in db.USUARIOs
                                select new ListUserViewModel
                                {
                                    id_user = u.id_usuario,
                                    id_rol = u.id_rol,
                                    nombre = u.nombre,
                                    apellido = u.apellido,
                                    fecha_creacion = u.fecha_creacion,
                                    username = u.username,
                                    password = u.password
                                }).ToList();

            }
            return View(userList);
        }

        public ActionResult BackPanel() {
            return RedirectToAction("Index", "Panel");
        }

    }
}