using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class TipoUsuarioBL
    {
        public List<TipoUsuarioCLS> listarTipoUsuario()
        {
            TipoUsuarioDAL oTipoUsuarioDAL = new TipoUsuarioDAL();
            return oTipoUsuarioDAL.listarTipoUsuario();
        }
    }
}
