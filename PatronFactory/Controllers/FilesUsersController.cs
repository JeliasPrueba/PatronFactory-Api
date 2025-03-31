using ClosedXML.Excel;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatronFactory.Factories;
using PatronFactory.Model;
using System.Text;

namespace PatronFactory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesUsersController : ControllerBase
    {
        

        public FilesUsersController()
        {
            
        }

        [HttpPost]
        [Route("{format}")]
        public IActionResult CreateReport([FromBody] List<User> usuarios, string format)
        {

            var servicio = ReportGeneratorFactory.ServicesFactory($"{format}");
            var arhivo = servicio.GenerarArchivo(usuarios);

            return File(arhivo, servicio.ContentType(), $"Usuario.{servicio.Format()}");

        }
    }
}
