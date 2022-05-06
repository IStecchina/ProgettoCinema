using Microsoft.AspNetCore.Mvc.Rendering;
using ProgettoCinema.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoCinema.Models
{
    public class RoomCreationModel
    {
        public CinemaRoom Room { get; set; }
        public IEnumerable<SelectListItem> Cinemas { get; init; }
        public IEnumerable<SelectListItem> Movies { get; init; }

        public RoomCreationModel()
        {
            Room = new CinemaRoom();
            Cinemas = new List<SelectListItem>();
            Movies = new List<SelectListItem>();
        }

        public RoomCreationModel(CinemaRoom r, List<Cinema> cinemas, List<Movie> movies)
        {
            Room = r;

            var cList = new List<SelectListItem>();
            cinemas.ForEach(c => cList.Add(new SelectListItem { Value = c.Id.ToString(), Text = c.Id.ToString() }));
            Cinemas = cList;

            var mList = new List<SelectListItem>();
            movies.ForEach(m => mList.Add(new SelectListItem { Value = m.ID.ToString(), Text = m.Title }));
            Movies = mList;
        }
    }
}
