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

        [InverseProperty("Customer")]
        public virtual Ticket? Ticket { get; init; }

        //Non-relational
        [Required]
        public string Name { get; init; } = null!;
        [Required]
        public string Surname { get; init; } = null!;
        [Required]
        public DateTime BirthDate { get; init; }

        public bool HasTicket => Ticket is not null;

        public string FullName => $"{Name} {Surname}";

        public int GetAge()
        {
            int result = DateTime.Now.Year - BirthDate.Year;
            //Check if we reached birthday this year
            if (DateTime.Now.Month < BirthDate.Month) result -= 1;
            if (DateTime.Now.Month == BirthDate.Month && DateTime.Now.Day < BirthDate.Day) result -= 1;

            return result;
        }
        public bool IsTooYoungForHorror => GetAge()<14;
        public bool IsYoungEnoughForDiscount => GetAge()<5;
        public bool IsOldEnoughForDiscount => GetAge()>70;


    }
}
