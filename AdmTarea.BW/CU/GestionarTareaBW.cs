using AdmTarea.BC.Modelos;
using AdmTarea.BC.ReglasDeNegocio;
using AdmTarea.BW.Interfaces.BW;
using AdmTarea.BW.Interfaces.DA;
namespace AdmTarea.BW.CU
{
    public class GestionarTareaBW : IGestionarTareaBW
    {
        private readonly IGestionarTareaDA gestionarTareaDA;
        public GestionarTareaBW(IGestionarTareaDA gestionarTareaDA) 
        { 
            this.gestionarTareaDA = gestionarTareaDA; 
        }

        public async Task<bool> registreTarea(Tarea tarea)
        {
            (bool esValido, string mensaje) validacionReglaDeTarea = ReglasTarea.LaTareaEsValida(tarea);

            if (!validacionReglaDeTarea.esValido)
            {
                return false;
            }

             return await gestionarTareaDA.registreTarea(tarea);
        }
        public async Task<bool> actualiceTarea(long id, Tarea tarea)
        {
            (bool esValido, string mensaje) validacionReglaDeTarea = ReglasTarea.LaTareaEsValida(tarea);

            (bool esValido, string mensaje) validacionReglaDeId = ReglasTarea.ElIdEsValido(id);

            if (!validacionReglaDeTarea.esValido && !validacionReglaDeId.esValido)
            {
                return false;
            }

            return await gestionarTareaDA.actualiceTarea(id, tarea);

        }

        public async Task<bool> elimineTarea(long id)
        {
        
            (bool esValido, string mensaje) validacionReglaDeId = ReglasTarea.ElIdEsValido(id);

            if ( !validacionReglaDeId.esValido)
            {
                return false;
            }

            return await gestionarTareaDA.elimineTarea(id);

        }

        public async Task<Tarea> obtengaTarea(long id)
        {
            
            (bool esValido, string mensaje) validacionReglaDeId = ReglasTarea.ElIdEsValido(id);

            if (!validacionReglaDeId.esValido)
            {
                return null;
            }

            return await gestionarTareaDA.obtengaTarea(id);

          
        }

        public async Task<IEnumerable<Tarea>>  obtengaTodasLasTareas()
        {
            return await gestionarTareaDA.obtengaTodasLasTareas();
        }

    
    }
}
