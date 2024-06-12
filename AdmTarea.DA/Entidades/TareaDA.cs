using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdmTarea.DA.Entidades
{
    [Table("AdmTarea")]
    public class TareaDA
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public long id { get; set; }

        [Required]
        public string nombre { get; set; }
   
        [Required]
        public bool estaListo { get; set; }

        public string? secreto { get; set; }

    }
}
