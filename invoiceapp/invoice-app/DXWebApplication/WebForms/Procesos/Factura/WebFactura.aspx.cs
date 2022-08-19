using DXWebApplication.App_Code.Controller.ControllerMantenimientos;
using DXWebApplication.App_Code.Models;
using DXWebApplication.App_Code.Utilidades;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DXWebApplication.WebForms.Procesos.Factura
{
    public partial class WebFactura : System.Web.UI.Page
    {

        ClsControllerProducto objProducto = new ClsControllerProducto();
        ClsErrorHandler log = new ClsErrorHandler();
        ClsCliente cliente = new ClsCliente();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["PedidoDetalle"] = null;
                Session["CatProducto"] = null;
                Session["PedidoDetalle"] = null;
                Session["Correlativo"] = null;
            }
        }


        

        protected void dxTxtNit_TextChanged(object sender, EventArgs e)
        {
            string nit = dxTxtNit.Text.ToString();
            string constr = System.Configuration.ConfigurationManager.ConnectionStrings["SrvSistema"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            string query = "SELECT ID_CLIENTE, NOMBRE, APELLIDO, NIT, DIRECCION FROM POS.CLIENTE  WHERE NIT='" + nit + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                dxTxtCliente.Text = dr["NOMBRE"].ToString();
                dxTxtDireccion.Text = dr["DIRECCION"].ToString();

            }
            else
            {

                dxTxtCliente.Text = " ";
                dxTxtDireccion.Text = " ";
                Response.Redirect("http://localhost:61908/WebForms/Mantenimientos/Cliente/WebCliente.aspx");
            }
            con.Close();
        }

        void CargaProducto()
        {
            if (objProducto.GetProductoCategoria())
            {
                dxGridProducto.DataSource = objProducto.DsReturn.Tables["Producto"];
                dxGridProducto.DataBind();
                Session["CatProducto"] = objProducto.DsReturn;

            }
        }

        void SetGridProducto()
        {
            dxGridProducto.DataSource = ((DataSet)Session["CatProducto"]);
            dxGridProducto.DataBind();


        }

        void SetGridDetalle()
        {
            dxGridDetalle.DataSource = ((DataTable)Session["PedidoDetalle"]);
            dxGridDetalle.DataBind();
        }

        protected void dxGridProducto_Init(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    CargaProducto();

                }
                if (IsPostBack)
                {
                    SetGridProducto();
                }

            }
            catch (Exception ex)
            {
                log.LogError(ex.ToString(), ex.StackTrace);

            }
        }

        protected void dxBtnAgregar_Click(object sender, EventArgs e)
        {
            DataTable dt = null;
            ClsDetalleFactura detalleFactura = new ClsDetalleFactura();
            List<object> fieldValues = dxGridProducto.GetSelectedFieldValues(new string[] { "ID_PRODUCTO", "DESCRIPCION", "PRECIO" });
            
            if (fieldValues.Count > 0)
            {
                foreach (object[] item in fieldValues)
                {
                    detalleFactura.IdProducto = int.Parse(item[0].ToString());
                    detalleFactura.Descripcion = item[1].ToString();
                    detalleFactura.Precio = decimal.Parse(item[2].ToString());
                }
                int correlativo;
                if (Session["PedidoDetalle"] != null)
                {
                    dt = Session["PedidoDetalle"] as DataTable;
                    correlativo = int.Parse(Session["Correlativo"].ToString()) + 1;
                }
                else
                {
                    dt = filldata();
                    correlativo = 1;

                }
                Session["Correlativo"] = correlativo;
                DataRow fila = dt.NewRow();      

                fila[0] = correlativo;
                fila[1] = int.Parse(dxSpnCantidad.Text);
                fila[2] = detalleFactura.IdProducto;
                fila[3] = detalleFactura.Descripcion;                
                fila[4] = detalleFactura.Precio;
                fila[5] = detalleFactura.Precio * int.Parse(dxSpnCantidad.Text);

                dt.Rows.Add(fila);

                dxGridDetalle.DataSource = dt;
                dxGridDetalle.DataBind();

                Session["PedidoDetalle"] = dt;
                
            }
        }

        //Data table Virtual
        public DataTable filldata()
        {
            DataTable dt = new DataTable();
            DataColumn correlativo = dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("CANTIDAD", typeof(int));
            dt.Columns.Add("ID_PRODUCTO", typeof(string));
            dt.Columns.Add("PRODUCTO", typeof(string));            
            dt.Columns.Add("PRECIO", typeof(decimal));
            dt.Columns.Add("SUBTOTAL", typeof(decimal));

            //dt.Columns.Add("ELIMINAR", typeof(Button));
            dt.PrimaryKey = new DataColumn[] { correlativo };
            correlativo.ReadOnly = true;

            return dt;
        }

        protected void dxGridDetalle_Init(object sender, EventArgs e)
        {
            if (IsPostBack)
                SetGridDetalle();
        }

        protected void dxGridDetalleDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {

            int idDetalle = int.Parse(e.Keys["ID"].ToString());
            DataTable dt = Session["PedidoDetalle"] as DataTable;
            DataRow fila = dt.NewRow();

            e.Cancel = true;
            dt.Rows.Find(idDetalle).Delete(); /// delete

           
            Session["PedidoDetalle"] = dt;
        }

    }




}