using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace lab4.Models
{
    public class PlayListViewModel
    {
        public IEnumerable<Play> Plays { get; set; }
        public SelectList Autor { get; set; }

        public SelectList Name { get; set; }
        public SelectList Genre { get; set; }
        public SelectList Data { get; set; }
    }
}