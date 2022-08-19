using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Xml;

namespace WebSecurityDemo.Controllers
{
    [AllowAnonymous]
    public class XmlController : Controller
    {

        public void ReadXmlWithXmlReader()
        {
            // 1. Cree configuraciones personalizadas para el analizador XML
            var settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;

            // Advertencia: este valor nunca debe ser 0, esto hará que su aplicación
            // vulnerable a este tipo de ataque.
            // Un valor normal sería 1024
            settings.MaxCharactersFromEntities = 0;

            // 2. Cree una instancia de XmlReader y cargue el archivo con configuraciones personalizadas.
            var reader = XmlReader.Create("C:\\Temp\\lol.xml", settings);

            // En este punto, el analizador no procesó el archivo, a menos que lo leyera
            using (reader)
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement()) { }
                }
            }
        }

        public void ReadXmlWithXmlDocument()
        {
            //1. Creamos una instancia de XmlDocument
            var doc = new XmlDocument();
            //2. Cargamos el archivo xml
            doc.Load("C:\\Temp\\lol.xml");
        }

        public IActionResult Index()
        {
            ReadXmlWithXmlReader();

            return View();
        }
    }
}
