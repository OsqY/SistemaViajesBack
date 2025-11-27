using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.UsuarioViajes
{
    public class FilterUsuarioViajeDTO : FilterDTO
    {
        public decimal? MinTarifa { get; set; }
        public decimal? MaxTarifa { get; set; }
        public double? MinDistancia { get; set; }
        public double? MaxDistancia { get; set; }
        public DateOnly? Fecha { get; set; }
        public DateOnly? MaxFecha { get; set; }
        public string? UsuarioId { get; set; }
        public int ViajeId { get; set; }

    }
}
