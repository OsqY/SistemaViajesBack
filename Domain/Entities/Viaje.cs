using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Domain.Entities
{
    public class Viaje
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public decimal TarifaTotal { get; private set; } = 0;

        [Range(1, 100)]
        public double DistanciaTotal { get; private set; } = 1;

        public DateOnly Fecha { get; set; }
        public int TransportistaId { get; set; }
        public Transportista Transportista { get; set; }
        public int SucursalId { get; set; }
        public Sucursal Sucursal { get; set; }
        public List<UsuarioViaje> UsuarioViajes { get; set; } = new();

        public void AgregarPasajero(UsuarioViaje nuevoPasajero)
        {
            if (UsuarioViajes.Any(uv => uv.UsuarioId == nuevoPasajero.UsuarioId))
                throw new InvalidOperationException($"El usuario {nuevoPasajero.UsuarioId} ya está registrado en este viaje.");

            if (nuevoPasajero.Distancia <= 0)
                throw new ArgumentException("La distancia del pasajero debe ser mayor a 0.");

            if (nuevoPasajero.Tarifa < 0)
                throw new ArgumentException("La tarifa no puede ser negativa.");

            double nuevaDistanciaTotal = DistanciaTotal + nuevoPasajero.Distancia;
            if (nuevaDistanciaTotal > 100)
                throw new InvalidOperationException($"No se puede agregar el pasajero. La distancia total ({nuevaDistanciaTotal}) excedería el límite permitido de 100.");

            UsuarioViajes.Add(nuevoPasajero);
            Totalizar();
        }

        public void RemoverPasajero(UsuarioViaje pasajero)
        {
            var item = UsuarioViajes.FirstOrDefault(uv => uv.UsuarioId == pasajero.UsuarioId);
            if (item != null)
            {
                UsuarioViajes.Remove(item);
                Totalizar();
            }
        }

        public void Totalizar()
        {
            TarifaTotal = UsuarioViajes.Sum(uv => uv.Tarifa);
            DistanciaTotal = UsuarioViajes.Sum(uv => uv.Distancia);
        }

        public void Validate()
        {
            if (TransportistaId <= 0)
                throw new InvalidOperationException("El viaje debe tener un transportista asignado.");

            if (SucursalId <= 0)
                throw new InvalidOperationException("El viaje debe estar asignado a una sucursal.");

            if (Fecha == default)
                throw new InvalidOperationException("La fecha del viaje es inválida.");
        }
    }
}
