using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MHS.P4.OnlineReferrals.Models.Database
{
    public partial class P4OnlineReferralsContext : DbContext
    {
        public P4OnlineReferralsContext()
        {
        }

        public P4OnlineReferralsContext(DbContextOptions<P4OnlineReferralsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Indication> Indication { get; set; }
        public virtual DbSet<Medication> Medication { get; set; }
        public virtual DbSet<PocketReferrals> PocketReferrals { get; set; }
        public virtual DbSet<TestType> TestType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=pcs-db01;Database=P4OnlineReferrals;user id=P4OnlineReferrals;password=forReferrals2020;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Indication>(entity =>
            {
                entity.Property(e => e.IndicationId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.NotesPrompt).HasMaxLength(10);
            });

            modelBuilder.Entity<Medication>(entity =>
            {
                entity.Property(e => e.MedicationId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.NotesPrompt).HasMaxLength(10);
            });

            modelBuilder.Entity<PocketReferrals>(entity =>
            {
                entity.HasKey(e => e.ReferralId);

                entity.Property(e => e.City).HasMaxLength(150);

                entity.Property(e => e.ConfirmationEmail)
                    .HasColumnName("confirmationEmail")
                    .HasMaxLength(500);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmailResult).HasColumnName("emailResult");

                entity.Property(e => e.Gender).HasMaxLength(1);

                entity.Property(e => e.InsuranceType).HasMaxLength(100);

                entity.Property(e => e.InterpretingPhysician).HasMaxLength(500);

                entity.Property(e => e.IsDefibrillator).HasColumnName("isDefibrillator");

                entity.Property(e => e.IsPacemaker).HasColumnName("isPacemaker");

                entity.Property(e => e.IsTest2Weeks).HasColumnName("isTest2Weeks");

                entity.Property(e => e.IsTestInconclusive).HasColumnName("isTestInconclusive");

                entity.Property(e => e.PatientCcfax)
                    .HasColumnName("PatientCCFax")
                    .HasMaxLength(100);

                entity.Property(e => e.PatientCcname)
                    .HasColumnName("PatientCCName")
                    .HasMaxLength(500);

                entity.Property(e => e.PatientHealthCardNum).HasMaxLength(50);

                entity.Property(e => e.PatientHealthCardVersion).HasMaxLength(10);

                entity.Property(e => e.PatientName).HasMaxLength(500);

                entity.Property(e => e.PatientPhone).HasMaxLength(500);

                entity.Property(e => e.PostalCode).HasMaxLength(7);

                entity.Property(e => e.Province).HasMaxLength(150);

                entity.Property(e => e.ReferringPhysician).HasMaxLength(500);

                entity.Property(e => e.ReferringPhysicianCpso)
                    .HasColumnName("ReferringPhysicianCPSO")
                    .HasMaxLength(30);

                entity.Property(e => e.ReferringPhysicianFax).HasMaxLength(15);

                entity.Property(e => e.TestRequested).HasMaxLength(100);

                entity.HasOne(d => d.TestTypeNavigation)
                    .WithMany(p => p.PocketReferrals)
                    .HasForeignKey(d => d.TestType)
                    .HasConstraintName("FK_PocketReferrals_TestType");
            });

            modelBuilder.Entity<TestType>(entity =>
            {
                entity.HasKey(e => e.TestId);

                entity.Property(e => e.TestName).HasMaxLength(500);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
