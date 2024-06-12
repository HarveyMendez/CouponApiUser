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
    public class UsuarioController : Controller
    {
        private readonly IGestionarUsuarioBW gestionarUsuarioBW;

        public UsuarioController(IGestionarUsuarioBW gestionarUsuarioBW)
        {
            this.gestionarUsuarioBW = gestionarUsuarioBW;
        }

        [HttpGet]
        public async Task<IEnumerable<UsuarioDTO>> ObtenerTodasLosUsuarios()
        {

            return UsuarioDTOMapper.ConvertirListaDeUsuarioADTO(await gestionarUsuarioBW.obtengaTodasLosUsuarios());
        }

        [HttpGet("{id}")]

        public async Task<UsuarioDTO> ObtenerUsuario(int id)
        {
            return UsuarioDTOMapper.ConvertirUsuarioADTO(await gestionarUsuarioBW.obtengaUsuario(id));
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> EditarUsuario(int id, UsuarioDTO usuarioDTO)
        {

            Usuario usuario = UsuarioDTOMapper.ConvertirDTOAUsuario(usuarioDTO);

            var respuesta = await gestionarUsuarioBW.actualiceUsuario(id, usuario);

            if (!respuesta)
                return BadRequest(respuesta);

            return Ok(respuesta);

        }

        [HttpPost("Registrar")]

        public async Task<ActionResult<bool>> RegistrarUsuario(UsuarioDTO usuarioDTO)
        {

            Usuario usuario = UsuarioDTOMapper.ConvertirDTOAUsuario(usuarioDTO);

            var respuesta = gestionarUsuarioBW.registreUsuario(usuario);

            return await respuesta;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<Usuario>> Login([FromBody] Usuario registroDTO)
        {
            try
            {
                var usuario = await gestionarUsuarioBW.Login(new Usuario
                {
                    correo = registroDTO.correo,
                    contrasenia = registroDTO.contrasenia
                });

                return Ok(usuario);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
        }



        [HttpDelete("{id}")]

        public async Task<IActionResult> EliminarUsuario(int id)
        {

            var respuesta = await gestionarUsuarioBW.elimineUsuario(id);

            if (!respuesta)
                return BadRequest(respuesta);

            return Ok(respuesta);

        }
    }
}
