using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.SucursalUsuarios
{
    public class SucursalUsuarioDTO
    {
        public int SucursalId { get; set; }
        public string NombreSucursal { get; set; }
        public string UsuarioId { get; set; }
        public string UsuarioEmail { get; set; }
        public double Distancia { get; set; }
    }
}
