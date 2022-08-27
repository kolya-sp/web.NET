using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using lab4.Models;

namespace lab4.Models
{
    public class PlayDbInitializer : DropCreateDatabaseAlways<PlayContext>
    {
        protected override void Seed(PlayContext db)
        {
            Play play1 = new Play { Name = "kolobok", Autor = "narod", Genre = "tragedia", Data = new DateTime(2022, 10, 11) };
            Play play2 = new Play { Name = "pes ts vovk", Autor = "Ivanov", Genre = "akshen", Data = new DateTime(2022, 12, 11) };
            Play play3 = new Play { Name = "zolushka", Autor = "Anderson", Genre = "kazka", Data = new DateTime(2022, 10, 15) };
            db.Plays.Add(play1);
            db.Plays.Add(play2);
            db.Plays.Add(play3);
            for (int i =0; i<10; i++)
            {
                Ticket t = new Ticket { Play = play1, Price = 50 };
                db.Tikets.Add(t);
            }
            for (int i = 0; i < 10; i++)
            {
                Ticket t = new Ticket { Play = play1, Price = 100 };
                db.Tikets.Add(t);
            }
            for (int i = 0; i < 10; i++)
            {
                Ticket t = new Ticket { Play = play2, Price = 50 };
                db.Tikets.Add(t);
            }
            for (int i = 0; i < 10; i++)
            {
                Ticket t = new Ticket { Play = play2, Price = 100 };
                db.Tikets.Add(t);
            }
            for (int i = 0; i < 10; i++)
            {
                Ticket t = new Ticket { Play = play3, Price = 50 };
                db.Tikets.Add(t);
            }
            for (int i = 0; i < 10; i++)
            {
                Ticket t = new Ticket { Play = play3, Price = 100 };
                db.Tikets.Add(t);
            }

            base.Seed(db);
        }
    }
}