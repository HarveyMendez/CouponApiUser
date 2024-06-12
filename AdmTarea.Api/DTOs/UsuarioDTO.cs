namespace AdmTarea.Api.DTOs
{
    public class UsuarioDTO
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string cedula { get; set; }
        public string fechaNacimiento { get; set; }
        public string correo { get; set; }
        public string contrasenia { get; set; }
    }
}
