using libComunes.CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibAntojitosBussines
{
   public  class clsVenta
    {
        public string Sql;
        public string strDocumento { get; set; }
        public string StrUsuario { get; set; }
        public double TotalVenta { get; set; }   

        public string Error { get; set; }


        public int Guardar()

        {
            int idfactura = 0;

            Sql = "SP_GuardaVenta";
            clsConexion oConexion = new clsConexion();
            oConexion.SQL = Sql;
            oConexion.StoredProcedure = true;
            oConexion.AgregarParametro("@strDocumento", strDocumento);
            oConexion.AgregarParametro("@StrUsuario", StrUsuario);
            oConexion.AgregarParametro("@TotalVenta", TotalVenta);
   

            if (oConexion.Consultar())
            {
                if (oConexion.Reader.HasRows)
                {
                    oConexion.Reader.Read();


                    idfactura = oConexion.Reader.GetInt32(0);
                }

                oConexion = null;
                return idfactura;


            }
            else
            {
                Error = oConexion.Error;
                oConexion = null;
                return idfactura;
            }


        }



    }
}
