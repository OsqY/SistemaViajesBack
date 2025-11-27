using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Viajes
{
    public class UpdateViajeDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "La fecha es un campo obligatorio.")]
        public DateOnly Fecha { get; set; }
        [Required(ErrorMessage = "El Transportista es un campo obligatorio.")]
        public int TransportistaId { get; set; }
    }
}
