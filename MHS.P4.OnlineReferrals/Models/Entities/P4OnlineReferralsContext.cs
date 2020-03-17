using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MHS.P4.OnlineReferrals.Models.Entities
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
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

           

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
