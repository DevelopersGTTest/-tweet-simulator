﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string message = "")
        {
            ViewBag.Message = message;
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password) {

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                using (PARROQUIAEntities db = new PARROQUIAEntities())
                {

                    USUARIO userDb = db.USUARIOs
                        .FirstOrDefault(u => u.username == username && u.password == password);

                    if (userDb != null)
                    {
                        Session["User"] = userDb;
                        return RedirectToAction("Index", "Panel");
                    } else
                    {
                        return RedirectToAction("Index", new { message = "Usuario / Password Incorrectos" });
                    }
                }

            } else {
                return RedirectToAction("Index", new { message = "Invalid Form" });
            }
        }

        [Authorize]
        public ActionResult LogOut() {
            Session.Remove("User");
            return RedirectToAction("Index");
        }

    }
}