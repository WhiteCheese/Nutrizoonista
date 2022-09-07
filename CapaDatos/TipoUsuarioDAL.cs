using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class TipoUsuarioDAL: CadenaDAL
    {
        public List<TipoUsuarioCLS> listarTipoUsuario()
        {
            List<TipoUsuarioCLS> lista = null;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_LISTAR_TIPOUSUARIO", cn))
                    {
                        //Le indico que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
                        if (drd != null)
                        {
                            lista = new List<TipoUsuarioCLS>();
                            int posId = drd.GetOrdinal("IDTIPOUSUARIO");
                            int posNombre = drd.GetOrdinal("NOMBRE");
                            int posDescripcion = drd.GetOrdinal("DESCRIPCION");
                            TipoUsuarioCLS oTipoUsuarioCLS;
                            while (drd.Read())
                            {
                                oTipoUsuarioCLS = new TipoUsuarioCLS();
                                oTipoUsuarioCLS.idtipousuario = drd.IsDBNull(posId) ? 0 : drd.GetInt32(posId);
                                oTipoUsuarioCLS.nombre = drd.IsDBNull(posNombre) ? "" : drd.GetString(posNombre);
                                oTipoUsuarioCLS.descripcion = drd.IsDBNull(posDescripcion) ? "" : drd.GetString(posDescripcion);
                                lista.Add(oTipoUsuarioCLS);
                            }
                            cn.Close();
                        }

                    }

                }
                catch (Exception ex)
                {
                    cn.Close();
                    //null para mi es error
                    lista = null;
                }

            }
            return lista;
        }

    }
}
