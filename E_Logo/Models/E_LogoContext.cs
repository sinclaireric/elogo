using Microsoft.EntityFrameworkCore;

namespace E_LOGO.Models
{
    public class E_LOGOContext : DbContext
    {
        public E_LOGOContext(DbContextOptions<E_LOGOContext> options)
            : base(options)
        {
        }

        public DbSet<SpeechTherapist> SpeechTherapists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SpeechTherapist>().HasData(
                new SpeechTherapist() { Id = 1, Username = "matilde", Password = "matilde", Firstname = "Matilde", Lastname = "Gravano" },
                new SpeechTherapist() { Id = 2, Username = "pelagie", Password = "pelagie", Firstname = "Pélagie", Lastname = "Lacroix" }
            );
        }
    }
}