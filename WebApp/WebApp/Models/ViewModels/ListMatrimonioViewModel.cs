using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.ViewModels
{
    public class ListMatrimonioViewModel
    {
        public int  id_matrimonio { get; set; }
	    public int id_usuario_registro { get; set; }
        public string nombre_esposo { get; set; }
	    public string fecha_nacimiento_esposo { get; set;  }
        public string profesion_esposo { get; set; }
	    public string nombre_esposa { get; set; }
        public string fecha_nacimiento_esposa { get; set; }
	    public string presion_esposa { get; set; }
        public string fecha_matrimonio { get; set; }
        public string nombre_padrinos  { get; set; }
}
}