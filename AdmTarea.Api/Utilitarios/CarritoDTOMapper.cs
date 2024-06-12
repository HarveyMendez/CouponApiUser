using AdmTarea.Api.DTOs;
using AdmTarea.BC.Modelos;
using AdmTarea.DA.Entidades;

namespace AdmTarea.Api.Utilitarios
{
    public static class CarritoDTOMapper
    {
        public static CarritoDTO ConvertirCarritoADTO(Carrito carrito)
        {
            return new CarritoDTO()
            {
                id = carrito.id,
                idCupon = carrito.idCupon,
                idUsario = carrito.idUsario,
                precioTotal = carrito.precioTotal,

            };
        }

        public static Carrito ConvertirDTOACarrito(CarritoDTO carritoDTO)
        {

            return new Carrito()
            {
                id = carritoDTO.id,
                idCupon = carritoDTO.idCupon,
                idUsario = carritoDTO.idUsario,
                precioTotal = carritoDTO.precioTotal,
            };
        }

        public static IEnumerable<CarritoDTO> ConvertirListaDeCarritosADTO(IEnumerable<Carrito> carritos)
        {

            IEnumerable<CarritoDTO> carritoDTO = carritos.Select(t => new CarritoDTO()
            {
                id = t.id,
                idCupon = t.idCupon,
                idUsario = t.idUsario,
                precioTotal = t.precioTotal,
            }
            );
            return carritoDTO;
        }
    }
}

