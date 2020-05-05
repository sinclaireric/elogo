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
         public DbSet<Patient> Patients { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SpeechTherapist>().HasIndex(u => u.Email).IsUnique(true);
            modelBuilder.Entity<Patient>().HasOne(p => p.SpeechTherapist).WithMany(st => st.Patients).HasForeignKey(p => p.SpeechTherapistID).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SpeechTherapist>().HasData(
                new SpeechTherapist() { Id = 1, Email = "matilde", Password = "matilde", Firstname = "Matilde", Lastname = "Gravano" },
                new SpeechTherapist() { Id = 2, Email = "pelagie", Password = "pelagie", Firstname = "Pélagie", Lastname = "Lacroix" }
            );
            modelBuilder.Entity<Patient>().HasData(
                new Patient() { Id = 1, Fullname = "Pablo cousu", Results = "not defined", Diagnostique = "dyslexique", LastTaskDone = "no one", SpeechTherapistID = 2 },
                new Patient() { Id = 2, Fullname = "Maido kapo", Results = "not defined", Diagnostique = "dyslexique", LastTaskDone = "5B", SpeechTherapistID = 1 },
                new Patient() { Id = 3, Fullname = "Jojo tousk", Results = "0/20", Diagnostique = "aphasique", LastTaskDone = "17A", SpeechTherapistID = 1 }

            );
        }
    }
}
