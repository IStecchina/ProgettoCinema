using Microsoft.EntityFrameworkCore;
using ProgettoCinema.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoCinema.DbMiddleware
{
    public class CinemaDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<Ticket> Tickets { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<CinemaRoom> Rooms { get; set; } = null!;
        public DbSet<Cinema> Cinemas { get; set; } = null!;

        public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options)
        {
        }
    }
}
