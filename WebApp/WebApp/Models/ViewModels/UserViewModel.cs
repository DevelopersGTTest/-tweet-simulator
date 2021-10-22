using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.ViewModels
{
    public class UserViewModel
    {
        public int id_user { get; set; }
        public int id_rol { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public DateTime fecha_creacion { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}