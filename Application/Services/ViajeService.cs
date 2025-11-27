using Application.DTO.Viajes;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ViajeService(IViajeRepository viajeRepository) : IViajeService
    {
        private ViajeDTO MapToDTO(Viaje viaje)
        {
            return new ViajeDTO
            {
                Id = viaje.Id,
                DistanciaTotal = viaje.DistanciaTotal,
                TarifaTotal = viaje.TarifaTotal,
                SucursalId = viaje.SucursalId,
                TransportistaId = viaje.TransportistaId,
                TransportistaNombre = viaje.Transportista != null
                            ? $"{viaje.Transportista.Nombres} {viaje.Transportista.Apellidos}"
                            : "No disponible",
                SucursalNombre = viaje.Sucursal != null
                            ? viaje.Sucursal.Nombre
                            : "No disponible",
            };
        }

        private ViajeReportDTO MapToReportDTO(Viaje viaje)
        {
            return new ViajeReportDTO
            {
                DistanciaTotal = viaje.DistanciaTotal,
                TarifaTotal = viaje.TarifaTotal,
                SucursalId = viaje.SucursalId,
                TransportistaId = viaje.TransportistaId,
                TransportistaNombre = viaje.Transportista.Nombres + " " + viaje.Transportista.Apellidos,
                SucursalNombre = viaje.Sucursal.Nombre,
            };
        }

        public async Task<IEnumerable<ViajeDTO>> GetAllViajesAsync(FilterViajeDTO filter)
        {
            var viajes = await viajeRepository.GetAllAsync(filter);
            var dtos = new List<ViajeDTO>();

            foreach (var viaje in viajes)
            {
                dtos.Add(MapToDTO(viaje));
            }

            return dtos;
        }

        public async Task<ViajeDTO?> GetViajeByIdAsync(int id)
        {
            var viaje = await viajeRepository.GetByIdAsync(id);

            if (viaje == null)
                return null;

            return MapToDTO(viaje);
        }
        public async Task<ViajeDTO?> AddViajeAsync(CreateViajeDTO createViaje)
        {
            var viaje = new Viaje
            {
                Fecha = createViaje.Fecha,
                SucursalId = createViaje.SucursalId,
                TransportistaId = createViaje.TransportistaId,
            };

            var newViaje = await viajeRepository.AddAsync(viaje);

            if (newViaje == null)
                return null;

            var createdViaje = await viajeRepository.GetByIdAsync(newViaje.Id);

            return MapToDTO(createdViaje);
        }

        public async Task UpdateViajeAsync(UpdateViajeDTO updateViaje)
        {
            var viaje = await viajeRepository.GetByIdAsync(updateViaje.Id);
            if (viaje == null)
                throw new Exception($"Viaje con Id: {updateViaje.Id} no existe para actualizarse.");

            viaje.Fecha = updateViaje.Fecha;
            viaje.TransportistaId = updateViaje.TransportistaId;

            await viajeRepository.UpdateAsync(viaje);
        }

        public async Task DeleteViajeAsync(int id)
        {
            await viajeRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ViajeReportDTO>> GetViajesForReport(FilterReportDTO filter)
        {
            var viajes = await viajeRepository.GetViajesForReport(filter);
            var dtos = new List<ViajeReportDTO>();

            foreach (var viaje in viajes)
            {
                dtos.Add(MapToReportDTO(viaje));
            }

            return dtos;
        }
    }
}
