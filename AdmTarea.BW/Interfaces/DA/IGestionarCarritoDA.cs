using AdmTarea.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmTarea.BW.Interfaces.DA
{
    public interface IGestionarCarritoDA
    {
        public Task<bool> registreCarrito(Carrito carrito);
        public Task<bool> actualiceCarrito(int id, Carrito carrito);
        public Task<bool> elimineCarrito(int id);
        public Task<IEnumerable<Carrito>> obtengaTodasLosCarritos();
        public Task<Carrito> obtengaCarrito(int id);
    }
}
