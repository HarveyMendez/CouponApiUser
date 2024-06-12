using AdmTarea.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdmTarea.BC.ReglasDeNegocio
{
    public static class ReglasCarrito
    {
        public static (bool, string) ElCarritoEsValido(Carrito carrito)
        {
            if (carrito.id <= 0)
                return (false, "El carrito no es válido debido a que el ID es menor o igual a cero.");

            if (carrito.idCupon < 0)
                return (false, "El carrito no es válido debido a que el ID del Cupón es menor a cero.");

            if (carrito.idUsario <= 0)
                return (false, "El carrito no es válido debido a que el ID del Usuario es menor o igual a cero.");

            if (carrito.precioTotal < 0)
                return (false, "El carrito no es válido debido a que el Precio Total es menor a cero.");

            return (true, string.Empty);

        }
        public static (bool, string) ElIdEsValido(int id)
        {
            if (id <= 0)
            {
                return (false, "El ID no es válido porque es igual o menor a cero.");
            }
            return (true, string.Empty);
        }
    }
}
