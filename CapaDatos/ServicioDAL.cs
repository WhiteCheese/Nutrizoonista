using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using CapaEntidad;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ServicioDAL: CadenaDAL
    {
        public List<ServicioCLS> filtrarServicio(string nombre)
        {
            List<ServicioCLS> lista = null;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("Select IDSERVICIO,NOMBRE,DESCRIPCION FROM SERVICIO WHERE ESTADO = 1 and NOMBRE like '%" + nombre + "%' ", cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult);//Guardar memoria para un solo select
                        if (dr != null)
                        {
                            ServicioCLS OServicioCLS;
                            lista = new List<ServicioCLS>();
                            int postID = dr.GetOrdinal("IDSERVICIO");
                            int postNombre = dr.GetOrdinal("NOMBRE");
                            int postDescripcion = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                OServicioCLS = new ServicioCLS();
                                OServicioCLS.idservicio = dr.IsDBNull(postID) ? 0 : dr.GetInt32(postID);
                                OServicioCLS.nombre = dr.IsDBNull(postNombre) ? "" : dr.GetString(postNombre);
                                OServicioCLS.descripcion = dr.IsDBNull(postDescripcion) ? "" : dr.GetString(postDescripcion);
                                lista.Add(OServicioCLS);
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

        public List<ServicioCLS> listarServicio()
        {
            List<ServicioCLS> lista = null;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("Select IDSERVICIO,NOMBRE,DESCRIPCION FROM SERVICIO WHERE ESTADO = 1", cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult);//Guardar memoria para un solo select
                        if (dr != null)
                        {
                            ServicioCLS oServicioCLS;
                            lista = new List<ServicioCLS>();
                            int postID = dr.GetOrdinal("IDSERVICIO");
                            int postNombre = dr.GetOrdinal("NOMBRE");
                            int postDescripcion = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                oServicioCLS = new ServicioCLS();
                                oServicioCLS.idservicio = dr.IsDBNull(postID) ? 0 : dr.GetInt32(postID);
                                oServicioCLS.nombre = dr.IsDBNull(postNombre) ? "" : dr.GetString(postNombre);
                                oServicioCLS.descripcion = dr.IsDBNull(postDescripcion) ? "" : dr.GetString(postDescripcion);
                                lista.Add(oServicioCLS);
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
