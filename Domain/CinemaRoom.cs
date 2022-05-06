using ProgettoCinema.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoCinema.Domain
{
    [Table("Rooms")]
    public class CinemaRoom
    {
        //Relational
        [Key]
        public int ID { get; init; }

        public int MovieId { get; init; }
        [ForeignKey("MovieId")]
        public virtual Movie Movie { get; init; } = null!;

        public int CinemaId { get; init; }
        [ForeignKey("CinemaId")]
        public virtual Cinema Cinema { get; init; } = null!;

        [InverseProperty("Room")]
        public virtual List<Ticket> OccupiedSeats { get; init; } = null!;
        //Non-relational
        public int Seats { get; init; }


        public void Empty()
        {
            //TODO
            //Delete all tickets that are in OccupiedSeats
        }

        public int AddCustomer(Customer c)
        {
            //Exception if room is full, or if movie is horror and customer is too young
            if (OccupiedSeats.Count >= Seats) {
                throw new FullRoomException();
            }
            if(Movie.Genre == "Horror" && c.IsTooYoungForHorror)
            {
                throw new ForbiddenMovieException();
            }
            return OccupiedSeats.Count + 1;
        }

        public decimal GetRevenue()
        {
            decimal revenue = 0;
            foreach (var ticket in OccupiedSeats) {
                revenue += ticket.ActualPrice;
            }
            return revenue;
        }
    }
}
