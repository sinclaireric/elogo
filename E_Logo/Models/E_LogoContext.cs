using System;
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
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Stimuli> Stimulis { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<ResponsesPatient> ResponsesPatient { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<SpeechTherapist>().HasIndex(u => u.Email).IsUnique(true);
            modelBuilder.Entity<Patient>().HasIndex(u => u.Fullname).IsUnique(true);
            modelBuilder.Entity<Task>().HasIndex(u => u.Name).IsUnique(true);
            modelBuilder.Entity<Stimuli>().HasIndex(u => u.Name).IsUnique(true);

            modelBuilder.Entity<ResponsesPatient>().HasKey(ut => new { ut.PatientID, ut.ResponseID });

            modelBuilder.Entity<Patient>().HasOne(p => p.SpeechTherapist).WithMany(st => st.Patients).HasForeignKey(p => p.SpeechTherapistID).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Response>().HasOne(r => r.Stimuli).WithMany(s => s.Responses).HasForeignKey(r => r.StimuliID).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Stimuli>().HasOne(s => s.Task).WithMany(t => t.Stimulis).HasForeignKey(r => r.TaskID).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ResponsesPatient>().HasOne(rp => rp.Patient).WithMany(p => p.ResponsesPatient).HasForeignKey(p => p.PatientID).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ResponsesPatient>().HasOne(rp => rp.Response).WithMany(t => t.ResponsesPatients).HasForeignKey(p => p.ResponseID).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
