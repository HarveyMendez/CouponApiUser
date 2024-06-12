using AdmTarea.Api.DTOs;
using AdmTarea.Api.Utilitarios;
using AdmTarea.BC.Modelos;
using AdmTarea.BW.CU;
using AdmTarea.BW.Interfaces.BW;
using Microsoft.AspNetCore.Mvc;

namespace AdmTarea.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoController : Controller
    {
        private readonly IGestionarCarritoBW gestionarCarritoBW;

        public CarritoController(IGestionarCarritoBW gestionarCarritoBW)
        {
            this.gestionarCarritoBW = gestionarCarritoBW;
        }

        [HttpGet]
        public async Task<IEnumerable<CarritoDTO>> ObtenerTodasLosCarritos()
        {

            return CarritoDTOMapper.ConvertirListaDeCarritosADTO(await gestionarCarritoBW.obtengaTodasLosCarritos());
        }
        [HttpGet("{id}")]

        public async Task<CarritoDTO> ObtenerCarrito(int id)
        {
            return CarritoDTOMapper.ConvertirCarritoADTO(await gestionarCarritoBW.obtengaCarrito(id));
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> EditarCarrito(int id, CarritoDTO carritoDTO)
        {

            Carrito carrito = CarritoDTOMapper.ConvertirDTOACarrito(carritoDTO);

            var respuesta = await gestionarCarritoBW.actualiceCarrito(id, carrito);

            if (!respuesta)
                return BadRequest(respuesta);

            return Ok(respuesta);

        }

        [HttpPost]

        public async Task<ActionResult<bool>> RegistrarCarrito(CarritoDTO carritoDTO)
        {

            Carrito carrito = CarritoDTOMapper.ConvertirDTOACarrito(carritoDTO);

            var respuesta = gestionarCarritoBW.registreCarrito(carrito);

            return await respuesta;
        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> EliminarCarrito(int id)
        {

            var respuesta = await gestionarCarritoBW.elimineCarrito(id);

            if (!respuesta)
                return BadRequest(respuesta);

            return Ok(respuesta);

        }

    }
}
