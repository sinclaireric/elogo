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
    }
}