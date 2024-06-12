using AdmTarea.Api.DTOs;
using AdmTarea.Api.Utilitarios;
using AdmTarea.BC.Modelos;
using AdmTarea.BW.Interfaces.BW;
using Microsoft.AspNetCore.Mvc;

namespace AdmTarea.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase

    { 
        private readonly IGestionarTareaBW gestionarTareaBW;

        public TareaController(IGestionarTareaBW gestionarTareaBW) 
        {     
            this.gestionarTareaBW = gestionarTareaBW;
        }


        [HttpGet]

        public async Task<IEnumerable<TareaDTO>>  ObtenerTodasLasTareas()
        {

           return TareaDTOMapper.ConvertirListaDeTareasADTO(await gestionarTareaBW.obtengaTodasLasTareas());
        }


        [HttpGet("{id}")]

        public async Task<TareaDTO> ObtenerTarea(long id)
        {
            return TareaDTOMapper.ConvertirTareaADTO (await gestionarTareaBW.obtengaTarea(id));
        }
        

        [HttpPut("{id}")]

        public async Task<IActionResult> EditarTarea(long id, TareaDTO tareaDTO)
        {

            Tarea tarea = TareaDTOMapper.ConvertirDTOATarea(tareaDTO);

            var respuesta = await gestionarTareaBW.actualiceTarea(id, tarea);

            if(!respuesta)
                return BadRequest(respuesta);

            return Ok(respuesta);


        }

        
        [HttpPost]

        public async Task<ActionResult<bool>> RegistrarTarea(TareaDTO tareaDTO)
        {

            Tarea tarea = TareaDTOMapper.ConvertirDTOATarea(tareaDTO);

            var respuesta = gestionarTareaBW.registreTarea(tarea);

            return await respuesta;
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> EliminarTarea(long id)
        {

            var respuesta = await gestionarTareaBW.elimineTarea(id);

            if (!respuesta)
                return BadRequest(respuesta);

            return Ok(respuesta);
 
        }

    }
}
