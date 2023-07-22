using System.ComponentModel.DataAnnotations;

namespace WebAppControlCursos.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [MaxLength(500, ErrorMessage ="El numero maximo de caracteres permitido es 500")]
        [Display(Name = "Descripcion")]
        public string Description { get; set; }

		[Required(ErrorMessage = "El(La) docente es requerido(a)")]
		[Display(Name = "Docente")]
		public string Teacher { get; set; }

        [Url(ErrorMessage = "La direccion no es valida")]
        [Display(Name = "Url")]
        [Required]
        public string Uri { get; set; }
    }
}
