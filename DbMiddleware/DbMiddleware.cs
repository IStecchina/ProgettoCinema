using ProgettoCinema.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoCinema.DbMiddleware
{
    public class DbMiddleware
    {
        private readonly CinemaDbContext _context;

        public DbMiddleware(CinemaDbContext context)
        {
            _context = context;
        }

        public List<Cinema> GetAllCinemas()
        {
            return _context.Cinemas.ToList();
        }
    }
}