using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Transportistas
{
    public class CreateTransportistaDTO
    {
        [Required(ErrorMessage = "El nombre del  es un campo requerido.")]
        [MinLength(2, ErrorMessage = "El nombre  tiene que tener un mínimo de 2 caracteres.")]
        [MaxLength(40, ErrorMessage = "El nombre  tiene que tener un máximo de 40 caracteres.")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "Los apellidos es un campo obligatorio.")]
        [MinLength(2, ErrorMessage = "Los apellidos tienen que tener un mínimo de 2 caracteres.")]
        [MaxLength(40, ErrorMessage = "Los apellidos tienen que tener un máximo de 40 caracteres.")]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "La descripción es un campo requerido.")]
        public string Descripcion { get; set; }
    }
}
