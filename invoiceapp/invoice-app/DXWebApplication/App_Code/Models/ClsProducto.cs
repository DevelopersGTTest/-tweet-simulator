using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DXWebApplication.App_Code.Models
{
    public class ClsProducto
    {
        private int idProducto;
        private int idTipoProducto;
        private string descripcion;
        private decimal precio;
        private int existencia;
        private int estado;

        public int IdProducto
        {
            get
            {
                return idProducto;
            }

            set
            {
                idProducto = value;
            }
        }

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

        public int Existencia
        {
            get
            {
                return existencia;
            }

            set
            {
                existencia = value;
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

        public decimal Precio
        {
            get
            {
                return precio;
            }

            set
            {
                precio = value;
            }
        }

    }
}