using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Viajes
{
    public class ViajeDTO
    {
        public int Id { get; set; }
        public decimal TarifaTotal { get; set; }
        public double DistanciaTotal { get; set; }

        public DateOnly Fecha { get; set; }
        public int? TransportistaId { get; set; }
        public string? TransportistaNombre { get; set; }
        public int? SucursalId { get; set; }
        public string? SucursalNombre { get; set; }
    }
}
