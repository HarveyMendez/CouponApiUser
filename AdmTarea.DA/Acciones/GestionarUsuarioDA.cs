using AdmTarea.BC.Modelos;
using AdmTarea.BW.Interfaces.DA;
using AdmTarea.DA.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmTarea.DA.Acciones
{
    public class GestionarUsuarioDA : IGestionarUsuarioDA
    {

        private readonly UsuarioContext usuarioContext;
        public GestionarUsuarioDA(UsuarioContext _usuarioContext)
        {
            usuarioContext = _usuarioContext;
        }
        public async Task<bool> actualiceUsuario(int id, Usuario usuario)
        {
            var usuarioDA = usuarioContext.UsuarioDA.FirstOrDefault(u => u.id == id);

            if (usuarioDA != null)
            {
                usuarioDA.nombre = usuario.nombre;
                usuarioDA.apellido = usuario.apellido;
                usuarioDA.cedula = usuario.cedula;
                usuarioDA.fechaNacimiento = usuario.fechaNacimiento;
                usuarioDA.correo = usuario.correo;
                usuarioDA.contrasenia = usuario.contrasenia;

                var resultado = await usuarioContext.SaveChangesAsync();

                return resultado >= 0;
            }
            return false;
        }

        public async Task<bool> elimineUsuario(int id)
        {
            var usuarioDA = usuarioContext.UsuarioDA.FirstOrDefault(u => u.id == id);

            if (usuarioDA != null)
            {
                usuarioContext.UsuarioDA.Remove(usuarioDA);
                var resultado = await usuarioContext.SaveChangesAsync();

                return resultado > 0;
            }
            return false;
        }

        public async Task<Usuario> obtengaUsuario(int id)
        {
            var usuarioDA = await usuarioContext.UsuarioDA.FirstOrDefaultAsync(u => u.id == id);

            if (usuarioDA == null)
                return null;

            Usuario usuario = new()
            {
                id = usuarioDA.id,
                nombre = usuarioDA.nombre,
                apellido = usuarioDA.apellido,
                cedula = usuarioDA.cedula,
                fechaNacimiento = usuarioDA.fechaNacimiento,
                correo = usuarioDA.correo,
                contrasenia = usuarioDA.contrasenia
            };

            return usuario;
        }

        public async Task<IEnumerable<Usuario>> obtengaTodasLosUsuarios()
        {
            return await usuarioContext.UsuarioDA
                   .Select(usuarioDA => new Usuario
                   {
                       id = usuarioDA.id,
                       nombre = usuarioDA.nombre,
                       apellido = usuarioDA.apellido,
                       cedula = usuarioDA.cedula,
                       fechaNacimiento = usuarioDA.fechaNacimiento,
                       correo = usuarioDA.correo,
                       contrasenia = usuarioDA.contrasenia
                   }).ToListAsync();
        }

        public async Task<bool> registreUsuario(Usuario usuario)
        {
            Entidades.UsuarioDA usuarioBD = new()
            {
                nombre = usuario.nombre,
                apellido = usuario.apellido,
                cedula = usuario.cedula,
                fechaNacimiento = usuario.fechaNacimiento,
                correo = usuario.correo,
                contrasenia = usuario.contrasenia
            };

            usuarioContext.UsuarioDA.Add(usuarioBD);

            var resultado = await usuarioContext.SaveChangesAsync();

            return resultado >= 0;
        }

        public async Task<Usuario> Login(Usuario usuario)
        {
            var usuarioDA = await usuarioContext.UsuarioDA.FirstOrDefaultAsync(u => u.correo == usuario.correo && u.contrasenia == usuario.contrasenia);

            if (usuarioDA == null)
                return null;

            return new Usuario
            {
                id = usuarioDA.id,
                nombre = usuarioDA.nombre,
                apellido = usuarioDA.apellido,
                cedula = usuarioDA.cedula,
                fechaNacimiento = usuarioDA.fechaNacimiento,
                correo = usuarioDA.correo,
                contrasenia = usuarioDA.contrasenia
            };
        }

    }
}
