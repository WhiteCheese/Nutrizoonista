using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaDatos
{
    public class MascotaDAL:CadenaDAL
    {

        public List<ListadoMascotaCLS> listarMascota()
        {
            List<ListadoMascotaCLS> lista = null;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_LISTAR_MASCOTA", cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult);
                        if (dr != null)
                        {
                            ListadoMascotaCLS oListadoMascotaCLS;
                            lista = new List<ListadoMascotaCLS>();
                            int postId = dr.GetOrdinal("IDMASCOTA");
                            int postNombre = dr.GetOrdinal("NOMBREMASCOTA");
                            int postEdad = dr.GetOrdinal("EDADMASCOTA");
                            int postEspecie = dr.GetOrdinal("ESPECIEMASCOTA");
                            int postGenero = dr.GetOrdinal("GENEROMASCOTA");
                            while (dr.Read())
                            {
                                oListadoMascotaCLS = new ListadoMascotaCLS();
                                oListadoMascotaCLS.idmascota = dr.IsDBNull(postId) ? 0 : dr.GetInt32(postId);
                                oListadoMascotaCLS.nombremascota = dr.IsDBNull(postNombre) ? "" : dr.GetString(postNombre);
                                oListadoMascotaCLS.edadmascota = dr.IsDBNull(postEdad) ? "" : dr.GetString(postEdad);
                                oListadoMascotaCLS.especiemascota = dr.IsDBNull(postEspecie) ? "" : dr.GetString(postEspecie);
                                oListadoMascotaCLS.generomascota = dr.IsDBNull(postGenero) ? "" : dr.GetString(postGenero);
                                lista.Add(oListadoMascotaCLS);
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

        public List<ListadoMascotaCLS> filtrarMascota(string nombre)
        {
            List<ListadoMascotaCLS> lista = null;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_FILTRAR_MASCOTA", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombre", nombre == null ? "" : nombre);
                        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult);
                        if (dr != null)
                        {
                            ListadoMascotaCLS oListadoMascotaCLS;
                            lista = new List<ListadoMascotaCLS>();
                            int postId = dr.GetOrdinal("IDMASCOTA");
                            int postNombre = dr.GetOrdinal("NOMBREMASCOTA");
                            int postEdad = dr.GetOrdinal("EDADMASCOTA");
                            int postEspecie = dr.GetOrdinal("ESPECIEMASCOTA");
                            int postGenero = dr.GetOrdinal("GENEROMASCOTA");
                            while (dr.Read())
                            {
                                oListadoMascotaCLS = new ListadoMascotaCLS();
                                oListadoMascotaCLS.idmascota = dr.IsDBNull(postId) ? 0 : dr.GetInt32(postId);
                                oListadoMascotaCLS.nombremascota = dr.IsDBNull(postNombre) ? "" : dr.GetString(postNombre);
                                oListadoMascotaCLS.edadmascota = dr.IsDBNull(postEdad) ? "" : dr.GetString(postEdad);
                                oListadoMascotaCLS.especiemascota = dr.IsDBNull(postEspecie) ? "" : dr.GetString(postEspecie);
                                oListadoMascotaCLS.generomascota = dr.IsDBNull(postGenero) ? "" : dr.GetString(postGenero);
                                lista.Add(oListadoMascotaCLS);
                            }
                            cn.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    cn.Close();
                    
                }

            }
            return lista;
        }

        public MascotaCLS recuperarMascota(int idmascota)
        {

            MascotaCLS oMascotaCLS = new MascotaCLS();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_RECUPERAR_MASCOTA", cn))
                    {
                        //Le indico que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", idmascota);
                        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult);
                        if (dr != null)
                        {
                            int posId = dr.GetOrdinal("IDMASCOTA");
                            int posIdGenero = dr.GetOrdinal("IDGENEROMASCOTA");
                            int posIdEspecie = dr.GetOrdinal("IDESPECIEMASCOTA");
                            int posIdEsterilizado = dr.GetOrdinal("IDESTERILIZADOMASCOTA");
                            int posIdNivelActividad = dr.GetOrdinal("IDNIVELACTIVIDADMASCOTA");
                            int posIdTomaMedicamentos = dr.GetOrdinal("IDTOMAMEDICAMENTOSMASCOTA");
                            int posNombre = dr.GetOrdinal("NOMBREMASCOTA");
                            int posEdad = dr.GetOrdinal("EDADMASCOTA");
                            int posRaza = dr.GetOrdinal("RAZAMASCOTA");
                            int posActividadDiaria = dr.GetOrdinal("ACTIVIDADDIARIA");
                            int posPeso = dr.GetOrdinal("PESOMASCOTA");
                            int posTipoAlimento = dr.GetOrdinal("TIPOALIMENTO");
                            int posMarcaAlimento = dr.GetOrdinal("MARCAALIMENTO");
                            int posCantidadComida = dr.GetOrdinal("CANTIDADCOMIDA");
                            int posEnfermedades = dr.GetOrdinal("ENFERMEDADES");
                            int posMedicamentos = dr.GetOrdinal("MEDICAMENTOS");

                            while (dr.Read())
                            {
                                oMascotaCLS.idmascota = dr.IsDBNull(posId) ? 0 : dr.GetInt32(posId);
                                oMascotaCLS.idgeneromascota = dr.IsDBNull(posIdGenero) ? 0 : dr.GetInt32(posIdGenero);
                                oMascotaCLS.idespeciemascota = dr.IsDBNull(posIdEspecie) ? 0 : dr.GetInt32(posIdEspecie);
                                oMascotaCLS.idesterilizadomascota = dr.IsDBNull(posIdEsterilizado) ? 0 : dr.GetInt32(posIdEsterilizado);
                                oMascotaCLS.idnivelactividadmascota = dr.IsDBNull(posIdNivelActividad) ? 0 : dr.GetInt32(posIdNivelActividad);
                                oMascotaCLS.idtomamedicamentosmascota = dr.IsDBNull(posIdTomaMedicamentos) ? 0 : dr.GetInt32(posIdTomaMedicamentos);
                                oMascotaCLS.nombremascota = dr.IsDBNull(posNombre) ? "" : dr.GetString(posNombre);
                                oMascotaCLS.edadmascota = dr.IsDBNull(posEdad) ? "" : dr.GetString(posEdad);
                                oMascotaCLS.razamascota = dr.IsDBNull(posRaza) ? "" : dr.GetString(posRaza);
                                oMascotaCLS.actividaddiaria = dr.IsDBNull(posActividadDiaria) ? "" : dr.GetString(posActividadDiaria);
                                oMascotaCLS.pesomascota = dr.IsDBNull(posPeso) ? "" : dr.GetString(posPeso);
                                oMascotaCLS.tipoalimento = dr.IsDBNull(posTipoAlimento) ? "" : dr.GetString(posTipoAlimento);
                                oMascotaCLS.marcaalimento = dr.IsDBNull(posMarcaAlimento) ? "" : dr.GetString(posMarcaAlimento);
                                oMascotaCLS.cantidadcomida = dr.IsDBNull(posCantidadComida) ? "" : dr.GetString(posCantidadComida);
                                oMascotaCLS.enfermedades = dr.IsDBNull(posEnfermedades) ? "" : dr.GetString(posEnfermedades);
                                oMascotaCLS.medicamentos = dr.IsDBNull(posMedicamentos) ? "" : dr.GetString(posMedicamentos);
                            }
                            cn.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    cn.Close();
                    oMascotaCLS = null;
                }
            }
            return oMascotaCLS;
        }

        public int eliminarMascota(int id)
        {
            //Respuesta 0 sera error
            int rpta = 0;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_ELIMINAR_MASCOTA", cn))
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

        public int guardarMascota(MascotaCLS oMascotaCLS)
        {
            //Respuesta 0 sera error
            int rpta = 0;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_GUARDAR_MASCOTA", cn))
                    {
                        //Le indico que es u procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idmascota", oMascotaCLS.idmascota);
                        cmd.Parameters.AddWithValue("@idgeneromascota", oMascotaCLS.idgeneromascota);
                        cmd.Parameters.AddWithValue("@idespeciemascota", oMascotaCLS.idespeciemascota);
                        cmd.Parameters.AddWithValue("@idesterilizadomascota", oMascotaCLS.idesterilizadomascota);
                        cmd.Parameters.AddWithValue("@idnivelactividadmascota", oMascotaCLS.idnivelactividadmascota);
                        cmd.Parameters.AddWithValue("@idtomamedicamentosmascota", oMascotaCLS.idtomamedicamentosmascota);
                        cmd.Parameters.AddWithValue("@nombremascota", oMascotaCLS.nombremascota);
                        cmd.Parameters.AddWithValue("@edadmascota", oMascotaCLS.edadmascota);
                        cmd.Parameters.AddWithValue("@razamascota", oMascotaCLS.razamascota);
                        cmd.Parameters.AddWithValue("@actividaddiaria", oMascotaCLS.actividaddiaria);
                        cmd.Parameters.AddWithValue("@pesomascota", oMascotaCLS.pesomascota);
                        cmd.Parameters.AddWithValue("@tipoalimento", oMascotaCLS.tipoalimento);
                        cmd.Parameters.AddWithValue("@marcaalimento", oMascotaCLS.marcaalimento);
                        cmd.Parameters.AddWithValue("@cantidadcomida", oMascotaCLS.cantidadcomida);
                        cmd.Parameters.AddWithValue("@enfermedades", oMascotaCLS.enfermedades);
                        cmd.Parameters.AddWithValue("@medicamentos", oMascotaCLS.medicamentos);
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
