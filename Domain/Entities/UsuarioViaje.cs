using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UsuarioViaje
    {
        public decimal Tarifa { get; set; }
        [MinLength(1)]
        [MaxLength(50)]
        public double Distancia { get; set; }
        public DateOnly Fecha { get; set; }
        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int ViajeId { get; set; }
        public Viaje Viaje { get; set; }
        public string CreatorUserId { get; set; }
        public Usuario CreatorUser { get; set; }

    }
}
