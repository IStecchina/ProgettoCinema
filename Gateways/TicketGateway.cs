﻿using Microsoft.EntityFrameworkCore;
using ProgettoCinema.DbMiddleware;
using ProgettoCinema.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoCinema.Gateways
{
    public class TicketGateway
    {
        private readonly CinemaDbContext _context;

        public TicketGateway(CinemaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Ticket>> GetAll()
        {
            return await _context.Tickets
                .ToListAsync();
        }

        public async Task<Ticket?> GetById(int id)
        {
            return await _context.Tickets
                .Where(t => t.ID == id)
                .Include(t => t.Customer)
                .Include(t => t.Room)
                .ThenInclude(r => r.Movie)
                .FirstOrDefaultAsync();
        }

        public async Task Create(Ticket t)
        {
            await _context.Tickets.AddAsync(t);
            await _context.SaveChangesAsync();
        }
    }
}
