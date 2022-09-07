namespace Nutrizoonista.Models
{
    public class Usuario
    {
        public int idusuario { get; set; }
        public string email { get; set; }
        public string clave { get; set; }
        public string nombre { get; set; }
        public string apepaterno { get; set; }
        public string apematerno { get; set; }
        public string celular { get; set; }
        public string distrito { get; set; }
        public string direccion { get; set; }
        public int idsexo { get; set; }
        public int idtipodocumento { get; set; }
        public string nrodocumento { get; set; }

        public string confirmarclave { get; set; }
    }
}
