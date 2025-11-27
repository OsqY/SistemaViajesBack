using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Viajes
{
    public class FilterViajeDTO : FilterDTO
    {
        public decimal? MinTarifaTotal { get; set; }
        public decimal? MaxTarifaTotal { get; set; }
        public double? MinDistanciaTotal { get; set; }
        public double? MaxDistanciaTotal { get; set; }

        public DateOnly? MinFecha { get; set; }
        public DateOnly? MaxFecha { get; set; }
        public int? TransportistaId { get; set; }
        public int? SucursalId { get; set; }

    }
}
