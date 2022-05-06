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
                .Include(r => r.Movie)
                .ToListAsync();
        }

        public async Task<CinemaRoom?> GetById(int id)
        {
            return await _context.Rooms
                .Where(r => r.ID == id)
                .Include(r => r.Movie)
                .Include(r => r.OccupiedSeats)
                .ThenInclude(t => t.Customer)
                .FirstOrDefaultAsync();
        }

        public async Task Create(CinemaRoom r)
        {
            await _context.Rooms.AddAsync(r);
            await _context.SaveChangesAsync();
        }
    }
}
