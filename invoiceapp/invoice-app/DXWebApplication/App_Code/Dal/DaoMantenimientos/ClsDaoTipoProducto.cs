using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DXWebApplication.App_Code.Utilidades;
using DXWebApplication.App_Code.Models;

namespace DXWebApplication.App_Code.Dal.DaoMantenimientos
{
    public class ClsDaoTipoProducto : ClsDataLayer
    {
        ClsConexion objSql = new ClsConexion();
        ClsErrorHandler log = new ClsErrorHandler();
        string strSql = "";
        //Estructura de un metodo para obtener informacion de la BD
        public bool GetTipoProductoAll()
        {
            try
            {
                strSql = "SELECT ID_TIPO_PRODUCTO, DESCRIPCION, ESTADO FROM POS.TIPO_PRODUCTO  ";
                DsReturn = objSql.EjectuaSQL(strSql, "Tipo_Producto");
            }
            catch (Exception ex)
            {
                log.LogError(ex.ToString(), ex.StackTrace);
                return false;
            }
            return true;
        }
        //Estructura de un metodo para ABC
        public bool InsertTipoProducto(ClsTipoProducto tipoProducto)
        {
            strSql = "INSERT INTO POS.TIPO_PRODUCTO(ID_TIPO_PRODUCTO, DESCRIPCION, ESTADO)"
                + "VALUES("
                + "(SELECT ISNULL(MAX(ID_TIPO_PRODUCTO), 0) + 1 FROM POS.TIPO_PRODUCTO), "
                + "'" + tipoProducto.Descripcion + "',"
                + "'" + tipoProducto.Estado + "'"
                + ")";
            return ExecuteSql(strSql);
        }
        //Metodo para modificar tipo producto
        public bool ModificaTipoProducto(ClsTipoProducto tipoProducto)
        {
            strSql = "UPDATE POS.TIPO_PRODUCTO "
                + " SET DESCRIPCION = '" + tipoProducto.Descripcion + "', ESTADO = '" + tipoProducto.Estado + "'"
                + "WHERE ID_TIPO_PRODUCTO = " + tipoProducto.IdTipoProducto;

            return ExecuteSql(strSql);
        }


        //delete
        public bool EliminarTipoProducto(int idTipoProducto)
        {
            strSql = "DELETE FROM POS.TIPO_PRODUCTO WHERE ID_TIPO_PRODUCTO = " + idTipoProducto;
            return ExecuteSql(strSql);
        }

        //e
        public bool ExecuteSql(string strSql)
        {
            try
            {
                return objSql.ejecutarNonQuery(strSql);
            }
            catch (Exception ex)
            {
                log.LogError(ex.ToString(), ex.StackTrace);
                return false;
            }
        }

    }
}