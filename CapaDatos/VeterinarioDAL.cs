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
    public class VeterinarioDAL:CadenaDAL
    {
        public List<VeterinarioCLS> listarVeterinario()
        {
            List<VeterinarioCLS> lista = null;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_LISTAR_VETERINARIO", cn))
                    {
                        //Le indico que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult);
                        if (dr != null)
                        {
                            lista = new List<VeterinarioCLS>();
                            int posId = dr.GetOrdinal("IDVETERINARIO");
                            int posNombre = dr.GetOrdinal("NOMBRE");
                            int posDni = dr.GetOrdinal("DNI");
                            int posCelular = dr.GetOrdinal("CELULAR");
                            VeterinarioCLS oVeterinarioCLS;
                            while (dr.Read())
                            {
                                oVeterinarioCLS = new VeterinarioCLS();
                                oVeterinarioCLS.idveterinario = dr.IsDBNull(posId) ? 0 : dr.GetInt32(posId);
                                oVeterinarioCLS.nombre = dr.IsDBNull(posNombre) ? "" : dr.GetString(posNombre);
                                oVeterinarioCLS.dni = dr.IsDBNull(posDni) ? "" : dr.GetString(posDni);
                                oVeterinarioCLS.celular = dr.IsDBNull(posCelular) ? "" : dr.GetString(posCelular);
                                lista.Add(oVeterinarioCLS);
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

        public List<VeterinarioCLS> filtrarVeterinario(VeterinarioCLS objVet)
        {
            List<VeterinarioCLS> lista = null;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_FILTRAR_VETERINARIO", cn))
                    {
                        //Le indico que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombre", objVet.nombre == null ? "" : objVet.nombre);
                        cmd.Parameters.AddWithValue("@dni", objVet.dni == null ? "" : objVet.dni);
                        cmd.Parameters.AddWithValue("@celular", objVet.celular == null ? "" : objVet.celular);
                        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult);
                        if (dr != null)
                        {
                            lista = new List<VeterinarioCLS>();
                            int posId = dr.GetOrdinal("IDVETERINARIO");
                            int posNombre = dr.GetOrdinal("NOMBRE");
                            int posDni = dr.GetOrdinal("DNI");
                            int posCelular = dr.GetOrdinal("CELULAR");
                            VeterinarioCLS oVeterinarioCLS;
                            while (dr.Read())
                            {
                                oVeterinarioCLS = new VeterinarioCLS();
                                oVeterinarioCLS.idveterinario = dr.IsDBNull(posId) ? 0 : dr.GetInt32(posId);
                                oVeterinarioCLS.nombre = dr.IsDBNull(posNombre) ? "" : dr.GetString(posNombre);
                                oVeterinarioCLS.dni = dr.IsDBNull(posDni) ? "" : dr.GetString(posDni);
                                oVeterinarioCLS.celular = dr.IsDBNull(posCelular) ? "" : dr.GetString(posCelular);
                                lista.Add(oVeterinarioCLS);
                            }
                            cn.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    cn.Close();
                    lista = null;
                }
            }

            return lista;
        }

        public VeterinarioCLS recuperarVeterinario(int idveterinario)
        {

            VeterinarioCLS oVeterinarioCLS = new VeterinarioCLS();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_RECUPERAR_VETERINARIO", cn))
                    {
                        //Le indico que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", idveterinario);
                        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult);
                        if (dr != null)
                        {
                            int posId = dr.GetOrdinal("IDVETERINARIO");
                            int posNombre = dr.GetOrdinal("NOMBRE");
                            int posDni = dr.GetOrdinal("DNI");
                            int posCelular = dr.GetOrdinal("CELULAR");

                            while (dr.Read())
                            {
                                oVeterinarioCLS.idveterinario = dr.IsDBNull(posId) ? 0 : dr.GetInt32(posId);
                                oVeterinarioCLS.nombre = dr.IsDBNull(posNombre) ? "" : dr.GetString(posNombre);
                                oVeterinarioCLS.dni = dr.IsDBNull(posDni) ? "" : dr.GetString(posDni);
                                oVeterinarioCLS.celular = dr.IsDBNull(posCelular) ? "" : dr.GetString(posCelular);
                            }
                            cn.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    cn.Close();
                    oVeterinarioCLS = null;
                }
            }

            return oVeterinarioCLS;
        }

        public int eliminarVeterinario(int id)
        {
            //Respuesta 0 sera error
            int rpta = 0;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_ELIMINAR_VETERINARIO", cn))
                    {
                        //Le indico que es una consulta SQL
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);
                        //Para ejecutar Insert, Update y Delete -> Devuelve el numero de filas afectadas
                        rpta = cmd.ExecuteNonQuery();
                        //Si es 1 es OK, si es 0 es que no se realizo
                    }
                }
                catch (Exception ex)
                {
                    cn.Close();
                    rpta = 0;
                }
            }
            return rpta;
        }

        public int guardarVeterinario(VeterinarioCLS oVeterinarioCLS)
        {
            //Respuesta 0 sera error
            int rpta = 0;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_GUARDAR_VETERINARIO", cn))
                    {
                        //Le indico que es u procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idveterinario", oVeterinarioCLS.idveterinario);
                        cmd.Parameters.AddWithValue("@nombre", oVeterinarioCLS.nombre);
                        cmd.Parameters.AddWithValue("@dni", oVeterinarioCLS.dni);
                        cmd.Parameters.AddWithValue("@celular", oVeterinarioCLS.celular);
                        //Para ejecutar Insert, Update y Delete -> Devuelve el numero de filas afectadas
                        rpta = cmd.ExecuteNonQuery();
                        //Si es 1 es OK, si es 0 es que no se realizo
                    }
                }
                catch (Exception ex)
                {
                    cn.Close();
                    rpta = 0;
                }
            }
            return rpta;
        }

    }
}
