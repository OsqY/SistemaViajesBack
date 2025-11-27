using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.SucursalUsuarios
{
    public class UpdateSucursalUsuarioDTO
    {
        [Required(ErrorMessage = "La Sucursal es obligatoria.")]
        public int SucursalId { get; set; }
        [Required(ErrorMessage = "El Usuario es obligatorio.")]
        public string UsuarioId { get; set; }
        [Range(1, 50, ErrorMessage = "La distancia debe estar entre 1 y 50.")]
        public double Distancia { get; set; }
    }
}
