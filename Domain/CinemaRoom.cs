using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoCinema.Domain
{
    public class CinemaRoom
    {
        public int Seats { get; init; }
        public Movie MyMovie { get; init; }

        public decimal GetRevenue()
        {
            return 0;
        }
    }
}
