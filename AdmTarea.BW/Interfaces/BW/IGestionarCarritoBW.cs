using AdmTarea.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmTarea.BW.Interfaces.BW
{
    public interface IGestionarCarritoBW
    {
         Task<bool> registreCarrito(Carrito carrito);
         Task<bool> actualiceCarrito(int id, Carrito carrito);
         Task<bool> elimineCarrito(int id);
         Task<IEnumerable<Carrito>> obtengaTodasLosCarritos();
         Task<Carrito> obtengaCarrito(int id);
    }
}
