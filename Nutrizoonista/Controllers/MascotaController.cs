using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace Nutrizoonista.Controllers
{
    public class MascotaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<ListadoMascotaCLS> filtrarMascota(string nombre)
        {
            MascotaDAL obj = new MascotaDAL();
            return obj.filtrarMascota(nombre);
        }

        public List<ListadoMascotaCLS> listarMascota()
        {
            MascotaBL obj = new MascotaBL();
            return obj.listarMascota();
        }

        public MascotaCLS recuperarMascota(int id)
        {
            MascotaBL obj = new MascotaBL();
            return obj.recuperarMascota(id);
        }

        public int eliminarMascota(int id)
        {
            MascotaBL obj = new MascotaBL();
            return obj.eliminarMascota(id);
        }

        public int guardarDatos(MascotaCLS oMascotaCLS)
        {
            MascotaBL obj = new MascotaBL();
            return obj.guardarMascota(oMascotaCLS);
        }
    }
}
