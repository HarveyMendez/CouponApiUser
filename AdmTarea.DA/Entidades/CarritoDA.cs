using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmTarea.DA.Entidades
{
    [Table("Carrito")]

    public class CarritoDA
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        public int idCupon { get; set; }
        public int idUsario { get; set; }
        public float precioTotal { get; set; }
    }
}
