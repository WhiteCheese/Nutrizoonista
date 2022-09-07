using CapaEntidad;
using CapaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace Nutrizoonista.Controllers
{
    public class TipoUsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<TipoUsuarioCLS> listarTipoUsuario()
        {
            TipoUsuarioBL obj = new TipoUsuarioBL();
            return obj.listarTipoUsuario();
        }
    }
}
