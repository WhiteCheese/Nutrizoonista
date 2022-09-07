using Microsoft.AspNetCore.Mvc;
using Nutrizoonista.Models;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace Nutrizoonista.Controllers
{
    public class LoginController : Controller
    {
        static string cadena = "Server=DESKTOP-8LMB3D9\\SQLEXPRESS;database=BD_Nutrizoonista;Integrated Security=true";

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(Usuario oUsuario)
        {
            bool registrado;
            string mensaje;

            if(oUsuario.clave == oUsuario.confirmarclave)
            {
                oUsuario.clave = ConvertirSha256(oUsuario.clave);
            }
            else
            {
                ViewData["Mensaje"] = "Las contraseñas no coinciden";
                return View();
            }

            using (SqlConnection cn = new SqlConnection(cadena))
            {

                SqlCommand cmd = new SqlCommand("SP_REGISTRAR_USUARIO", cn);
                cmd.Parameters.AddWithValue("@email", oUsuario.email);
                cmd.Parameters.AddWithValue("@clave", oUsuario.clave);
                cmd.Parameters.AddWithValue("@nombre", oUsuario.nombre);
                cmd.Parameters.AddWithValue("@apepaterno", oUsuario.apepaterno);
                cmd.Parameters.AddWithValue("@apematerno", oUsuario.apematerno);
                cmd.Parameters.AddWithValue("@celular", oUsuario.celular);
                cmd.Parameters.AddWithValue("@distrito", oUsuario.distrito);
                cmd.Parameters.AddWithValue("@direccion", oUsuario.direccion);
                cmd.Parameters.AddWithValue("@idsexo", oUsuario.idsexo);
                cmd.Parameters.AddWithValue("@idtipodocumento", oUsuario.idtipodocumento);
                cmd.Parameters.AddWithValue("@nrodocumento", oUsuario.nrodocumento);

                cmd.Parameters.Add("registrado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                cmd.ExecuteNonQuery();

                registrado = Convert.ToBoolean(cmd.Parameters["registrado"].Value);
                mensaje = cmd.Parameters["mensaje"].Value.ToString();
            }

            ViewData["mensaje"] = mensaje;

            if (registrado)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult Login(Usuario oUsuario)
        {
            oUsuario.clave = ConvertirSha256(oUsuario.clave);

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("SP_VALIDAR_USUARIO", cn);
                cmd.Parameters.AddWithValue("@email", oUsuario.email);
                cmd.Parameters.AddWithValue("@clave", oUsuario.clave);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                oUsuario.idusuario = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            }

            if (oUsuario.idusuario != 0)
            {
                return RedirectToAction("Index", "Mascota");
            }
            else
            {
                ViewData["mensaje"] = "Usuario no encontrado";
                return View();
            }
        }

        public static string ConvertirSha256(string texto)
        {
            //using System.Text;
            //USAR LA REFERENCIA DE "System.Security.Cryptography"

            StringBuilder Sb = new StringBuilder();
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(texto));

                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }
    }
}
