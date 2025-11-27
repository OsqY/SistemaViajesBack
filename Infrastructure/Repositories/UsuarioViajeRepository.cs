using Application.DTO.UsuarioViajes;
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
    public class UsuarioViajeRepository(AppDbContext context) : IUsuarioViajeRepository
    {
        public async Task<IEnumerable<UsuarioViaje>> GetAllAsync(FilterUsuarioViajeDTO filter)
        {
            var usuarioViajes = context.UsuariosViajes
                .Include(u => u.Usuario).Include(u => u.Viaje)
                .AsNoTracking().Where(e => e.ViajeId == filter.ViajeId);

            if (filter.UsuarioId != null)
                usuarioViajes = usuarioViajes.Where(e => e.UsuarioId == filter.UsuarioId);

            if (filter.MinDistancia != null)
                usuarioViajes = usuarioViajes.Where(e => e.Distancia >= filter.MinDistancia);

            if (filter.MaxDistancia != null)
                usuarioViajes = usuarioViajes.Where(e => e.Distancia <= filter.MaxDistancia);

            if (filter.MinTarifa != null)
                usuarioViajes = usuarioViajes.Where(e => e.Tarifa >= filter.MinTarifa);

            if (filter.MaxTarifa != null)
                usuarioViajes = usuarioViajes.Where(e => e.Tarifa <= filter.MaxTarifa);

            return await usuarioViajes.Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();
        }

        public async Task<UsuarioViaje?> GetByIdAsync(int viajeId, string usuarioId)
        {
            return await context.UsuariosViajes.AsNoTracking().FirstOrDefaultAsync(e => e.ViajeId == viajeId && e.UsuarioId == usuarioId);
        }

        public async Task<UsuarioViaje?> AddAsync(UsuarioViaje usuarioViaje)
        {
            await context.UsuariosViajes.AddAsync(usuarioViaje);
            await context.SaveChangesAsync();
            return usuarioViaje;
        }

        public async Task UpdateAsync(UsuarioViaje usuarioViaje)
        {
            context.UsuariosViajes.Update(usuarioViaje);
            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int viajeId, string usuarioId)
        {
            var usuarioViaje = await context.UsuariosViajes.FirstOrDefaultAsync(e => e.ViajeId == viajeId && e.UsuarioId == usuarioId);
            if (usuarioViaje != null)
            {
                context.UsuariosViajes.Remove(usuarioViaje);
                await context.SaveChangesAsync();
            }
        }

    }
}
