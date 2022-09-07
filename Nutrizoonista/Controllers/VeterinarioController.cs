using Microsoft.AspNetCore.Mvc;
using CapaEntidad;
using CapaNegocio;
using System;

namespace Nutrizoonista.Controllers
{
    public class VeterinarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<VeterinarioCLS> listarVeterinario()
        {
            VeterinarioBL obj = new VeterinarioBL();
            return obj.listarVeterinario();
        }

        public List<VeterinarioCLS> filtrarVeterinario(VeterinarioCLS objVet)
        {
            VeterinarioBL obj = new VeterinarioBL();
            return obj.filtrarVeterinario(objVet);
        }

        // 1-> Correcto y 0->Incorrecto
        public int guardarDatos(VeterinarioCLS objVet)
        {
            VeterinarioBL obj = new VeterinarioBL();
            return obj.guardarVeterinario(objVet);
        }

        public VeterinarioCLS recuperarVeterinario(int id)
        {
            VeterinarioBL obj = new VeterinarioBL();
            return obj.recuperarVeterinario(id);
        }

        public int eliminarVeterinario(int id)
        {
            VeterinarioBL obj = new VeterinarioBL();
            return obj.eliminarVeterinario(id);
        }
    }
}
