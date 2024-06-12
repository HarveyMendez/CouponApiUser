using AdmTarea.BC.Modelos;
using AdmTarea.BW.Interfaces.DA;
using AdmTarea.DA.Contexto;
using Microsoft.EntityFrameworkCore;

namespace AdmTarea.DA.Acciones
{
    public class GestionarCarritoDA : IGestionarCarritoDA
    {
        private readonly CarritoContext carritoContext;

        public GestionarCarritoDA(CarritoContext _carritoContext)
        {
            carritoContext = _carritoContext;
        }

        public async Task<bool> actualiceCarrito(int id, Carrito carrito)
        {
            var carritoDA = carritoContext.CarritoDA.FirstOrDefault(c => c.id == id);

            if (carritoDA != null)
            {
                carritoDA.idCupon = carrito.idCupon;
                carritoDA.idUsario = carrito.idUsario;
                carritoDA.precioTotal = carrito.precioTotal;

                var resultado = await carritoContext.SaveChangesAsync();

                return resultado >= 0;
            }
            return false;
        }

        public async Task<bool> elimineCarrito(int id)
        {
            var carritoDA = carritoContext.CarritoDA.FirstOrDefault(c => c.id == id);

            if (carritoDA != null)
            {
                carritoContext.CarritoDA.Remove(carritoDA);
                var resultado = await carritoContext.SaveChangesAsync();

                return resultado > 0;
            }
            return false;
        }

        public async Task<Carrito> obtengaCarrito(int id)
        {
            var carritoDA = await carritoContext.CarritoDA.FirstOrDefaultAsync(c => c.id == id);

            if (carritoDA == null)
                return null;

            Carrito carrito = new()
            {
                id = carritoDA.id,
                idCupon = carritoDA.idCupon,
                idUsario = carritoDA.idUsario,
                precioTotal = carritoDA.precioTotal
            };

            return carrito;
        }

        public async Task<IEnumerable<Carrito>> obtengaTodasLosCarritos()
        {
            return await carritoContext.CarritoDA
                   .Select(carritoDA => new Carrito
                   {
                       id = carritoDA.id,
                       idCupon = carritoDA.idCupon,
                       idUsario = carritoDA.idUsario,
                       precioTotal = carritoDA.precioTotal
                   }).ToListAsync();
        }

        public async Task<bool> registreCarrito(Carrito carrito)
        {
            Entidades.CarritoDA carritoBD = new()
            {
                id = carrito.id,
                idCupon = carrito.idCupon,
                idUsario = carrito.idUsario,
                precioTotal = carrito.precioTotal
            };

            carritoContext.CarritoDA.Add(carritoBD);

            var resultado = await carritoContext.SaveChangesAsync();

            return resultado >= 0;
        }

    }
}

