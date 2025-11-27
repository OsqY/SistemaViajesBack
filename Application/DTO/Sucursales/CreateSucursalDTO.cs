using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Sucursales
{
    public class CreateSucursalDTO
    {
        [Required(ErrorMessage = "El nombre de la sucursal es un campo obligatorio.")]
        [MinLength(5, ErrorMessage = "La longitud mínima para el nombre de la sucursal es de 5.")]
        [MaxLength(100, ErrorMessage = "La longitud máxima para el nombre de la sucursal es de 100.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La dirección de la sucursal es un obligatorio.")]
        [MinLength(20, ErrorMessage = "La longitud mínima para la dirección de la sucursal es de 20.")]
        [MaxLength(255, ErrorMessage = "La longitud máxima para la dirección de la sucursal es de 255.")]
        public string Direccion { get; set; }

    }
}
