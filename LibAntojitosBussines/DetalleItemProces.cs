using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using LibAntojitosBussines.Models;
using libComunes.CapaDatos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LibAntojitosBussines
{
   public class DetalleItemProces
    {
      
        public List<DetallesItemModel> DetallesList { get; set; }

        public int IdFactura { get; set; }

        public string NombreCliente { get; set; }

        public string DocumentoCliente { get; set; }

        public string Usuario { get; set; }

        public string ValorTotal { get; set; }

        public string Error { get; set; }

        public string Sql;


        

        public bool Guardar()

        {
            bool OK = true;

            foreach(DetallesItemModel detalle in DetallesList)
            {

                Sql = "SP_GuardaDetalleVenta";
                clsConexion oConexion = new clsConexion();
                oConexion.SQL = Sql;
                oConexion.StoredProcedure = true;
                oConexion.AgregarParametro("@prIdVenta", IdFactura);
                oConexion.AgregarParametro("@pridCodigProduc", detalle.CodigoProduto);
                oConexion.AgregarParametro("@intCantidad", detalle.Cantidad);
                oConexion.AgregarParametro("@doublePrecio", detalle.Valor);

                if (oConexion.EjecutarSentencia())
                {


                    oConexion = null;
                    OK=true;


                }
                else
                {
                    Error = oConexion.Error;
                    oConexion = null;
                    OK= false;
                }



            }

            return OK;

           


        }


        public MemoryStream GeneraPdfFactura()
        {
            MemoryStream ms = new MemoryStream();
            iText.Kernel.Pdf.PdfWriter pw = new iText.Kernel.Pdf.PdfWriter(ms);
            PdfDocument pdfDocument = new PdfDocument(pw);
            Document doc = new Document(pdfDocument, PageSize.LETTER);
            doc.SetMargins(175, 25, 65, 32);
            float[] widths = new float[] { 15f,5f,10f,20f,15f,10f,20f };

            Style stylecell = new Style().SetBorder(Border.NO_BORDER);

            Table _table = new Table(widths).UseAllAvailableWidth().SetBorderLeft(new SolidBorder(1)).SetBorderRight(new SolidBorder(1)).SetBorderTop(new SolidBorder(1)).SetBorderBottom(new SolidBorder(1));


            Cell _cell = new Cell().Add(new Paragraph("Nombre Cliente").SetFontSize(8));
            _table.AddHeaderCell(_cell.AddStyle(stylecell));

            _cell = new Cell().Add(new Paragraph("Nombre Usuario").SetFontSize(8));
            _table.AddHeaderCell(_cell.AddStyle(stylecell));

            _cell = new Cell().Add(new Paragraph("valor Pagar").SetFontSize(8));
            _table.AddHeaderCell(_cell.AddStyle(stylecell));

            _table.GetHeader();


            _cell = new Cell().Add(new Paragraph(NombreCliente));
            _table.AddCell(_cell.AddStyle(stylecell));

            _cell = new Cell().Add(new Paragraph(Usuario));
            _table.AddCell(_cell.AddStyle(stylecell));

            _cell = new Cell().Add(new Paragraph(ValorTotal));
            _table.AddCell(_cell.AddStyle(stylecell));


            doc.Add(_table);
            doc.Close();
            byte[] byesstream = ms.ToArray();
            ms = new MemoryStream();
            ms.Write(byesstream, 0, byesstream.Length);
            ms.Position = 0;
            return ms;

        }








    }
}
