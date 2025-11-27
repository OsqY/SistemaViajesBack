using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Transportista
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, StringLength(40, MinimumLength = 2)]
        public string Nombres { get; set; }
        [Required, StringLength(40, MinimumLength = 2)]
        public string Apellidos { get; set; }
        [Required, StringLength(500, MinimumLength = 10)]
        public string Descripcion { get; set; }
        public decimal Tarifa { get; set; }
        public List<Viaje> Viajes { get; set; } = new();

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Nombres) || Nombres.Length < 2)
                throw new ArgumentException("El nombre es inválido.");

            if (string.IsNullOrWhiteSpace(Apellidos) || Apellidos.Length < 2)
                throw new ArgumentException("El apellido es inválido.");

            if (Tarifa < 0)
                throw new ArgumentException("La tarifa del transportista no puede ser negativa.");
        }
    }
}