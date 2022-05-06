using Microsoft.EntityFrameworkCore;
using ProgettoCinema.DbMiddleware;
using ProgettoCinema.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoCinema.Gateways
{
    public class RoomGateway
    {
        private readonly CinemaDbContext _context;

        public RoomGateway(CinemaDbContext context)
        {
            _context = context;
        }

        public async Task<List<CinemaRoom>> GetAll()
        {
            return await _context.Rooms
                .Include(c => c.Movie)
                .ToListAsync();
        }

        public async Task<CinemaRoom?> GetById(int id)
        {
            return await _context.Rooms
                .Include(c => c.Movie)
                .Include(c => c.Customers)
                .FirstOrDefaultAsync(c => c.ID == id);
        }

        public async Task Create(CinemaRoom c)
        {
            await _context.Rooms.AddAsync(c);
            await _context.SaveChangesAsync();
        }
    }
}
