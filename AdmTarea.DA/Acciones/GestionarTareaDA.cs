
using AdmTarea.BC.Modelos;
using AdmTarea.BW.Interfaces.DA;
using AdmTarea.DA.Contexto;
using Microsoft.EntityFrameworkCore;


namespace AdmTarea.DA.Acciones
{
    public class GestionarTareaDA : IGestionarTareaDA
    {

        private readonly AdmTareaContext admTareaContext;
        public GestionarTareaDA(AdmTareaContext _admTareaContext)
        {
            admTareaContext = _admTareaContext;
        }
        public async Task<bool> actualiceTarea(long id, Tarea tarea)
        {
            var tareaDA = admTareaContext.TareaDA.FirstOrDefault(t => t.id == id);

            if (tareaDA != null)
            {
                tareaDA.nombre = tarea.nombre;
                tareaDA.estaListo = tarea.estaListo;
                tareaDA.secreto = tarea.secreto;

                var resultado = await admTareaContext.SaveChangesAsync();

                return resultado >= 0 ? true : false;
            }
            return false;
        }

        public async Task<bool> elimineTarea(long id)
        {
            var tareaDA = admTareaContext.TareaDA.FirstOrDefault(t => t.id == id);

            if (tareaDA != null)
            {
                admTareaContext.TareaDA.Remove(tareaDA);
                var resultado =  await admTareaContext.SaveChangesAsync();

                if (resultado > 0)
                    return true;
            }
            return false;
        }

        public async Task<Tarea> obtengaTarea(long id)
        {
    
            var tareaDA = await admTareaContext.TareaDA.FirstOrDefaultAsync(t => t.id == id);

            if (tareaDA is null) 
                return null; 
            

            Tarea tarea = new()
            {
                id = tareaDA.id,
                nombre = tareaDA.nombre, 
                estaListo = tareaDA.estaListo, 
                secreto = tareaDA.secreto
            };

            return tarea;
        }

        public async Task<IEnumerable<Tarea>>  obtengaTodasLasTareas()
        {

           return await admTareaContext.TareaDA
                  .Select(tareaDA => new Tarea
                  {
                      id = tareaDA.id,
                      nombre = tareaDA.nombre,
                      estaListo = tareaDA.estaListo,
                      secreto = tareaDA.secreto

                  }).ToListAsync();
        }

        public async Task<bool> registreTarea(Tarea tarea)
        {
            Entidades.TareaDA tareaBD = new()
           {
               id = tarea.id,
               nombre = tarea.nombre,
               estaListo = tarea.estaListo, 
               secreto = tarea.secreto
           };

            admTareaContext.TareaDA.Add(tareaBD);

            var resultado = await admTareaContext.SaveChangesAsync();

            return resultado >= 0 ? true : false;

            return true;

        }
    }
}
