
using DocumentFormat.OpenXml.Drawing;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using PatronFactory.Interfaces;
using PatronFactory.Model;

using System.Text;
using Table = iText.Layout.Element.Table;

namespace PatronFactory.Services
{
    public class ReportPdf: IUserFiles
    {
        public Byte[] GenerarArchivo(List<User> usuario)
        {
            using var memory = new MemoryStream();
            using var writter = new PdfWriter(memory);
            using var pdf = new PdfDocument(writter);
            var document = new Document(pdf);

            var table = new Table(4);
            table.AddHeaderCell("ID");
            table.AddHeaderCell("Nombre");
            table.AddHeaderCell("Fecha de creacion");
            table.AddHeaderCell("Valor total");

            usuario.ForEach(usuario =>
            {
                table.AddCell(usuario.Id.ToString());
                table.AddCell(usuario.Nombre.ToString());
                table.AddCell(usuario.FechaDeCreacion.ToShortDateString());
                table.AddCell(usuario.ValorTotal.ToString());

            });

            document.Add(table);
            document.Close();

            return memory.ToArray();
        }

        public string ContentType() => "application/pdf";
        public string Format() => "pdf";
    }
}
