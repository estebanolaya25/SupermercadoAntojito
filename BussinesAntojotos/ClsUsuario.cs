using libComunes.CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesAntojotos
{
    public class ClsUsuario
    {
        public string strUsuario { get; set; }
        public string strClave { get; set; }
        public string Sql;
        public string Error;




        public bool IniciarSession()
        {
            Sql = "SELECT     Clave  " +
                      "FROM          tblUsuario " +
                      "WHERE       NombreUser  = @prUsuario";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = Sql;
            oConexion.AgregarParametro("@prUsuario", strUsuario);

            if (oConexion.Consultar())
            {
                //Se utiliza el objeto Reader... Propiedad HasRows, y métodos Get
                if (oConexion.Reader.HasRows)
                {
                    //Se lee el reader con el metodo Read
                    oConexion.Reader.Read();
                    //Se capturan los datos
                    if (strClave == oConexion.Reader.GetString(0))
                    {

                        oConexion.CerrarConexion();
                        oConexion = null;
                        return true;
                    }
                    else
                    {
                        Error = "Contraseña Errada!";

                        oConexion.CerrarConexion();
                        oConexion = null;
                        return false;

                    }


                }
                else
                {
                    //No hay datos, se levanta un error
                    Error = "no hay usuario registado con : " + strUsuario;
                    //Cerrar y liberar
                    oConexion.CerrarConexion();
                    oConexion = null;
                    return false;
                }
            }
            else
            {
                Error = oConexion.Error;
                //Cerrar conexión
                oConexion.CerrarConexion();
                oConexion = null;
                return false;
            }


        }



    }
}
