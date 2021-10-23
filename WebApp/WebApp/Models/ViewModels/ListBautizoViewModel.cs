using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.ViewModels
{
    public class ListBautizoViewModel
    {
        public int id_bautizo { get; set; }
	    public int id_usuario_registro { get; set; }
        public string nombre_bautizado { get; set; }
	    public string fecha_nacimiento_bautizado { get; set; }
	    public string nombre_padre { get; set; }
	    public string nombre_madre { get; set; }
	    public string nombres_padrinos { get; set; }
        public string fecha_bautizo { get; set; }
    }
}