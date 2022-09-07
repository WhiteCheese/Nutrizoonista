using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ServicioBL
    {
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
