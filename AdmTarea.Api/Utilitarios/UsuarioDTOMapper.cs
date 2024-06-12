using AdmTarea.Api.DTOs;
using AdmTarea.BC.Modelos;
using AdmTarea.DA.Entidades;

namespace AdmTarea.Api.Utilitarios
{
    public static class UsuarioDTOMapper
    {
        public static UsuarioDTO ConvertirUsuarioADTO(Usuario usuario)
        {
            return new UsuarioDTO()
            {
                id = usuario.id,
                nombre = usuario.nombre,
                apellido = usuario.apellido,
                cedula = usuario.cedula,
                fechaNacimiento = usuario.fechaNacimiento,
                correo = usuario.correo,
                contrasenia = usuario.contrasenia
            };
        }

        public static Usuario ConvertirDTOAUsuario(UsuarioDTO usuarioDTO)
        {

            return new Usuario()
            {
                id = usuarioDTO.id,
                nombre = usuarioDTO.nombre,
                apellido = usuarioDTO.apellido,
                cedula = usuarioDTO.cedula,
                fechaNacimiento = usuarioDTO.fechaNacimiento,
                correo = usuarioDTO.correo,
                contrasenia = usuarioDTO.contrasenia
            };
        }

        public static IEnumerable<UsuarioDTO> ConvertirListaDeUsuarioADTO(IEnumerable<Usuario> usuarios)
        {

            IEnumerable<UsuarioDTO> usuarioDTO = usuarios.Select(t => new UsuarioDTO()
            {
                id = t.id,
                nombre = t.nombre,
                apellido = t.apellido,
                cedula = t.cedula,
                fechaNacimiento = t.fechaNacimiento,
                correo = t.correo,
                contrasenia = t.contrasenia
            }
            );
            return usuarioDTO;
        }
    }
}
