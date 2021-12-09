using LibAntojitosBussines.Models;
using libComunes.CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace LibAntojitosBussines
{
    public class ClsCliente
    {
        public GridView grvTiempo { get; set; }
        public string Sql;
        public string strDocumento { get; set; }
        public string strNobreCliente { get; set; }
        public string strApellido { get; set; }

        public string strDireccion { get; set; }
        public string strTelefono { get; set; }
        public string strEmail { get; set; }


        public string Error { get; set; }

        #region "METODOS"

        public bool Guardar()

        {
            Sql = " INSERT INTO tblClientes (strDocumento, strNobreCliente, strApellido, strDireccion, strTelefono, strEmail) " +
                                      "VALUES (@prstrDocumento,  @prstrNobreCliente, @prstrApellido, @prstrDireccion, @prstrTelefono, @prstrEmail )";


            clsConexion oConexion = new clsConexion();
            oConexion.SQL = Sql;
            oConexion.AgregarParametro("@prstrDocumento", strDocumento);
            oConexion.AgregarParametro("@prstrNobreCliente", strNobreCliente);
            oConexion.AgregarParametro("@prstrApellido", strApellido);
            oConexion.AgregarParametro("@prstrDireccion", strDireccion);
            oConexion.AgregarParametro("@prstrTelefono", strTelefono);
            oConexion.AgregarParametro("@prstrEmail", strEmail);

            if (oConexion.EjecutarSentencia())
            {
                oConexion = null;
                return true;


            }
            else
            {
                Error = oConexion.Error;
                oConexion = null;
                return false;
            }


        }

        public ClienteDto Buscar(string Documento)

        {
            ClienteDto cliente = new ClienteDto();
            Sql = " select * from tblClientes where strDocumento='"+Documento+"'";
            clsConexion oConexion = new clsConexion();
            oConexion.SQL = Sql;
            oConexion.AgregarParametro("@prstrDocumento", Documento);

            if (oConexion.Consultar())
            {
                if (oConexion.Reader.HasRows)
                {

                    oConexion.Reader.Read();
                    cliente.strDocumento = Documento;
                    cliente.strNobreCliente = oConexion.Reader.GetString(1);
                    cliente.strApellido = oConexion.Reader.GetString(2);
                    cliente.strDireccion = oConexion.Reader.GetString(3);
                    cliente.strTelefono = oConexion.Reader.GetString(4);
                    cliente.strEmail = oConexion.Reader.GetString(5);
                    return cliente;

                }
                else
                {
                    oConexion.CerrarConexion();
                    oConexion = null;
                    Error = "No se encontro Cliente registrado";
                    return null;

                }

            }
            else {
                Error = oConexion.Error;
                oConexion.CerrarConexion();
                oConexion = null;
               
            }


            return null;
            
           


        }


       




        #endregion



    }
}
