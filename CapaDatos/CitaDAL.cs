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
    public class CitaDAL:CadenaDAL
    {

        public List<ListadoCitaCLS> listarCita()
        {
            List<ListadoCitaCLS> lista = null;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_LISTAR_CITA", cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult);
                        if (dr != null)
                        {
                            ListadoCitaCLS oListadoCitaCLS;
                            lista = new List<ListadoCitaCLS>();
                            int postId = dr.GetOrdinal("IDCITA");
                            int postNombreMascota = dr.GetOrdinal("NOMBREMASCOTA");
                            int postNombreServicio = dr.GetOrdinal("SERVICIO");
                            int postNombreVeterinario = dr.GetOrdinal("NOMBREVETERINARIO");
                            int postNombreSucursal = dr.GetOrdinal("NOMBRESUCURSAL");
                            int postFecha = dr.GetOrdinal("FECHA");
                            int postHorario = dr.GetOrdinal("HORARIO");
                            while (dr.Read())
                            {
                                oListadoCitaCLS = new ListadoCitaCLS();
                                oListadoCitaCLS.idcita = dr.IsDBNull(postId) ? 0 : dr.GetInt32(postId);
                                oListadoCitaCLS.nombremascota = dr.IsDBNull(postNombreMascota) ? "" : dr.GetString(postNombreMascota);
                                oListadoCitaCLS.nombreservicio = dr.IsDBNull(postNombreServicio) ? "" : dr.GetString(postNombreServicio);
                                oListadoCitaCLS.nombreveterinario = dr.IsDBNull(postNombreVeterinario) ? "" : dr.GetString(postNombreVeterinario);
                                oListadoCitaCLS.nombresucursal = dr.IsDBNull(postNombreSucursal) ? "" : dr.GetString(postNombreSucursal);
                                oListadoCitaCLS.fecharegistro = dr.GetDateTime(postFecha);
                                oListadoCitaCLS.horario = dr.IsDBNull(postHorario) ? "" : dr.GetString(postHorario);
                                lista.Add(oListadoCitaCLS);
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

        public List<ListadoCitaCLS> filtrarCita(ListadoCitaCLS objCita)
        {
            List<ListadoCitaCLS> lista = null;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_FILTRAR_CITA", cn))
                    {
                        //Le indico que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombre", objCita.nombremascota == null ? "" : objCita.nombremascota);
                        cmd.Parameters.AddWithValue("@idespeciemascota", objCita.idespeciemascota == 0 ? "" : objCita.idespeciemascota);
                        cmd.Parameters.AddWithValue("@fecha_inicio", objCita.fecharegistro.ToString() == null ? "" : objCita.fecharegistro.ToString());
                        cmd.Parameters.AddWithValue("@fecha_fin", objCita.fechafin.ToString() == null ? "" : objCita.fechafin.ToString());
                        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult);
                        if (dr != null)
                        {
                            lista = new List<ListadoCitaCLS>();
                            int postId = dr.GetOrdinal("IDCITA");
                            int postNombreMascota = dr.GetOrdinal("NOMBREMASCOTA");
                            int postNombreServicio = dr.GetOrdinal("SERVICIO");
                            int postNombreVeterinario = dr.GetOrdinal("NOMBREVETERINARIO");
                            int postNombreSucursal = dr.GetOrdinal("NOMBRESUCURSAL");
                            int postFecha = dr.GetOrdinal("FECHA");
                            int postHorario = dr.GetOrdinal("HORARIO");
                            ListadoCitaCLS oListadoCitaCLS;
                            while (dr.Read())
                            {
                                oListadoCitaCLS = new ListadoCitaCLS();
                                oListadoCitaCLS.idcita = dr.IsDBNull(postId) ? 0 : dr.GetInt32(postId);
                                oListadoCitaCLS.nombremascota = dr.IsDBNull(postNombreMascota) ? "" : dr.GetString(postNombreMascota);
                                oListadoCitaCLS.nombreservicio = dr.IsDBNull(postNombreServicio) ? "" : dr.GetString(postNombreServicio);
                                oListadoCitaCLS.nombreveterinario = dr.IsDBNull(postNombreVeterinario) ? "" : dr.GetString(postNombreVeterinario);
                                oListadoCitaCLS.nombresucursal = dr.IsDBNull(postNombreSucursal) ? "" : dr.GetString(postNombreSucursal);
                                oListadoCitaCLS.fecharegistro = dr.GetDateTime(postFecha);
                                oListadoCitaCLS.horario = dr.IsDBNull(postHorario) ? "" : dr.GetString(postHorario);
                                lista.Add(oListadoCitaCLS);
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
    }
}
