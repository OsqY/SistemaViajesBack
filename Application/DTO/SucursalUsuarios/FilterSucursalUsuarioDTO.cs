using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.SucursalUsuarios
{
    public class FilterSucursalUsuarioDTO : FilterDTO
    {
        public int SucursalId { get; set; }
        public string? UsuarioId { get; set; }
        public double? MinDistancia { get; set; }
        public double? MaxDistancia { get; set; }
    }
}
