using DXWebApplication.App_Code.Models;
using DXWebApplication.App_Code.Utilidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DXWebApplication.App_Code.Dal.DaoProcesos
{
    public class ClsDaoFactura : ClsDataLayer
    {
        ClsConexion objSql = new ClsConexion();
        ClsErrorHandler log = new ClsErrorHandler();
        string strSql = "";


        public bool InsertarFactura(ClsFactura Factura, List<ClsDetalleFactura> LstDetalleFactura)
        {
            SqlConnection conexion = objSql.OpenConexion();
            SqlTransaction transaccion;
            transaccion = conexion.BeginTransaction();
            try
            {
                                
                strSql = "INSERT INTO POS.FACTURA (ID......) VALUES (" + Factura.IdFactura + "";
                objSql.EjectuaSQLT(conexion, transaccion, strSql);

                foreach (ClsDetalleFactura detalleFactura in LstDetalleFactura)
                {
                    strSql = "INSERT INTO POS.DETALLE_FACTURA (.......)";
                    objSql.EjectuaSQLT(conexion, transaccion, strSql);
                    strSql = "UPDATE POS.PRODUCTO SET EXISTENCIA = ";
                    objSql.EjectuaSQLT(conexion, transaccion, strSql);
                }

                transaccion.Commit();

            }
            catch (Exception ex)
            {
                log.LogError(ex.ToString(), ex.StackTrace);
                transaccion.Rollback();
                conexion.Close();

                return false;
            }
            conexion.Close();
            return true;


        }

    }
}