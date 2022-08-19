using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DXWebApplication.App_Code.Dal;
using DXWebApplication.App_Code.Dal.DaoMantenimientos;
using DXWebApplication.App_Code.Models;
using DXWebApplication.App_Code.Utilidades;

namespace DXWebApplication.App_Code.Controller.ControllerMantenimientos
{
    public class ClsControllerTipoProducto : ClsController
    {

        ClsErrorHandler log = new ClsErrorHandler();
        ClsDaoTipoProducto objTipoProducto = new ClsDaoTipoProducto();

        public bool GetTipoProductoAll()
        {
            try
            {
                if (objTipoProducto.GetTipoProductoAll())
                {
                    DsReturn = objTipoProducto.DsReturn;
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

        public bool InsertTipoProducto(ClsTipoProducto tipoProducto)
        {
            try
            {
                if (objTipoProducto.InsertTipoProducto(tipoProducto))
                    return true;
            }
            catch (Exception ex)
            {
                log.LogError(ex.ToString(), ex.StackTrace);
                return false;
            }
            return false;
        }

        public bool EliminarTipoProducto(int idTipoProducto)
        {
            try
            {
                if (objTipoProducto.EliminarTipoProducto(idTipoProducto))
                    return true;
            }
            catch (Exception ex)
            {
                log.LogError(ex.ToString(), ex.StackTrace);
                return false;
            }
            return false;
        }


        public bool ModificaTipoProducto(ClsTipoProducto tipoProducto)
        {
            try
            {
                if (objTipoProducto.ModificaTipoProducto(tipoProducto))
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