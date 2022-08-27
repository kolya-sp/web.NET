using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab4.Models
{
    public class Play
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Autor { get; set; } = "";
        public string Genre { get; set; } = "";
        public DateTime Data { get; set; } = new DateTime();
        public List<Ticket> Tikets { get; set; }
    }
}