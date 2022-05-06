using Microsoft.EntityFrameworkCore;
using ProgettoCinema.DbMiddleware;
using ProgettoCinema.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoCinema.Gateways
{
    public class CustomerGateway
    {

        private readonly CinemaDbContext _context;

        public CustomerGateway(CinemaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _context.Customers
                .ToListAsync();
        }

        public async Task<Customer?> GetById(int id)
        {
            return await _context.Customers
                .Where(c => c.ID == id)
                .FirstOrDefaultAsync();
        }

        public async Task Create(Customer c)
        {
            await _context.Customers.AddAsync(c);
            await _context.SaveChangesAsync();
        }
    }
}
