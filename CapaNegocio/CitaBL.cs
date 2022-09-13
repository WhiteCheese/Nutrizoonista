using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CitaBL
    {
        public List<ListadoCitaCLS> listarCita()
        {
            CitaDAL obj = new CitaDAL();
            return obj.listarCita();
        }

        public List<ListadoCitaCLS> filtrarCita(ListadoCitaCLS objCita)
        {
            CitaDAL obj = new CitaDAL();
            return obj.filtrarCita(objCita);
        }

    }
}
