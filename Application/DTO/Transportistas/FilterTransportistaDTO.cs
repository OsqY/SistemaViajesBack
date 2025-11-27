using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Transportistas
{
    public class FilterTransportistaDTO : FilterDTO
    {
        private string? _nombre;
        public string? NombreFilter { get { return _nombre?.ToLower(); } set { _nombre = value; } }
        public string? ApellidosFilter { get; set; } = null;

    }
}
