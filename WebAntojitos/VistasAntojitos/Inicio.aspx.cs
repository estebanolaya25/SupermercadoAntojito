using LibAntojitosBussines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAntojitos.VistasAntojitos
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string Usuario, Contraseña;
            Usuario = txtUsuario.Text;
            Contraseña = txtClave.Text;

            ClsUsuario oUsuario = new ClsUsuario();


            oUsuario.strUsuario = Usuario;
            oUsuario.strClave = Contraseña;

            if (oUsuario.IniciarSession())
            {

                Session["Usuario"] = Usuario;

                Response.Redirect("VistaUser.aspx");




            }
            else
            {
                lblError.Text = oUsuario.Error;

            }


            oUsuario = null;
        }
    }
}