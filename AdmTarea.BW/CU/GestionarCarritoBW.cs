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
    public class GestionarCarritoBW : IGestionarCarritoBW
    {
        private readonly IGestionarCarritoDA gestionarCarritoDA;

        public GestionarCarritoBW(IGestionarCarritoDA gestionarCarritoDA)
        {
            this.gestionarCarritoDA = gestionarCarritoDA;
        }

        public async Task<bool> registreCarrito(Carrito carrito)
        {
            (bool esValido, string mensaje) validacionReglaDeCarrito = ReglasCarrito.ElCarritoEsValido(carrito);

            if (!validacionReglaDeCarrito.esValido)
            {
                return false;
            }

            return await gestionarCarritoDA.registreCarrito(carrito);
        }

        public async Task<bool> actualiceCarrito(int id, Carrito carrito)
        {
            (bool esValido, string mensaje) validacionReglaDeCarrito = ReglasCarrito.ElCarritoEsValido(carrito);

            (bool esValido, string mensaje) validacionReglaDeId = ReglasCarrito.ElIdEsValido(id);

            if (!validacionReglaDeCarrito.esValido || !validacionReglaDeId.esValido)
            {
                return false;
            }

            return await gestionarCarritoDA.actualiceCarrito(id, carrito);
        }

        public async Task<bool> elimineCarrito(int id)
        {
            (bool esValido, string mensaje) validacionReglaDeId = ReglasCarrito.ElIdEsValido(id);

            if (!validacionReglaDeId.esValido)
            {
                return false;
            }

            return await gestionarCarritoDA.elimineCarrito(id);
        }

        public async Task<Carrito> obtengaCarrito(int id)
        {
            (bool esValido, string mensaje) validacionReglaDeId = ReglasCarrito.ElIdEsValido(id);

            if (!validacionReglaDeId.esValido)
            {
                return null;
            }

            return await gestionarCarritoDA.obtengaCarrito(id);
        }

        public async Task<IEnumerable<Carrito>> obtengaTodasLosCarritos()
        {
            return await gestionarCarritoDA.obtengaTodasLosCarritos();
        }
    }
}
