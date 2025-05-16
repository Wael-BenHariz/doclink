using DocLink.Models;
using Microsoft.EntityFrameworkCore;

namespace DocLink.Data
{
    public class UserDbContext(DbContextOptions<UserDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<MedicalClinic> Clinics { get; set; }
        public DbSet<DoctorAvailability> DoctorAvailabilities { get; set; }
        public DbSet<DoctorReview> DoctorReviews { get; set; }
        public DbSet<HealthcareService> HealthcareServices { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<PaymentTransaction> PaymentTransactions { get; set; }
        public DbSet<AppointmentTimeSlot> AppointmentTimeSlots { get; set; }

        public DbSet<PatientMedicalRecord> PatientMedicalRecords { get; set; }

        public DbSet<MedicalClinic> MedicalClinics { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure User entity
            modelBuilder.Entity<User>()
                .HasMany(u => u.Availabilities)
                .WithOne(a => a.Doctor)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(u => u.ServicesOffered)
                .WithOne(s => s.Doctor)
                .HasForeignKey(s => s.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            // DoctorReview relationships
            modelBuilder.Entity<DoctorReview>()
                .HasOne(dr => dr.Doctor)
                .WithMany(d => d.ReviewsReceived)
                .HasForeignKey(dr => dr.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DoctorReview>()
                .HasOne(dr => dr.Patient)
                .WithMany(p => p.ReviewsWritten)
                .HasForeignKey(dr => dr.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            // DocLink relationships
            modelBuilder.Entity<Appointment>()
                .HasOne(ma => ma.Doctor)
                .WithMany(d => d.DoctorAppointments)
                .HasForeignKey(ma => ma.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(ma => ma.Patient)
                .WithMany(p => p.PatientAppointments)
                .HasForeignKey(ma => ma.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(ma => ma.Payment)
                .WithOne(p => p.Appointment)
                .HasForeignKey<PaymentTransaction>(p => p.AppointmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // PaymentTransaction relationships
            modelBuilder.Entity<PaymentTransaction>()
                .HasOne(pt => pt.User)
                .WithMany(u => u.PaymentTransactions)
                .HasForeignKey(pt => pt.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
