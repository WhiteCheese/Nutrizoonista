using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class VeterinarioBL
    {
        public List<VeterinarioCLS> listarVeterinario()
        {
            VeterinarioDAL oVeterinarioDAL = new VeterinarioDAL();
            return oVeterinarioDAL.listarVeterinario();
        }

        public List<VeterinarioCLS> filtrarVeterinario(VeterinarioCLS objVet)
        {
            VeterinarioDAL oVeterinarioDAL = new VeterinarioDAL();
            return oVeterinarioDAL.filtrarVeterinario(objVet);
        }

        public VeterinarioCLS recuperarVeterinario(int idveterinario)
        {
            VeterinarioDAL oVeterinarioDAL = new VeterinarioDAL();
            return oVeterinarioDAL.recuperarVeterinario(idveterinario);
        }

        public int eliminarVeterinario(int id)
        {
            VeterinarioDAL oVeterinarioDAL = new VeterinarioDAL();
            return oVeterinarioDAL.eliminarVeterinario(id);
        }

        public int guardarVeterinario(VeterinarioCLS oVeterinarioCLS)
        {
            VeterinarioDAL oVeterinarioDAL = new VeterinarioDAL();
            return oVeterinarioDAL.guardarVeterinario(oVeterinarioCLS);
        }
    }
}
