using libComunes.CapaDatos;
using libComunes.CapaObjetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace LibAntojitosBussines
{
    public class ClsProductos

    {

        public GridView grvProductos { get; set; }
        public string Sql;
        public int intCodigo { get; set; }
        public string strNombre { get; set; }
        public double ValorUnitario { get; set; }
        public int UnidadesExistentes { get; set; }
        public string Error { get; set; }


        public bool Guardar()

        {
            Sql = " INSERT INTO tblProductos (strNombreProducto, ValorUnitario, UnidadesExistentes) " +
                                      "VALUES (@prstrNombre,  @prValorUnitario, @prUnidadesExistentes )";


            clsConexion oConexion = new clsConexion();
            oConexion.SQL = Sql;
            oConexion.AgregarParametro("@prstrNombre", strNombre);
            oConexion.AgregarParametro("@prValorUnitario", ValorUnitario);
            oConexion.AgregarParametro("@prUnidadesExistentes", UnidadesExistentes);


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


        public bool LlenarGridTiempo()
        {
            Sql = "SELECT * from tblProductos";

            clsGrid oGrid = new clsGrid();
            oGrid.SQL = Sql;
           
            oGrid.gridGenerico = grvProductos;
          
            if (oGrid.LlenarGridWeb())
            {
                grvProductos = oGrid.gridGenerico;
                oGrid = null;
              
                return true;
            }
            else
            {
                Error = oGrid.Error;
                oGrid = null;
                return false;
            }
        }


    }
}
