using LibAntojitosBussines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAntojitos.models;

namespace WebAntojitos.VistasAntojitos
{
    public partial class VistaUser : System.Web.UI.Page
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            ClsCliente objCliente = new ClsCliente();

            string documento = txtDocumentoCliente.Text;

            clientemodel objclienteModel = new clientemodel();


            var objclienteModel1 = objCliente.Buscar(documento);


            if (objclienteModel1 == null)
            {

                Session["Usuario"] = lblUsuario.Text;

                Response.Redirect("CrearCliente.aspx");

            }
            else
            {
                Session["Usuario"] = lblUsuario.Text;

                Response.Redirect("IniciarVenta.aspx?strDocumento=" + objclienteModel1.strDocumento + "&strNombre=" + objclienteModel1.strNobreCliente+"&strUsuario="+ Session["Usuario"]);



            }



        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
           
        }
    }
}