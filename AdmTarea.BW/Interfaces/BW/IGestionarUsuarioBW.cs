using AdmTarea.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmTarea.BW.Interfaces.BW
{
    public interface IGestionarUsuarioBW
    {
         Task<bool> registreUsuario(Usuario usuario);
         Task<bool> actualiceUsuario(int id, Usuario usuario);
         Task<bool> elimineUsuario(int id);
         Task<IEnumerable<Usuario>> obtengaTodasLosUsuarios();
         Task<Usuario> obtengaUsuario(int id);
         Task<Usuario> Login(Usuario usuario);
    }
}
