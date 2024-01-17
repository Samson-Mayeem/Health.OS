using HealthOS.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Health.OS.APi.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }
       

        public DbSet<Patient> Patient { get; set; }

        public DbSet<Room> Room { get; set; }

        public DbSet<OnCall> OnCalls { get; set; }

        public DbSet<Usage> Usage { get; set; }

        //public DbSet<User> Staff { get; set; }

        public DbSet<Appointment> Appointment { get; set; }

        public DbSet<Medications> Medication { get; set; }

        public DbSet<Prescription> Prescription { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Affiliated> Affiliated { get; set; }

        public DbSet<Procedure> Procedures { get; set; }

        public DbSet<Treatment> Treatments { get; set; }

        public DbSet<UnderGoes> Undergoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Staff)
                .WithMany()
                .HasForeignKey(a => a.StaffId); // Assuming StaffId is the foreign key property
            modelBuilder.Entity<Department>()
                .HasOne(a => a.Staff)
                .WithMany()
                .HasForeignKey(a => a.StaffId);
            modelBuilder.Entity<OnCall>()
                .HasOne(a => a.Staff)
                .WithMany()
                .HasForeignKey(a => a.StaffId);

            modelBuilder.Entity<Prescription>()
                .HasOne(a => a.Staff)
                .WithMany()
                .HasForeignKey(a => a.DoctorId);
            modelBuilder.Entity<Prescription>()
                .HasOne(a => a.Medication)
                .WithMany()
                .HasForeignKey(a => a.MedicationId);
            modelBuilder.Entity<Treatment>()
                .HasOne(a => a.Staff)
                .WithMany()
                .HasForeignKey(a => a.StaffId);
            // Other configurations...

            base.OnModelCreating(modelBuilder);
        }
    }
}
