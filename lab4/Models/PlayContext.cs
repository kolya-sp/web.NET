using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace lab4.Models
{
    public class PlayContext: DbContext
    {
        public DbSet<Play> Plays { get; set; }
        public DbSet<Ticket> Tikets { get; set; }
    }
}