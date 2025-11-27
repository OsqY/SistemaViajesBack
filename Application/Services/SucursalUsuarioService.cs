using Application.DTO.SucursalUsuarios;
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
    public class SucursalUsuarioService(ISucursalUsuarioRepository sucursalUsuarioRepository) : ISucursalUsuarioService
    {
        private SucursalUsuarioDTO MapToDTO(SucursalUsuario sucursalUsuario)
        {
            return new SucursalUsuarioDTO
            {
                UsuarioId = sucursalUsuario.UsuarioId,
                Distancia = sucursalUsuario.Distancia,
                SucursalId = sucursalUsuario.SucursalId,
                NombreSucursal = sucursalUsuario.Sucursal.Nombre,
                UsuarioEmail = sucursalUsuario.Usuario.Email
            };
        }

        public async Task<IEnumerable<SucursalUsuarioDTO>> GetAllSucursalUsuariosAsync(FilterSucursalUsuarioDTO filter)
        {
            var sucursalUsuarios = await sucursalUsuarioRepository.GetAllAsync(filter);
            var dtos = new List<SucursalUsuarioDTO>();

            foreach (var sucursalUsuario in sucursalUsuarios)
            {
                dtos.Add(MapToDTO(sucursalUsuario));
            }
            return dtos;
        }

        public async Task<SucursalUsuarioDTO?> GetSucursalUsuarioAsync(int sucursalId, string usuarioId)
        {
            var sucursalUsuario = await sucursalUsuarioRepository.GetByIdAsync(sucursalId, usuarioId);

            if (sucursalUsuario == null)
                return null;

            return MapToDTO(sucursalUsuario);
        }

        public async Task<SucursalUsuarioDTO?> AddSucursalUsuarioAsync(CreateSucursalUsuarioDTO createSucursalUsuario)
        {
            var sucursalUsuario = new SucursalUsuario
            {
                SucursalId = createSucursalUsuario.SucursalId,
                UsuarioId = createSucursalUsuario.UsuarioId,
                Distancia = createSucursalUsuario.Distancia
            };

            var newSucursalUsuario = await sucursalUsuarioRepository.AddAsync(sucursalUsuario);
            if (newSucursalUsuario == null)
                return null;
            return MapToDTO(newSucursalUsuario);
        }

        public async Task UpdateSucursalUsuarioAsync(UpdateSucursalUsuarioDTO updateSucursalUsuario)
        {
            var sucursalUsuario = await sucursalUsuarioRepository.GetByIdAsync(updateSucursalUsuario.SucursalId, updateSucursalUsuario.UsuarioId);

            if (sucursalUsuario == null)
                throw new Exception($"El registro del usuario con Id: {updateSucursalUsuario.UsuarioId} para la sucursal con Id: {updateSucursalUsuario.SucursalId} no existe para actualizarse.");

            sucursalUsuario.UsuarioId = updateSucursalUsuario.UsuarioId;

            await sucursalUsuarioRepository.UpdateAsync(sucursalUsuario);

        }
        public async Task DeleteSucursalUsuarioAsync(int sucursalId, string usuarioId)
        {
            await sucursalUsuarioRepository.DeleteASync(sucursalId, usuarioId);
        }

    }
}
