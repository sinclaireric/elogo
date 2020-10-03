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
            modelBuilder.Entity<Patient>().HasIndex(u => u.Fullname).IsUnique(true);
            modelBuilder.Entity<Task>().HasIndex(u => u.Name).IsUnique(true);
            modelBuilder.Entity<Stimuli>().HasIndex(u => u.Name).IsUnique(true);


            modelBuilder.Entity<Patient>().HasOne(p => p.SpeechTherapist).WithMany(st => st.Patients).HasForeignKey(p => p.SpeechTherapistID).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Response>().HasOne(r => r.Stimuli).WithMany(s => s.Responses).HasForeignKey(r => r.StimuliID).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Stimuli>().HasOne(s => s.Task).WithMany(t => t.Stimulis).HasForeignKey(r => r.TaskID).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SpeechTherapist>().HasData(
                new SpeechTherapist() { Id = 1, Email = "matilde", Password = "matilde", Firstname = "Matilde", Lastname = "Gravano" },
                new SpeechTherapist() { Id = 2, Email = "pelagie", Password = "pelagie", Firstname = "Pélagie", Lastname = "Campos" }
            );
            modelBuilder.Entity<Patient>().HasData(
                new Patient() { Id = 1, Fullname = "Pablo cousu", Diagnostique = "dyslexique", LastTaskDone = "no one", SpeechTherapistID = 2 },
                new Patient() { Id = 2, Fullname = "Maido kapo", Diagnostique = "dyslexique", LastTaskDone = "5B", SpeechTherapistID = 1 },
                new Patient() { Id = 3, Fullname = "Jojo tousk", Diagnostique = "aphasique", LastTaskDone = "17A", SpeechTherapistID = 1 },
                new Patient() { Id = 4, Fullname = "Charline Dupont", Diagnostique = "dyslexique", LastTaskDone = "5B", SpeechTherapistID = 1 },
                new Patient() { Id = 5, Fullname = "Benoit Blanc", Diagnostique = "dyslexique", LastTaskDone = "5B", SpeechTherapistID = 2 },
                new Patient() { Id = 6, Fullname = "Maxime Gros", Diagnostique = "dyslexique", LastTaskDone = "5B", SpeechTherapistID = 2 },
                new Patient() { Id = 7, Fullname = "Elodie Filou", Diagnostique = "dyslexique", LastTaskDone = "5B", SpeechTherapistID = 1 },
                new Patient() { Id = 8, Fullname = "Julie Desprez", Diagnostique = "dyslexique", LastTaskDone = "5B", SpeechTherapistID = 2 }


            );
            modelBuilder.Entity<Task>().HasData(
                new Task() { Id = 1, Name = "Tâche 1: appariement de lettres" },
                new Task() { Id = 2, Name = "Tâche 2 : Lecture de mots" },
                new Task() { Id = 3, Name = "Tâche 3: Dénomination des objets" }
            );

            modelBuilder.Entity<Stimuli>().HasData(
                new Stimuli() { Id = 1, Name = "A", TaskID = 1 },
                new Stimuli() { Id = 2, Name = "B", TaskID = 1 },
                new Stimuli() { Id = 3, Name = "C", TaskID = 1 },
                new Stimuli() { Id = 4, Name = "D", TaskID = 1 }
            );
            modelBuilder.Entity<Response>().HasData(
                new Response() { Id = 1, Type = Types.Choices, StimuliID = 1, Choice = "a" },
                new Response() { Id = 2, Type = Types.Choices, StimuliID = 1, Choice = "h" },

                new Response() { Id = 3, Type = Types.Choices, StimuliID = 2, Choice = "d" },
                new Response() { Id = 4, Type = Types.Choices, StimuliID = 2, Choice = "b" },

                new Response() { Id = 5, Type = Types.Choices, StimuliID = 3, Choice = "o" },
                new Response() { Id = 6, Type = Types.Choices, StimuliID = 3, Choice = "c" },

                new Response() { Id = 7, Type = Types.Choices, StimuliID = 4, Choice = "n" },
                new Response() { Id = 8, Type = Types.Choices, StimuliID = 4, Choice = "d" }
            );

        }
    }
}
