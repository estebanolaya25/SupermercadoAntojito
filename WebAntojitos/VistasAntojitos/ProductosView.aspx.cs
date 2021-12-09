using LibAntojitosBussines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAntojitos.VistasAntojitos
{
    public partial class ProductosView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string Usuario = Session["Usuario"].ToString();

                lblUsuario.Text = Usuario;
            }
            catch (Exception ex)
            {
                Response.Redirect("Inicio.aspx");
            }

            if (!Page.IsPostBack)
            {
                llenarGridProducto();
            }  
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ClsProductos objProducto = new ClsProductos();
            objProducto.strNombre = txtNombre.Text;
            objProducto.ValorUnitario = Convert.ToDouble(txtValorUunitario.Text);
            objProducto.UnidadesExistentes = Convert.ToInt32(txtUnidadesExistentes.Text);

            if (objProducto.Guardar())
            {

                lblError.Text = "Producto Guardado";
                llenarGridProducto();

            }



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

        protected void GridInventario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridInventario_PageIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {        

            Session["Usuario"] = lblUsuario.Text;
            Response.Redirect("VistaUser.aspx");
        }
    }
}