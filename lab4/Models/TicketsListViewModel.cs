using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace lab4.Models
{
    public class TicketsListViewModel
    {
        public IEnumerable<Ticket> Tickets { get; set; }
        public SelectList Owner { get; set; }

        public SelectList PlayName { get; set; }
    }
}