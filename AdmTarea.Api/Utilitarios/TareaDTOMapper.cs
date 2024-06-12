using AdmTarea.Api.DTOs;
using AdmTarea.BC.Modelos;
using System.Collections.Generic;


namespace AdmTarea.Api.Utilitarios
{
    public  static class TareaDTOMapper
    {

        public static TareaDTO ConvertirTareaADTO(Tarea tarea)
        {
            return new TareaDTO()
            {
                estaListo = tarea.estaListo,
                id = tarea.id,
                nombre = tarea.nombre,
                secreto = tarea.secreto
            };
        }

        public static Tarea ConvertirDTOATarea(TareaDTO tareaDTO)
        {

            return new Tarea()
            {
                estaListo = tareaDTO.estaListo,
                id = tareaDTO.id,
                nombre = tareaDTO.nombre,
                secreto = tareaDTO.secreto
            };
        }

        public static IEnumerable<TareaDTO> ConvertirListaDeTareasADTO(IEnumerable<Tarea> tareas)
        {

            IEnumerable<TareaDTO> tareasDTO = tareas.Select(t => new TareaDTO()
            {
                secreto = t.secreto,
                estaListo = t.estaListo,
                nombre = t.nombre,
                id = t.id
            }
            );
            return tareasDTO;
        }
    }
}
