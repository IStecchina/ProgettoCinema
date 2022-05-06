using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoCinema.Domain
{
    public record Movie(
        [Required]
        string Title,
        [Required]
        string Author,
        [Required]
        string Producer,
        [Required]
        string Genre,
        [Required]
        TimeSpan Duration
        )
    {
    }
}
