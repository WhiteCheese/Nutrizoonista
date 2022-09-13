using CapaEntidad;
using CapaNegocio;
using Grpc.Core;
using Microsoft.AspNetCore.Mvc;

using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Http.Extensions;


namespace Nutrizoonista.Controllers
{
    public class CitaController : Controller
    {
        private readonly IConverter _converter;

        public CitaController(IConverter converter)
        {
            _converter = converter;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult VistaParaPDF()
        {
            return View();
        }

        public IActionResult MostrarPDFenPagina()
        {
            string pagina_actual = HttpContext.Request.Path;
            string url_pagina = HttpContext.Request.GetEncodedUrl();
            url_pagina = url_pagina.Replace(pagina_actual, "");
            url_pagina = $"{url_pagina}/Cita/VistaParaPDF";


            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = new GlobalSettings()
                {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait
                },
                Objects = {
                    new ObjectSettings(){
                        Page = url_pagina
                    }
                }

            };

            var archivoPDF = _converter.Convert(pdf);

            return File(archivoPDF, "application/pdf");
        }

        public IActionResult DescargarPDF()
        {
            string pagina_actual = HttpContext.Request.Path;
            string url_pagina = HttpContext.Request.GetEncodedUrl();
            url_pagina = url_pagina.Replace(pagina_actual, "");
            url_pagina = $"{url_pagina}/Cita/VistaParaPDF";


            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = new GlobalSettings()
                {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait
                },
                Objects = {
                    new ObjectSettings(){
                        Page = url_pagina
                    }
                }

            };

            var archivoPDF = _converter.Convert(pdf);
            string nombrePDF = "reporte_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf";

            return File(archivoPDF, "application/pdf", nombrePDF);
        }

        public List<ListadoCitaCLS> listarCita()
        {
            CitaBL obj = new CitaBL();
            return obj.listarCita();
        }

        public List<ListadoCitaCLS> filtrarCita(ListadoCitaCLS objCita)
        {
            CitaBL obj = new CitaBL();
            return obj.filtrarCita(objCita);
        }


    }
}
