using PatronFactory.Interfaces;
using PatronFactory.Model;
using System.Net.Mime;
using System.Text;


namespace PatronFactory.Services
{
    public class ReportCsv: IUserFiles
    {
        public Byte[] GenerarArchivo(List<User> usuario)
        {
            var builder = new StringBuilder();
            builder.AppendLine("Id, Nombre, Fecha De Creacion, Valor Total");

            usuario.ForEach(usuario =>
            {
                builder.AppendLine($"{usuario.Id}, {usuario.Nombre}, {usuario.FechaDeCreacion.ToShortDateString()}, {usuario.ValorTotal}");
            });

            var csv = Encoding.UTF8.GetBytes(builder.ToString());

            return csv;
        }

        public string ContentType() => "text/csv";
        public string Format() => "csv";
    }
}
