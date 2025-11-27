using Application.DTO.Transportistas;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TransportistaRepository(AppDbContext context) : ITransportistaRepository
    {
        public async Task<IEnumerable<Transportista>> GetAllAsync(FilterTransportistaDTO filter)
        {
            var transportistas = context.Transportistas.AsNoTracking();

            if (filter.NombreFilter != null)
                transportistas = transportistas.Where(e => e.Nombres.ToLower().Contains(filter.NombreFilter));

            if (filter.ApellidosFilter != null)
                transportistas = transportistas.Where(e => e.Apellidos.ToLower().Contains(filter.ApellidosFilter.ToLower()));

            return await transportistas.Skip((filter.PageNumber - 1) * filter.PageSize).Take(filter.PageSize).ToListAsync();
        }

        public async Task<Transportista?> GetByIdAsync(int id)
        {
            return await context.Transportistas.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Transportista?> AddAsync(Transportista transportista)
        {
            await context.Transportistas.AddAsync(transportista);
            await context.SaveChangesAsync();
            return transportista;
        }

        public async Task UpdateAsync(Transportista transportista)
        {
            context.Transportistas.Update(transportista);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var transportista = await context.Transportistas.FindAsync(id);
            if (transportista != null)
            {
                context.Transportistas.Remove(transportista);
                await context.SaveChangesAsync();
            }
        }
    }
}
