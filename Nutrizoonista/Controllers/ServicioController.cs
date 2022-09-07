using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace Nutrizoonista.Controllers
{
    public class ServicioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<ServicioCLS> filtrarServicio(string nombre)
        {
            ServicioDAL obj = new ServicioDAL();
            return obj.filtrarServicio(nombre);
        }

        public List<ServicioCLS> listarServicio()
        {
            ServicioDAL obj = new ServicioDAL();
            return obj.listarServicio();
        }
    }
}
