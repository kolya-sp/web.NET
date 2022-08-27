using Microsoft.EntityFrameworkCore;
namespace dal
{
    public class Play
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Autor { get; set; }
        public string? Genre { get; set; }
        public DateTime? Data { get; set; }
        public List<Ticket> Tikets { get; set; } = new();
    }
    public class Ticket
    {
        public int Id { get; set; }
        public string? State { get; set; } = "free";
        public string? Owner { get; set; }
        public int Price { get; set; }
        public int PlayId { get; set; }
        public Play? Play { get; set; }
    }

    public class ApplicationContext : DbContext
    {
        //public DbSet<Play> Plays => Set<Play>();
        public DbSet<Play> Plays { get; set; } = null!;
        public DbSet<Ticket> Tikets => Set<Ticket>();
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=lab3db;Trusted_Connection=True;");
        }
    }
}