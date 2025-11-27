using Application.DTO.SucursalUsuarios;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class SucursalUsuarioRepository(AppDbContext context) : ISucursalUsuarioRepository
    {
        public async Task<IEnumerable<SucursalUsuario>> GetAllAsync(FilterSucursalUsuarioDTO filter)
        {
            var sucursalUsuarios = context.SucursalUsuarios.Include(e => e.Sucursal).Include(e => e.Usuario)
                .AsNoTracking().Where(e => e.SucursalId == filter.SucursalId);

            if (filter.MinDistancia != null)
                sucursalUsuarios = sucursalUsuarios.Where(e => e.Distancia >= filter.MinDistancia);

            if (filter.MaxDistancia != null)
                sucursalUsuarios = sucursalUsuarios.Where(e => e.Distancia <= filter.MaxDistancia);

            return await sucursalUsuarios.Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                    .ToListAsync();
        }

        public async Task<SucursalUsuario?> GetByIdAsync(int sucursalId, string usuarioId)
        {
            return await context.SucursalUsuarios.AsNoTracking().FirstOrDefaultAsync(e => e.SucursalId == sucursalId && e.UsuarioId == usuarioId);
        }
        public async Task<SucursalUsuario?> AddAsync(SucursalUsuario sucursalUsuario)
        {
            await context.SucursalUsuarios.AddAsync(sucursalUsuario);
            await context.SaveChangesAsync();
            return sucursalUsuario;
        }


        public async Task UpdateAsync(SucursalUsuario sucursalUsuario)
        {
            context.SucursalUsuarios.Update(sucursalUsuario);
            await context.SaveChangesAsync();
        }
        public async Task DeleteASync(int sucursalId, string usuarioId)
        {
            var sucursalUsuario = await context.SucursalUsuarios.FirstOrDefaultAsync(e => e.SucursalId == sucursalId && e.UsuarioId == usuarioId);
            if (sucursalUsuario != null)
            {
                context.SucursalUsuarios.Remove(sucursalUsuario);
                await context.SaveChangesAsync();
            }
        }

    }
}
