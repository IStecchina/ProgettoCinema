using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoCinema.Domain
{
    public class Cinema
    {

        public List<CinemaRoom> Rooms { get; init; }

        public Cinema(List<CinemaRoom> rooms)
        {
            Rooms = rooms;
        }

        public decimal GetRevenue()
        {
            return Rooms.Sum(r => r.GetRevenue());
        }
    }
}
