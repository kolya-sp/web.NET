using dal;
using Microsoft.EntityFrameworkCore;

namespace bll
{
    public class theatre
    {
        public theatre() 
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                //db.Database.EnsureDeleted();
                //db.Database.EnsureCreated();
            }
        }
        public string get_playsandtickets()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                string rezult = "";
                var plays2 = db.Plays.Include(p => p.Tikets);
                foreach (var p in plays2)
                {
                    rezult += $"play: {p.Name} Genre: {p.Genre} data: {p.Data}\n";
                    rezult += "Непроданi бiлети\n";
                    var tickets1 = p.Tikets.Where(t => t.State == "free").GroupBy(t => t.Price).Select(g => new
                    {
                        g.Key,
                        Count = g.Count()
                    });
                    foreach (var t in tickets1)
                    {
                        rezult += $"Prise:{t.Key} Count:{t.Count}\n";
                    }


                    rezult += "Заброньованi бiлети\n";
                    var tickets2 = p.Tikets.Where(t => t.State == "booked").GroupBy(t => t.Price).Select(g => new
                    {
                        g.Key,
                        Count = g.Count()
                    });
                    foreach (var t in tickets2)
                    {
                        rezult += $"Prise:{t.Key} Count:{t.Count}\n";
                    }

                    rezult += "Проданi бiлети\n";
                    var tickets3 = p.Tikets.Where(t => t.State == "sold").GroupBy(t => t.Price).Select(g => new
                    {
                        g.Key,
                        Count = g.Count()
                    });
                    foreach (var t in tickets3)
                    {
                        rezult += $"Prise:{t.Key} Count:{t.Count}\n";
                    }
                    rezult += "---------------------------------------\n";
                }
                return rezult;
            }
        }
        public void PlayAdd(string name, string autor, string genre, int y, int m, int d, int price1, int count1, int price2, int count2)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Play pl = new Play { Name = name, Autor = autor, Genre = genre, Data = new DateTime(y, m, d) };
                db.Plays.Add(pl);
                for (int i = 0; i < count1; i++)
                {
                    Ticket t = new() { Price = price1, Play = pl };
                    db.Tikets.Add(t);
                }
                for (int i = 0; i < count2; i++)
                {
                    Ticket t = new() { Price = price2, Play = pl };
                    db.Tikets.Add(t);
                }
                db.SaveChanges();
            }
        }
        public void Playdell(string name)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Play? pl = db.Plays.Include(p => p.Tikets).FirstOrDefault(p => p.Name == name);
                if (pl != null)
                {
                    db.Plays.Remove(pl);
                    db.SaveChanges();
                }
            }
        }
        public bool selling(string Pname, int price, string Owner)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Ticket? t = db.Tikets.Include(t => t.Play).FirstOrDefault(t => (t.Play.Name == Pname && t.State == "free" && t.Price == price));
                if (t != null)
                {
                    t.State = "sold";
                    t.Owner = Owner;
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool booking(string Pname, int price, string Owner)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Ticket? t = db.Tikets.Include(t => t.Play).FirstOrDefault(t => (t.Play.Name == Pname && t.State == "free" && t.Price == price));
                if (t != null)
                {
                    t.State = "booked";
                    t.Owner = Owner;
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool bookingsell(string Pname, int price, string Owner)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Ticket? t = db.Tikets.Include(t => t.Play).FirstOrDefault(t => (t.Play.Name == Pname && t.State == "booked" && t.Price == price));
                if (t != null)
                {
                    t.State = "sold";
                    t.Owner = Owner;
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public string get_plays()
        {
            string rezult = "";
            using (ApplicationContext db = new ApplicationContext())
            {
                var plays = db.Plays.ToList();
                rezult += "Список вистав:\n";
                foreach (Play p in plays)
                {
                    rezult += $"{p.Name} - {p.Autor} - {p.Genre} - {p.Data}\n";
                }
            }                
            return rezult;
        }
        public void dell_all()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Database.EnsureDeleted();
            }
        }
        public void add_testdata() 
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                PlayAdd("kolobok", "Narod", "tragediya", 2020, 07, 11, 50, 20, 100, 20);
                PlayAdd("zolushka", "Anderson", "tragediya", 2020, 07, 11, 50, 20, 100, 20);
                PlayAdd("pes ta vovk", "Ivanon", "ekshen", 2020, 07, 11, 50, 20, 100, 20);
            }
        }

    }
}