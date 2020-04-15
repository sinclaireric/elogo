using Microsoft.EntityFrameworkCore;

namespace E_Logo.Models
{
    public class E_LogoContext : DbContext
    {
        public E_LogoContext(DbContextOptions<E_LogoContext> options)
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