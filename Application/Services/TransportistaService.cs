using Application.DTO.Transportistas;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TransportistaService(ITransportistaRepository transportistaRepository) : ITransportistaService
    {
        private TransportistaDTO MapToDTO(Transportista transportista)
        {
            return new TransportistaDTO
            {
                Id = transportista.Id,
                Nombres = transportista.Nombres,
                Apellidos = transportista.Apellidos,
                Descripcion = transportista.Descripcion,
            };
        }

        public async Task<IEnumerable<TransportistaDTO>> GetAllTransportistasAsync(FilterTransportistaDTO filter)
        {
            var transportistas = await transportistaRepository.GetAllAsync(filter);
            var dtos = new List<TransportistaDTO>();

            foreach (var transportista in transportistas)
            {
                dtos.Add(MapToDTO(transportista));
            }
            return dtos;
        }

        public async Task<TransportistaDTO?> GetTransportistaByIdAsync(int id)
        {
            var transportista = await transportistaRepository.GetByIdAsync(id);

            if (transportista == null)
                return null;

            return MapToDTO(transportista);
        }

        public async Task<TransportistaDTO?> AddTransportistaAsync(CreateTransportistaDTO createTransportista)
        {
            var transportista = new Transportista
            {
                Nombres = createTransportista.Nombres,
                Apellidos = createTransportista.Apellidos,
                Descripcion = createTransportista.Descripcion,
            };

            transportista.Validate();

            var newTransportista = await transportistaRepository.AddAsync(transportista);

            if (newTransportista == null)
                return null;

            return MapToDTO(newTransportista);
        }

        public async Task UpdateTransportistaAsync(UpdateTransportistaDTO updateTransportista)
        {
            var transportista = await transportistaRepository.GetByIdAsync(updateTransportista.Id);
            if (transportista == null)
                throw new Exception($"Transportista con Id: {updateTransportista.Id} no existe para actualizarse.");

            transportista.Nombres = updateTransportista.Nombres;
            transportista.Apellidos = updateTransportista.Apellidos;
            transportista.Descripcion = updateTransportista.Descripcion;

            transportista.Validate();

            await transportistaRepository.UpdateAsync(transportista);
        }

        public async Task DeleteTransportistaAsync(int id)
        {
            await transportistaRepository.DeleteAsync(id);
        }
    }
}