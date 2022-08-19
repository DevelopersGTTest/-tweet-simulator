using DXWebApplication.App_Code.Dal;
using DXWebApplication.App_Code.Dal.DaoMantenimientos;
using DXWebApplication.App_Code.Models;
using DXWebApplication.App_Code.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DXWebApplication.App_Code.Controller.ControllerMantenimientos
{
    public class ClsControllerProducto : ClsController
    {
        ClsErrorHandler log = new ClsErrorHandler();
        ClsDaoProducto objProducto = new ClsDaoProducto();

        public bool GetProductoAll()
        {
            try
            {
                if (objProducto.GetProductoAll())
                {
                    DsReturn = objProducto.DsReturn;
                    return true;
                }
            }
            catch (Exception ex)
            {
                log.LogError(ex.ToString(), ex.StackTrace);
                return false;
            }
            return false;
        }

        public bool GetProductoCategoria()
        {
            try
            {
                if (objProducto.GetProductoCategoria())
                {
                    DsReturn = objProducto.DsReturn;
                    return true;
                }
            }
            catch (Exception ex)
            {
                log.LogError(ex.ToString(), ex.StackTrace);
                return false;
            }
            return false;
        }

        public bool InsertProducto(ClsProducto producto)
        {
            try
            {
                if (objProducto.InsertProducto(producto))
                    return true;
            }
            catch (Exception ex)
            {
                log.LogError(ex.ToString(), ex.StackTrace);
                return false;
            }
            return false;
        }

        public bool EliminarProducto(int idProducto)
        {
            try
            {
                if (objProducto.EliminarProducto(idProducto))
                    return true;
            }
            catch (Exception ex)
            {
                log.LogError(ex.ToString(), ex.StackTrace);
                return false;
            }
            return false;
        }


        public bool ModificaProducto(ClsProducto producto)
        {
            try
            {
                if (objProducto.ModificaProducto(producto))
                    return true;
            }
            catch (Exception ex)
            {
                log.LogError(ex.ToString(), ex.StackTrace);
                return false;
            }
            return false;
        }

    }
}