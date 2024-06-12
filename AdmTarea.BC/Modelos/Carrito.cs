using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmTarea.BC.Modelos
{
    public class Carrito
    {
        public int id { get; set; }
        public int idCupon { get; set;}
        public int idUsario { get; set;}
        public float precioTotal { get; set; }
    }
}
