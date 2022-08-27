using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lab4.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lab4.Models;
using System.Data.Entity;
namespace lab4.Controllers
{
    public class HomeController : Controller
    {
        // создаем контекст данных
        public PlayContext db = new PlayContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Plays()
        {
            var plays = db.Plays.Include(p => p.Tikets);
            return View(plays.ToList());
        }
        [HttpGet]
        public ActionResult Sell()
        {
            // Формируем список вистав для передачи в представление
            SelectList plays = new SelectList(db.Plays, "Id", "Name");
            ViewBag.Plays = plays;
            return View();
        }
        [HttpPost]
        public ActionResult Sell(Ticket ticket)
        {
            //Добавляем ticket в таблицу
            ticket.State = "sold";
            db.Tikets.Add(ticket);
            db.SaveChanges();
            // перенаправляем на главную страницу
            return RedirectToAction("Index");
        }
        public ActionResult Book()
        {
            // Формируем список вистав для передачи в представление
            SelectList plays = new SelectList(db.Plays, "Id", "Name");
            ViewBag.Plays = plays;
            return View();
        }
        [HttpPost]
        public ActionResult Book(Ticket ticket)
        {
            //Добавляем ticket в таблицу
            ticket.State = "booking";
            db.Tikets.Add(ticket);
            db.SaveChanges();
            // перенаправляем на главную страницу
            return RedirectToAction("Index");
        }
        public ActionResult BookingSold(string Owner, string PlayName)
        {

            IQueryable<Ticket> tickets = db.Tikets.Include(t => t.Play).Where(t=>t.State=="booking");
            if (!String.IsNullOrEmpty(Owner)&& Owner!="всі")
            {
                tickets = tickets.Where(t => t.Owner == Owner);
            }
            if (!String.IsNullOrEmpty(PlayName) && PlayName != "всі")
            {
                tickets = tickets.Where(t => t.Play.Name == PlayName);
            }
            var t0 = tickets.ToList();
            t0.Insert(0,new Ticket { Owner ="всі", Play = new Play { Name = "всі"} });
            TicketsListViewModel tlvm = new TicketsListViewModel
            {
                Tickets = tickets.ToList(),
                Owner = new SelectList(t0, "Owner", "Owner"),
                PlayName = new SelectList(t0, "Play.Name", "Play.Name"),
            };
            return View(tlvm);
        }
        public ActionResult BookingSold1(int id)
        {
            Ticket t1 = db.Tikets.FirstOrDefault(t=>t.Id==id);
            if (t1 != null)
            {
                t1.State = "sold";
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult BookingDelete(int id)
        {
            Ticket t1 = db.Tikets.FirstOrDefault(t => t.Id == id);
            if (t1 != null)
            {
                db.Tikets.Remove(t1);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Plays2(string Autor, string Name, string Genre, DateTime? Data)
        {
            if (Data != null) //виправив проблему з кодуванням, місяць і день браузер міняв місцями
            {
                Data = new DateTime(Data.Value.Year, Data.Value.Day, Data.Value.Month);
            }
            IQueryable<Play> plays = db.Plays;
            if (!String.IsNullOrEmpty(Autor) && Autor != "всі")
            {
                plays = plays.Where(p => p.Autor == Autor);
            }
            if (!String.IsNullOrEmpty(Name) && Name != "всі")
            {
                plays = plays.Where(p => p.Name == Name);
            }
            if (!String.IsNullOrEmpty(Genre) && Genre != "всі")
            {
                plays = plays.Where(p => p.Genre == Genre);
            }
            if (Data!=null && Data.Value != new DateTime(1,1,1))
            {
                plays = plays.Where(p => p.Data==Data.Value);
            }

            var p0 = plays.ToList();
            p0.Insert(0, new Play { Autor = "всі", Name="всі", Genre="всі", Data = new DateTime(1,1,1) });

            PlayListViewModel plvm = new PlayListViewModel
            {
                Plays = plays.ToList(),
                Autor = new SelectList(p0, "Autor", "Autor"),

                Name = new SelectList(p0, "Name", "Name"),
                Genre = new SelectList(p0, "Genre", "Genre"),
                Data = new SelectList(p0, "Data", "Data"),
            };
            //ViewBag.data = Data;
            return View(plvm);
        }
        public ActionResult Tickets()
        {

            return View(db.Tikets.Include(t=>t.Play).ToList());
        }
    }
}