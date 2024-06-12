using AdmTarea.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmTarea.BW.Interfaces.BW
{
    public interface IGestionarTareaBW
    {
        Task<bool> registreTarea(Tarea tarea);
        Task<bool> actualiceTarea(long id, Tarea tarea);
        Task<bool> elimineTarea(long id);
        Task<IEnumerable<Tarea>> obtengaTodasLasTareas();
        Task<Tarea> obtengaTarea( long id);
    }
}
