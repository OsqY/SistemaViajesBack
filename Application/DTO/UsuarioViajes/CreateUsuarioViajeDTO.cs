using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.UsuarioViajes
{
    public class CreateUsuarioViajeDTO
    {
        public decimal Tarifa { get; set; }
        [Range(1, 100)]
        public double Distancia { get; set; }
        public DateOnly Fecha { get; set; }
        [Required(ErrorMessage = "El usuario es obligatorio.")]
        public string UsuarioId { get; set; }
        [Required(ErrorMessage = "El viaje es obligatorio.")]
        public int ViajeId { get; set; }
        public string CreatorUserId { get; set; }
    }
}
