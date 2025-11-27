using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.UsuarioViajes
{
    public class UsuarioViajeDTO
    {
        public decimal Tarifa { get; set; }
        public double Distancia { get; set; }
        public DateOnly Fecha { get; set; }
        public string UsuarioId { get; set; }
        public string UsuarioEmail { get; set; }
        public int ViajeId { get; set; }
    }
}
