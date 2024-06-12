using AdmTarea.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdmTarea.BC.ReglasDeNegocio
{
    public static class ReglasUsuario
    {
        public static (bool, string) ElUsuarioEsValido(Usuario usuario)
        {
            if (usuario.id < 0)
                return (false, "El usuario no es válido debido a que el ID es igual o menor a cero.");

            if (string.IsNullOrEmpty(usuario.nombre))
                return (false, "El usuario no es válido debido a que el Nombre es nulo o vacío.");

            if (usuario.nombre.Length > 11)
                return (false, "El usuario no es válido debido a que el Nombre supera los 11 caracteres.");

            if (string.IsNullOrEmpty(usuario.apellido))
                return (false, "El usuario no es válido debido a que el Apellido es nulo o vacío.");

            if (usuario.apellido.Length > 30)
                return (false, "El usuario no es válido debido a que el Apellido supera los 30 caracteres.");

            if (!Regex.IsMatch(usuario.cedula, @"^\d{2}-\d{4}-\d{4}$"))
                return (false, "El usuario no es válido debido a que la Cédula no cumple con la máscara 00-0000-0000.");

            if (usuario.fechaNacimiento == default)
                return (false, "El usuario no es válido debido a que la Fecha de nacimiento no es válida.");

            if (!Regex.IsMatch(usuario.correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                return (false, "El usuario no es válido debido a que el Correo electrónico no cumple con la máscara joshua@gmail.com");

            if (usuario.contrasenia.Length < 8)
                return (false, "El usuario no es válido debido a que la Contraseña no tiene al menos 8 caracteres.");

            if (!Regex.IsMatch(usuario.contrasenia, @"[A-Z]"))
                return (false, "El usuario no es válido debido a que la Contraseña no tiene al menos una letra mayúscula.");

            if (!Regex.IsMatch(usuario.contrasenia, @"[a-z]"))
                return (false, "El usuario no es válido debido a que la Contraseña no tiene al menos una letra minúscula.");

            if (!Regex.IsMatch(usuario.contrasenia, @"\d"))
                return (false, "El usuario no es válido debido a que la Contraseña no tiene al menos un número.");

            if (!Regex.IsMatch(usuario.contrasenia, @"[!@#$%^&*]"))
                return (false, "El usuario no es válido debido a que la Contraseña no tiene al menos un carácter especial (!, @, #, $, %, ^, &, *).");

            return (true, string.Empty);

        }
        public static (bool, string) ElIdEsValido(int id)
        {
            if (id <= 0)
            {
                return (false, "El ID no es válido porque es igual o menor a cero.");
            }
            return (true, string.Empty);
        }
    }
}
