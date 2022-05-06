using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoCinema.Domain
{
    [Table("Movies")]
    public class Movie
    {
        //Relational
        [Key]
        public int ID { get; init; }
        //Non-relational
        [Required]
        public string Title { get; init; } = null!;
        [Required]
        public string Author { get; init; } = null!;
        [Required]
        public string Producer { get; init; } = null!;
        [Required]
        public string Genre { get; init; } = null!;
        [Required]
        public TimeSpan Duration { get; init; }
    }
}
