using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CitaCLS
    {
        public int idcita { get; set; }
        public int idmascota { get; set; }
        public int idservicio { get; set; }
        public int idveterinario { get; set; }
        public int idsucursal { get; set; }
        public DateTime fecharegistro { get; set; }
        public int idhorario { get; set; }
    }

    public class ListadoCitaCLS
    {
        public int idcita { get; set; }
        public string nombremascota { get; set; }
        public string nombreservicio { get; set; }
        public string nombreveterinario { get; set; }
        public string nombresucursal { get; set; }
        public DateTime fecharegistro { get; set; }
        public string horario { get; set; }


        public int idespeciemascota { get; set; }
        public DateTime fechafin { get; set; }

    }
}
