using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoCinema.Domain
{
    [Table("Tickets")]
    public class Ticket
    {
        //Relational
        [Key]
        public int ID { get; init; }

        [InverseProperty("Ticket")]
        public virtual Customer Customer { get; init; } = null!;
        //Non-relational
        [Required]
        public int Position { get; init; }
        [Required]
        public decimal Price { get; init; }
    }
}
