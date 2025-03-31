using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Packaging;
using iText.Kernel.Pdf;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatronFactory.Models;

namespace PatronFactory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantillasController : ControllerBase
    {
        public PlantillasController() { }

        [HttpPost]
        public IActionResult GenerarContratoWord()
        {
            string templatePath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Templates", "Pruebaword.docx");

            if (!System.IO.File.Exists(templatePath))
            {
                return BadRequest("La plantilla no fue encontrada.");
            }

            byte[] wordBytes;

            // Leer el archivo directamente en memoria para edición
            using (MemoryStream memoryStream = new MemoryStream(System.IO.File.ReadAllBytes(templatePath)))
            {
                using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(memoryStream, true))
                {
                    var contrato = new { Nombre = "Juan Pérez", Edad = 30 };

                    // Reemplazo de marcadores en el documento
                    foreach (var text in wordDocument.MainDocumentPart.Document.Body.Descendants<Text>())
                    {
                        text.Text = text.Text
                            .Replace("Nombre", contrato.Nombre)
                            .Replace("Edad", contrato.Edad.ToString());
                    }

                    wordDocument.MainDocumentPart.Document.Save();
                }

                wordBytes = memoryStream.ToArray();
            }

            return File(wordBytes, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "Contrato.docx");
        }

    }
}
