using AdmTarea.BC.Modelos;
using AdmTarea.BC.ReglasDeNegocio;
using AdmTarea.BW.Interfaces.BW;
using AdmTarea.BW.Interfaces.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmTarea.BW.CU
{
    public class GestionarUsuarioBW : IGestionarUsuarioBW
    {
        private readonly IGestionarUsuarioDA gestionarUsuarioDA;

        public GestionarUsuarioBW(IGestionarUsuarioDA gestionarUsuarioDA)
        {
            this.gestionarUsuarioDA = gestionarUsuarioDA;
        }

        public async Task<bool> registreUsuario(Usuario usuario)
        {
            (bool esValido, string mensaje) validacionReglaDeUsuario = ReglasUsuario.ElUsuarioEsValido(usuario);

            if (!validacionReglaDeUsuario.esValido)
            {
                return false;
            }

            return await gestionarUsuarioDA.registreUsuario(usuario);
        }

        public async Task<bool> actualiceUsuario(int id, Usuario usuario)
        {
            (bool esValido, string mensaje) validacionReglaDeUsuario = ReglasUsuario.ElUsuarioEsValido(usuario);

            (bool esValido, string mensaje) validacionReglaDeId = ReglasUsuario.ElIdEsValido(id);

            if (!validacionReglaDeUsuario.esValido && !validacionReglaDeId.esValido)
            {
                return false;
            }

            return await gestionarUsuarioDA.actualiceUsuario(id, usuario);
        }

        public async Task<bool> elimineUsuario(int id)
        {
            (bool esValido, string mensaje) validacionReglaDeId = ReglasUsuario.ElIdEsValido(id);

            if (!validacionReglaDeId.esValido)
            {
                return false;
            }

            return await gestionarUsuarioDA.elimineUsuario(id);
        }

        public async Task<Usuario> obtengaUsuario(int id)
        {
            (bool esValido, string mensaje) validacionReglaDeId = ReglasUsuario.ElIdEsValido(id);

            if (!validacionReglaDeId.esValido)
            {
                return null;
            }

            return await gestionarUsuarioDA.obtengaUsuario(id);
        }

        public async Task<IEnumerable<Usuario>> obtengaTodasLosUsuarios()
        {
            return await gestionarUsuarioDA.obtengaTodasLosUsuarios();
        }

        public async Task<Usuario> Login(Usuario registroDTO)
        {
            if (registroDTO == null || string.IsNullOrEmpty(registroDTO.correo) || string.IsNullOrEmpty(registroDTO.contrasenia))
            {
                throw new ArgumentException("Solicitud inválida");
            }

            var usuario = await gestionarUsuarioDA.Login(registroDTO);

            if (usuario == null)
            {
                throw new UnauthorizedAccessException("Correo o contraseña incorrectos");
            }

            return usuario;
        }
    }
}
