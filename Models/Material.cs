using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebAppControlCursos.Models
{
	public class Material
	{
		[Key]
		[Required]
		[Display(Name = "MaterialId")]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		public int CourseId { get; set; }

		[ForeignKey("CourseId")]
		public Course Course { get; set; }

		[Required(ErrorMessage = "El nombre es requerido")]
		[Display(Name = "Nombre")]
		[MaxLength(150)]
		public string Name { get; set; }

		[MaxLength(500, ErrorMessage = "El numero maximo de caracteres permitido es 500")]
		[Required]
		[Display(Name = "Descripcion")]
		public string Description { get; set; }
	}
}
