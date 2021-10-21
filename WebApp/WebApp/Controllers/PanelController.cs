using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
   
    public class PanelController : Controller
    {
        // GET: Panel
        public ActionResult Index()
        {
            using (PARROQUIAEntities db = new PARROQUIAEntities()) {

                USUARIO userSession = (USUARIO) Session["User"];
                if (userSession != null) {
                    ViewBag.Message = "Bienvenido: " + Convert.ToString(userSession.username);
                }
            }
            return View();
        }
    }
}