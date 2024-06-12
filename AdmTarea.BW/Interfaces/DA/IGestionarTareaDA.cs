using AdmTarea.BC.Modelos;

namespace AdmTarea.BW.Interfaces.DA
{
    public interface IGestionarTareaDA
    {
        public Task<bool> registreTarea(Tarea tarea);
        public Task<bool> actualiceTarea(long id, Tarea tarea);
        public Task<bool> elimineTarea(long id);
        public Task<IEnumerable<Tarea>> obtengaTodasLasTareas();
        public Task<Tarea> obtengaTarea(long id);
    }
}
