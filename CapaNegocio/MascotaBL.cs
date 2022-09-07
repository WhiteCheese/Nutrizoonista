using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class MascotaBL
    {
        public List<ListadoMascotaCLS> filtrarMascota(string nombre)
        {
            MascotaDAL obj = new MascotaDAL();
            return obj.filtrarMascota(nombre);
        }
        public List<ListadoMascotaCLS> listarMascota()
        {
            MascotaDAL obj = new MascotaDAL();
            return obj.listarMascota();
        }

        public MascotaCLS recuperarMascota(int idmascota)
        {
            MascotaDAL obj = new MascotaDAL();
            return obj.recuperarMascota(idmascota);
        }

        public int eliminarMascota(int id)
        {
            MascotaDAL obj = new MascotaDAL();
            return obj.eliminarMascota(id);
        }

        public int guardarMascota(MascotaCLS oMascotaCLS)
        {
            MascotaDAL obj = new MascotaDAL();
            return obj.guardarMascota(oMascotaCLS);
        }
    }
}
