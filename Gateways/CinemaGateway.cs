using Microsoft.EntityFrameworkCore;
using ProgettoCinema.Abstract;
using ProgettoCinema.DbMiddleware;
using ProgettoCinema.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoCinema.Gateways
{
    public class CinemaGateway : IGateway<Cinema>
    {
        private readonly CinemaDbContext _context;

        public CinemaGateway(CinemaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cinema>> GetAll()
        {
            return await _context.Cinemas
                .ToListAsync();
        }

        public async Task<Cinema?> GetById(int id)
        {
            return await _context.Cinemas
                .Where(c => c.Id == id)
                .Include(c => c.Rooms)
                .ThenInclude(r => r.Movie)
                .Include(c => c.Rooms)
                .ThenInclude(r => r.OccupiedSeats)
                .ThenInclude(t => t.Customer)
                .FirstOrDefaultAsync();
        }

        public async Task Create(Cinema c)
        {
            await _context.Cinemas.AddAsync(c);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Cinema c)
        {
            _context.Cinemas.Update(c);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var c = await GetById(id);
            if (c is not null) _context.Cinemas.Remove(c);
            await _context.SaveChangesAsync();
        }
    }
}
