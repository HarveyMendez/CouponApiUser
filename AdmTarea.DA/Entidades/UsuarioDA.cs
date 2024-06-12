using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmTarea.DA.Entidades
{
    [Table("Usurio")]
    public class UsuarioDA
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public string nombre { get; set; }

        [Required]
        public string apellido { get; set; }

        [Required]
        public string cedula { get; set; }

        [Required]
        public string fechaNacimiento { get; set; }

        [Required]
        public string correo { get; set; }

        [Required]
        public string contrasenia { get; set; }
    }
}
