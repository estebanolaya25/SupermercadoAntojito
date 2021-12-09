using LibAntojitosBussines;
using LibAntojitosBussines.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebAntojitos.VistasAntojitos
{
    public partial class IniciarVenta : System.Web.UI.Page
    {

       

        public DetalleItemProces proces;

        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                Session["Usuario"] = null;
                Session["var"] = null;

                llenarGridProducto();
                lblDocCLiente.Text = Request.QueryString["strDocumento"].ToString();
                lblNombreCli.Text = Request.QueryString["strNombre"].ToString();
                lblUsuario.Text = Request.QueryString["strUsuario"].ToString();

                
            }

        }

        protected void GridInventario_SelectedIndexChanged(object sender, EventArgs e)
        {

            double valor;

            lblCodigoPro.Text = GridInventario.SelectedRow.Cells[1].Text;

            valor = Convert.ToDouble(GridInventario.SelectedRow.Cells[3].Text);

            lblProducto.Text = GridInventario.SelectedRow.Cells[2].Text;
            lblValorPro.Text = valor.ToString("C2");

        }

        private void llenarGridProducto()
        {
            string User = lblUsuario.Text;
            ClsProductos objProducto = new ClsProductos();


            objProducto.grvProductos = GridInventario;

            if (!objProducto.LlenarGridTiempo())
            {
                lblError.Text = objProducto.Error;

            }



            objProducto = null;



        }

        

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            double valorPagar = 0;


            List<DetallesItemModel> detalles = new List<DetallesItemModel>();

            detalles=(List<DetallesItemModel>)Session["var"];

            if (detalles == null)
            {
            
            detalles= new List<DetallesItemModel>();
            }    

            DetallesItemModel obtItem = new DetallesItemModel();

            int codigo= Convert.ToInt32(lblCodigoPro.Text);

            int cantidad= Convert.ToInt32(txtCantidad.Text);
            string valorstring = lblValorPro.Text;
            valorstring.Replace("$", "");
            string nc= valorstring.Replace("$ ", "");

            double valorunitario = Convert.ToDouble(nc); //Convert.ToDouble(lblValorPro.Text);

            double valort = valorunitario * cantidad;

            obtItem.CodigoProduto=Convert.ToInt32(lblCodigoPro.Text);
            obtItem.Cantidad = cantidad;
            obtItem.Valor = valort;
            detalles.Add(obtItem);


            foreach (DetallesItemModel item in detalles)
            {
                valorPagar = valorPagar + item.Valor;

            }

            lblTotalPagar.Text = valorPagar.ToString("C2");

            Session["var"] = detalles; 
            GrvItems.DataSource = detalles;
            GrvItems.DataBind();
            



        }

        protected void GrvItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GrvItems_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {

            GridInventario.DataSource = null;
            GridInventario = null;

            Session["Usuario"] = lblUsuario.Text;            
            Response.Redirect("VistaUser.aspx");

        }

        protected void btnFacturar_Click(object sender, EventArgs e)
        {

            int idfactura = 0; ;
            double ValorTotal=0;
            List<DetallesItemModel> detalles = new List<DetallesItemModel>();

            detalles = (List<DetallesItemModel>)Session["var"];


            foreach (DetallesItemModel detalle in detalles)
            {
                ValorTotal = ValorTotal + (detalle.Cantidad * detalle.Valor);

            }

            clsVenta clsVenta = new clsVenta();


            clsVenta.strDocumento = lblDocCLiente.Text;
            clsVenta.StrUsuario = lblUsuario.Text;
            clsVenta.TotalVenta = ValorTotal;

            idfactura = clsVenta.Guardar();

            if (idfactura == 0)
            {
                lblError.Text = "ERROR GUARDANTO";

            }else
            {
                lblError.Text = "ok";

            }


            DetalleItemProces objDetalle = new DetalleItemProces();

            objDetalle.DetallesList = detalles;
            objDetalle.IdFactura = idfactura;
            objDetalle.NombreCliente = lblNombreCli.Text;
            objDetalle.Usuario = lblUsuario.Text;
            objDetalle.ValorTotal = lblTotalPagar.Text;

            if (objDetalle.Guardar())
            {
                lblError.Text = "ok";

            }
            else
            {
                lblError.Text = objDetalle.Error;
            }

            PDFGenerator(objDetalle.GeneraPdfFactura());











        }

        public FileStreamResult PDFGenerator(MemoryStream ms)
        {         

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=labtest.pdf");
            Response.Buffer = true;
            Response.Clear();
            Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
            Response.OutputStream.Flush();
            Response.End();

            return new FileStreamResult(Response.OutputStream, "application/pdf");

        }


    }
}