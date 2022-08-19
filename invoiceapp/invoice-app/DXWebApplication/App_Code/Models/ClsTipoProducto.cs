using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DXWebApplication.App_Code.Models
{
    public class ClsTipoProducto
    {
        private int idTipoProducto;
        private string descripcion;
        private int estado;


        public int IdTipoProducto
        {
            get
            {
                return idTipoProducto;
            }

            set
            {
                idTipoProducto = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }
        

        public int Estado
        {
            get
            {
                return estado;
            }

            set
            {
                estado = value;
            }
        }


    }
}