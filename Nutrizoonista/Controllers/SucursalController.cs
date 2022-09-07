using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace Nutrizoonista.Controllers
{
    public class SucursalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<SucursalCLS> listarSucursal()
        {
            SucursalBL obj = new SucursalBL();
            return obj.listarSucursal();
        }

        public List<SucursalCLS> filtrarSucursal(string nombre)
        {
            SucursalDAL obj = new SucursalDAL();
            return obj.filtrarSucursal(nombre);
        }
    }
}
