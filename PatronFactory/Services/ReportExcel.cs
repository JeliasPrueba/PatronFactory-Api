using ClosedXML.Excel;
using PatronFactory.Interfaces;
using PatronFactory.Model;

namespace PatronFactory.Services
{
    public class ReportExcel: IUserFiles
    {
        public Byte[] GenerarArchivo(List<User> usuario)
        {
            var Excel = new XLWorkbook();
            var Hoja = Excel.AddWorksheet("Hoja de reporte");
            Hoja.Cell(1, 1).Value = "ID";
            Hoja.Cell(1, 2).Value = "Nombre";
            Hoja.Cell(1, 3).Value = "Fecha de creacion";
            Hoja.Cell(1, 4).Value = "Valor Total";

            usuario.ForEach(usuario =>
            {
                Hoja.Cell(2, 1).Value = usuario.Id;
                Hoja.Cell(2, 2).Value = usuario.Nombre;
                Hoja.Cell(2, 3).Value = usuario.FechaDeCreacion;
                Hoja.Cell(2, 4).Value = usuario.ValorTotal;
            });

            MemoryStream memoryStream = new MemoryStream();
            Excel.SaveAs(memoryStream);

            return memoryStream.ToArray();
        }

        public string ContentType() => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        public string Format() => "xlsx";
    }
}
