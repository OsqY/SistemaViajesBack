using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SucursalUsuario
    {
        public int SucursalId { get; set; }
        public Sucursal Sucursal { get; set; }
        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        [Range(1, 50)]
        public double Distancia { get; set; }
    }
}
