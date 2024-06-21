using System.ComponentModel.DataAnnotations;

namespace T2_ESCATE_ALEXANDER.Models
{
    public class Distribuidor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de distribuidor es obligatorio")]
        public string NombreDistribuidor { get; set; }

        [Required(ErrorMessage = "La razón social es obligatoria")]
        public string RazonSocial { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El año de inicio de operación es obligatorio")]
        [Range(1900, 3000, ErrorMessage = "El año de inicio de operación debe ser entre 1900 y 3000")]
        public int Año { get; set; }

        [Required(ErrorMessage = "El contacto es obligatorio")]
        public string Contacto { get; set; }

        [Required(ErrorMessage = "El país es obligatorio")]
        public string Pais { get; set; }
    }
}
