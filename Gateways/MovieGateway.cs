using Microsoft.EntityFrameworkCore;
using ProgettoCinema.DbMiddleware;
using ProgettoCinema.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoCinema.Gateways
{
    public class MovieGateway
    {
        private readonly CinemaDbContext _context;

        public MovieGateway(CinemaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Movie>> GetAll()
        {
            return await _context.Movies
                .ToListAsync();
        }

        public async Task<Movie?> GetById(int id)
        {
            return await _context.Movies
                .FirstOrDefaultAsync(c => c.ID == id);
        }

        public async Task Create(Movie c)
        {
            await _context.Movies.AddAsync(c);
            await _context.SaveChangesAsync();
        }
    }
}
