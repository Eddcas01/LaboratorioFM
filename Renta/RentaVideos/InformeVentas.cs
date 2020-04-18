using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace RentaVideos
{
    public partial class InformeVentas : Form
    {
        conexion con = new conexion();
        public InformeVentas()
        {
            InitializeComponent();
            llenartbl();
        }

        void llenartbl()// al inicializar la tabla de usuarios
        {
            string sql = "select re.MEMBRESIA, rd.PRECIO_UNIDAD, rd.CANTIDAD , (sum(rd.PRECIO_UNIDAD*rd.CANTIDAD)) as 'Total' from renta_detalle rd INNER JOIN renta_encabezado re on re.ID_ENCABEZADO=rd.ID_ENCABEZADO WHERE re.ESTADO=1 GROUP by re.MEMBRESIA;";
            OdbcCommand command = new OdbcCommand(sql, con.conexion1());
            OdbcDataAdapter adaptador = new OdbcDataAdapter(command);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);

            dgb_informe.DataSource = dt;
            adaptador.Update(dt);


        }



        void exportarTabla(DataGridView dtg, string name)
        {
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            PdfPTable pdftable = new PdfPTable(dtg.Columns.Count);
            pdftable.DefaultCell.Padding = 3;
            pdftable.WidthPercentage = 100;
            pdftable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdftable.DefaultCell.BorderWidth = 1;

            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
            foreach (DataGridViewColumn col in dtg.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(col.HeaderText));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdftable.AddCell(cell);
            }

            foreach (DataGridViewRow row in dtg.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdftable.AddCell(new Phrase(cell.Value.ToString(), text));
                }
            }


            var savefeldialoge = new SaveFileDialog();
            savefeldialoge.FileName = name;
            savefeldialoge.DefaultExt = ".pdf";
            if (savefeldialoge.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefeldialoge.FileName, FileMode.Create))
                {
                    Document pdfdoc = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
                    PdfWriter.GetInstance(pdfdoc, stream);
                    pdfdoc.Open();
                    pdfdoc.Add(pdftable);
                    pdfdoc.Close();
                    stream.Close();
                }

            }


        }

        private void Button1_Click(object sender, EventArgs e)
        {
            exportarTabla( dgb_informe  ,"InformeVentas");
        }
    }
}
