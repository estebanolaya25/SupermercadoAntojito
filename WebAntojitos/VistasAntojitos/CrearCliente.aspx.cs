using LibAntojitosBussines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAntojitos.VistasAntojitos
{
    public partial class CrearCliente : System.Web.UI.Page
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

        }

        protected void btnCrearCliente_Click(object sender, EventArgs e)
        {
            ClsCliente objCliente = new ClsCliente();


            objCliente.strDocumento = txtDocumento.Text;
            objCliente.strNobreCliente = txtNombre.Text;
            objCliente.strApellido = txtApellidos.Text;
            objCliente.strTelefono = txtTelefono.Text;
            objCliente.strDireccion = txrDireccion.Text;
            objCliente.strEmail = txtEmial.Text;


            if (objCliente.Guardar())

            {
                Session["Usuario"] = lblUsuario.Text;
                Response.Redirect("IniciarVenta.aspx?strDocumento=" + objCliente.strDocumento+"&strNombre="+ objCliente.strNobreCliente+ "&strUsuario="+ lblUsuario.Text);
            }
            else { 
            
            }





          
        }
    }
}