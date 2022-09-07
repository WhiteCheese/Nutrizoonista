using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class MascotaCLS
    { 
        public int idmascota { get; set; }
        public int? idusuario { get; set; }
        public int idgeneromascota { get; set; }    
        public int idespeciemascota { get; set; }   
        public int idesterilizadomascota { get; set; }
        public int idnivelactividadmascota { get; set; }    
        public int idtomamedicamentosmascota { get;set; }
        public string nombremascota { get; set; }
        public string edadmascota { get; set; }
        public string razamascota { get; set; }
        public string actividaddiaria { get; set; }
        public string pesomascota { get; set; }
        public string tipoalimento { get; set; }
        public string marcaalimento { get; set; }
        public string cantidadcomida { get; set; }
        public string enfermedades { get; set; }
        public string medicamentos { get; set; }
    }

    public class ListadoMascotaCLS
    {
        public int idmascota { get; set; }
        public string nombremascota { get; set; }
        public string edadmascota { get; set; }
        public string generomascota { get; set; }
        public string especiemascota { get; set; }
    }
}
