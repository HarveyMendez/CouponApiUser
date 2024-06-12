using AdmTarea.BC.Modelos;

namespace AdmTarea.BC.ReglasDeNegocio
{
    public  static class ReglasTarea
    {
        public static (bool, string) LaTareaEsValida(Tarea tarea)
        {
            if (tarea.id < 0)
                return (false, "La tarea no es válida debido a que el ID es igual o menor a cero.");

            if (tarea.nombre is null)
                return (false, "La tarea no es válida debid a que el Nombre es nulo.");

            if (tarea.nombre.Equals(String.Empty))
                return (false, "La tarea no es válida debid a que el Nombre es nulo.");

            return (true, string.Empty);
        }

        public static (bool, string) ElIdEsValido(long id)
        {
            if (id < 0)
                return (false, "La tarea no es válida debido a que el ID es igual o menor a cero.");

            return (true, string.Empty);
        }
    }
}
