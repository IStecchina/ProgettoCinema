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
    public class MovieGateway : IGateway<Movie>
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
                .Where(m => m.ID == id)
                .FirstOrDefaultAsync();
        }

        public async Task Create(Movie m)
        {
            await _context.Movies.AddAsync(m);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Movie m)
        {
            _context.Movies.Update(m);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var m = await GetById(id);
            if (m is not null) _context.Movies.Remove(m);
            await _context.SaveChangesAsync();
        }
    }
}
