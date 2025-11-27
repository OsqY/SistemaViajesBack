using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Sucursales
{
    public class FilterSucursalDTO : FilterDTO
    {
        private string? _nombre;
        private string? _direccion;
        public string? NombreFilter { get { return _nombre?.ToLower(); } set { _nombre = value; } }
        public string? DireccionFilter { get { return _direccion?.ToLower(); } set { _direccion = value; } }
    }
}
