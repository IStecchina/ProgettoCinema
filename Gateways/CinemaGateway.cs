using Microsoft.EntityFrameworkCore;
using ProgettoCinema.DbMiddleware;
using ProgettoCinema.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoCinema.Gateways
{
    public class CinemaGateway
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
                .Include(c => c.Rooms)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task Create(Cinema c)
        {
            await _context.Cinemas.AddAsync(c);
            await _context.SaveChangesAsync();
        }

    }
}
