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

        public ActionResult NewUser() {
            using (PARROQUIAEntities db = new PARROQUIAEntities())
            {
                USUARIO userSession = (USUARIO)Session["User"];
                if (userSession != null)
                {
                    ViewBag.Message = "Bienvenido: " + Convert.ToString(userSession.username);
                }
            }
                return View();
        }

        [HttpPost]
        public ActionResult SaveUser(string name, string lastname, string username, string password, string rol ) {
            using (PARROQUIAEntities db = new PARROQUIAEntities()) {
          
                USUARIO newUser = new USUARIO();
                newUser.id_rol = int.Parse(rol);
                newUser.nombre = name;
                newUser.apellido = lastname;
                newUser.fecha_creacion = DateTime.Parse("2021-11-24 12:35:29.123");
                newUser.username = username;
                newUser.password = password;

                db.USUARIOs.Add(newUser);
                db.SaveChanges();
            }
            return Redirect("Index");

        }

        [HttpGet]
        public ActionResult DeleteUser(int id_user) {
            using (PARROQUIAEntities db = new PARROQUIAEntities())
            {
                var userDb = db.USUARIOs.Find(id_user);
                db.USUARIOs.Remove(userDb);
                db.SaveChanges();
            }
            return Redirect("Index");
        }

    }
}