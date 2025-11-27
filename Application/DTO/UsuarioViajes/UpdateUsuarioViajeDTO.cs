using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.UsuarioViajes
{
    public class UpdateUsuarioViajeDTO
    {
        public decimal Tarifa { get; set; }
        [Range(1, 100)]
        public double Distancia { get; set; }
        [Required(ErrorMessage = "El usuario es campo obligatorio.")]
        public string UsuarioId { get; set; }
        [Required(ErrorMessage = "El viaje es un campo obligatorio.")]
        public int ViajeId { get; set; }
    }
}
