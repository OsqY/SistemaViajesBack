using Application.DTO.UsuarioViajes;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Application.Services
{
    public class UsuarioViajeService(IUsuarioViajeRepository usuarioViajeRepository, IViajeRepository viajeRepository, ISucursalUsuarioRepository sucursalUsuarioRepository) : IUsuarioViajeService
    {
        private UsuarioViajeDTO MapToDTO(UsuarioViaje usuarioViaje)
        {
            return new UsuarioViajeDTO
            {
                UsuarioId = usuarioViaje.UsuarioId,
                ViajeId = usuarioViaje.ViajeId,
                Distancia = usuarioViaje.Distancia,
                Fecha = usuarioViaje.Fecha,
                Tarifa = usuarioViaje.Tarifa,
                UsuarioEmail = usuarioViaje.Usuario.Email,
            };
        }

        public async Task<IEnumerable<UsuarioViajeDTO>> GetAllUsuarioViajesAsync(FilterUsuarioViajeDTO filter)
        {
            var usuarioViajes = await usuarioViajeRepository.GetAllAsync(filter);
            var dtos = new List<UsuarioViajeDTO>();

            foreach (var usuarioViaje in usuarioViajes)
            {
                dtos.Add(MapToDTO(usuarioViaje));
            }

            return dtos;
        }

        public async Task<UsuarioViajeDTO?> GetUsuarioViajeByIdAsync(int viajeId, string usuarioId)
        {
            var usuarioViaje = await usuarioViajeRepository.GetByIdAsync(viajeId, usuarioId);

            if (usuarioViaje == null)
                return null;

            return MapToDTO(usuarioViaje);
        }

        public async Task<UsuarioViajeDTO?> AddUsuarioViajeAsync(CreateUsuarioViajeDTO createUsuarioViaje)
        {
            var viaje = await viajeRepository.GetByIdWithDetailsAsync(createUsuarioViaje.ViajeId);

            if (viaje == null)
                throw new Exception("El viaje no existe.");

            var relacionSucursal = await sucursalUsuarioRepository.GetByIdAsync(viaje.SucursalId, createUsuarioViaje.UsuarioId);
            if (relacionSucursal == null)
                throw new Exception("El usuario no pertenece a la sucursal asignada a este viaje.");

            var usuarioViaje = new UsuarioViaje
            {
                Distancia = createUsuarioViaje.Distancia,
                Tarifa = createUsuarioViaje.Tarifa,
                Fecha = DateOnly.FromDateTime(DateTime.Now),
                ViajeId = createUsuarioViaje.ViajeId,
                UsuarioId = createUsuarioViaje.UsuarioId,
                CreatorUserId = createUsuarioViaje.CreatorUserId,
            };

            viaje.AgregarPasajero(usuarioViaje);

            await viajeRepository.UpdateAsync(viaje);
            return MapToDTO(usuarioViaje);
        }

        public async Task UpdateUsuarioViajeAsync(UpdateUsuarioViajeDTO updateUsuarioViaje)
        {
            var viaje = await viajeRepository.GetByIdWithDetailsAsync(updateUsuarioViaje.ViajeId);

            if (viaje == null)
                throw new Exception("El viaje no existe.");

            var item = viaje.UsuarioViajes.FirstOrDefault(uv => uv.UsuarioId == updateUsuarioViaje.UsuarioId);

            if (item == null)
                throw new Exception($"El pasajero con ID {updateUsuarioViaje.UsuarioId} no se encuentra en este viaje.");

            if (updateUsuarioViaje.Distancia > 0)
                item.Distancia = updateUsuarioViaje.Distancia;

            if (updateUsuarioViaje.Tarifa > 0)
                item.Tarifa = updateUsuarioViaje.Tarifa;

            viaje.Totalizar();

            await viajeRepository.UpdateAsync(viaje);
        }

        public async Task DeleteUsuarioViajeAsync(int viajeId, string usuarioId)
        {
            var viaje = await viajeRepository.GetByIdWithDetailsAsync(viajeId);

            if (viaje == null)
                throw new Exception("El viaje no existe.");

            var usuarioViaje = viaje.UsuarioViajes.FirstOrDefault(uv => uv.UsuarioId == usuarioId);

            if (usuarioViaje != null)
            {
                viaje.RemoverPasajero(usuarioViaje);
                await viajeRepository.UpdateAsync(viaje);
            }
        }
    }
}
