using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab4.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string State { get; set; } = "free";
        public string Owner { get; set; } = "";
        public int Price { get; set; } = 0;
        public int PlayId { get; set; }
        public Play Play { get; set; }
    }
}