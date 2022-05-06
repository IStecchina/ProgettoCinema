using Microsoft.AspNetCore.Mvc.Rendering;
using ProgettoCinema.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoCinema.Models
{
    public class TicketCreationModel
    {

        public Ticket Ticket { get; set; }
        public IEnumerable<SelectListItem> Rooms { get; init; }
        public IEnumerable<SelectListItem> Customers { get; init; }

        public TicketCreationModel()
        {
            Ticket = new Ticket();
            Rooms = new List<SelectListItem>();
            Customers = new List<SelectListItem>();
        }

        public TicketCreationModel(Ticket t, List<CinemaRoom> rooms, List<Customer> customers)
        {
            Ticket = t;

            var rList = new List<SelectListItem>();
            rooms.ForEach(r => rList.Add(new SelectListItem { Value = r.ID.ToString(), Text = $"Room Id: {r.ID} - Movie: {r.Movie.Title}" }));
            Rooms = rList;

            var cList = new List<SelectListItem>();
            customers.ForEach(c => cList.Add(new SelectListItem { Value = c.ID.ToString(), Text = $"{c.Name} {c.Surname}" }));
            Customers = cList;
        }
    }
}
