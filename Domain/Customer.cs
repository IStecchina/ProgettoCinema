using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoCinema.Domain
{
    [Table("Customers")]
    public class Customer
    {
        //Relational
        [Key]
        public int ID { get; init; }

        public int TicketId { get; init; }
        [ForeignKey("TicketId")]
        public virtual Ticket Ticket { get; init; } = null!;

        public int? RoomId { get; init; }
        [ForeignKey("RoomId")]
        public virtual CinemaRoom? Room { get; init; }
        //Non-relational
        [Required]
        public string Name { get; init; } = null!;
        [Required]
        public string Surname { get; init; } = null!;
        [Required]
        public DateTime BirthDate { get; init; }

    }
}
