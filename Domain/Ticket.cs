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

        public int RoomId { get; init; }
        [ForeignKey("RoomId")]
        public virtual CinemaRoom Room { get; init; } = null!;
        //Non-relational
        [Required]
        public int Position { get; init; }
        [Required]
        public decimal Price { get; init; }

        //Price including discounts
        public decimal ActualPrice => ApplyDiscountsIfApplicable(Price);

        public decimal ApplyDiscountsIfApplicable(decimal basePrice)
        {
            decimal discount = 0;
            if (Customer.IsOldEnoughForDiscount) discount = 0.1m * basePrice;
            if (Customer.IsYoungEnoughForDiscount) discount = 0.5m * basePrice;
            return basePrice - discount;
        }
    }
}
