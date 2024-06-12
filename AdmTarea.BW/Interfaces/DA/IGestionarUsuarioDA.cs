using AdmTarea.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmTarea.BW.Interfaces.DA
{
    public interface IGestionarUsuarioDA
    {
        public Task<bool> registreUsuario (Usuario usuario);
        public Task<bool> actualiceUsuario(int id, Usuario usuario);
        public Task<bool> elimineUsuario(int id);
        public Task<IEnumerable<Usuario>> obtengaTodasLosUsuarios();
        public Task<Usuario> obtengaUsuario(int id);
        public Task<Usuario> Login(Usuario usuario);

    }
}
