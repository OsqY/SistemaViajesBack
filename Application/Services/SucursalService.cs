using Application.DTO.Sucursales;
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
    public class SucursalService(ISucursalRepository sucursalRepository) : ISucursalService
    {
        private SucursalDTO MapToDTO(Sucursal sucursal)
        {
            return new SucursalDTO
            {
                Id = sucursal.Id,
                Nombre = sucursal.Nombre,
                Direccion = sucursal.Direccion,
            };
        }

        public async Task<IEnumerable<SucursalDTO>> GetAllSucursalesAsync(FilterSucursalDTO filter)
        {
            var sucursales = await sucursalRepository.GetAllAsync(filter);
            var dtos = new List<SucursalDTO>();

            foreach (var sucursal in sucursales)
            {
                dtos.Add(MapToDTO(sucursal));
            }
            return dtos;
        }

        public async Task<SucursalDTO?> GetSucursalByIdAsync(int id)
        {
            var sucursal = await sucursalRepository.GetByIdAsync(id);

            if (sucursal == null)
                return null;

            return MapToDTO(sucursal);
        }

        public async Task<SucursalDTO?> AddSucursalAsync(CreateSucursalDTO createSucursal)
        {
            var sucursal = new Sucursal
            {
                Nombre = createSucursal.Nombre,
                Direccion = createSucursal.Direccion
            };

            var newSucursal = await sucursalRepository.AddAsync(sucursal);

            if (newSucursal == null)
                return null;

            return MapToDTO(newSucursal);
        }

        public async Task UpdateSucursalAsync(UpdateSucursalDTO updateSucursal)
        {
            var sucursal = await sucursalRepository.GetByIdAsync(updateSucursal.Id);

            if (sucursal == null)
                throw new Exception($"Sucursal con Id: {updateSucursal.Id} no existe para actualizarse.");

            sucursal.Nombre = updateSucursal.Nombre;
            sucursal.Direccion = updateSucursal.Direccion;

            await sucursalRepository.UpdateAsync(sucursal);
        }

        public async Task DeleteSucursalAsync(int id)
        {
            await sucursalRepository.DeleteAsync(id);
        }


    }
}
