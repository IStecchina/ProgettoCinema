using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoCinema.Domain
{
    [Table("Cinemas")]
    public class Cinema
    {
        //Relational
        [Key]
        public int Id { get; init; }

        [InverseProperty("Cinema")]
        public List<CinemaRoom> Rooms { get; init; } = null!;

        //Non-relational
        public string Name { get; init; } = null!;

        public decimal GetRevenue()
        {
            return Rooms.Sum(r => r.GetRevenue());
        }
    }
}
