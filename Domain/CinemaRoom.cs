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
        public virtual List<Customer> Customers { get; init; } = null!;
        //Non-relational
        public int Seats { get; init; }


        public void Empty()
        {
            //TODO
        }

        public void AddCustomer(Customer c)
        {
            //TODO
        }

        public decimal GetRevenue()
        {
            //TODO
            return 0;
        }
    }
}
