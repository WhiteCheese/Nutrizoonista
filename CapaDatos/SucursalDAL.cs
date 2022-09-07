using CapaEntidad;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class SucursalDAL:CadenaDAL
    {
        public List<SucursalCLS> filtrarSucursal(string nombre)
        {
            List<SucursalCLS> lista = null;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_FILTRAR_SUCURSAL", cn))
                    {
                        //Le indico que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        //Esta linea define un parametro
                        cmd.Parameters.AddWithValue("@nombresucursal", nombre == null ? "" : nombre);
                        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult);
                        if (dr != null)
                        {
                            lista = new List<SucursalCLS>();
                            int posId = dr.GetOrdinal("IDSUCURSAL");
                            int posNombre = dr.GetOrdinal("NOMBRE");
                            int posDireccion = dr.GetOrdinal("DIRECCION");
                            SucursalCLS oSucursalCLS;
                            while (dr.Read())
                            {
                                oSucursalCLS = new SucursalCLS();
                                oSucursalCLS.idsucursal = dr.IsDBNull(posId) ? 0 : dr.GetInt32(posId);
                                oSucursalCLS.nombre = dr.IsDBNull(posNombre) ? "" : dr.GetString(posNombre);
                                oSucursalCLS.direccion = dr.IsDBNull(posDireccion) ? "" : dr.GetString(posDireccion);
                                lista.Add(oSucursalCLS);
                            }
                            cn.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    cn.Close();
                    //Nu
                }
            }

            return lista;
        }

        public List<SucursalCLS> listarSucursal()
        {
            List<SucursalCLS> lista = null;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_LISTAR_SUCURSAL", cn))
                    {
                        //Le indico que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult);
                        if (dr != null)
                        {
                            lista = new List<SucursalCLS>();
                            int posId = dr.GetOrdinal("IDSUCURSAL");
                            int posNombre = dr.GetOrdinal("NOMBRE");
                            int posDireccion = dr.GetOrdinal("DIRECCION");
                            SucursalCLS oSucursalCLS;
                            while (dr.Read())
                            {
                                oSucursalCLS = new SucursalCLS();
                                oSucursalCLS.idsucursal = dr.IsDBNull(posId) ? 0 : dr.GetInt32(posId);
                                oSucursalCLS.nombre = dr.IsDBNull(posNombre) ? "" : dr.GetString(posNombre);
                                oSucursalCLS.direccion = dr.IsDBNull(posDireccion) ? "" : dr.GetString(posDireccion);
                                lista.Add(oSucursalCLS);
                            }
                            cn.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    cn.Close();
                    //Nu
                }
            }

            return lista;
        }

    }
}