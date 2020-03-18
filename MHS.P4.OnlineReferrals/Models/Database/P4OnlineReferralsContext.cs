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
        public virtual DbSet<SalesReportExport> SalesReportExport { get; set; }

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

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("datetime");

                entity.Property(e => e.Gender).HasMaxLength(1);

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
                    .HasMaxLength(15);

                entity.Property(e => e.ReferringPhysicianFax).HasMaxLength(15);
            });

            modelBuilder.Entity<SalesReportExport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("SalesReportExport");

                entity.Property(e => e.FirstName).HasColumnName("firstName");

                entity.Property(e => e.FirstReferDate).HasColumnName("first_refer_date");

                entity.Property(e => e.LastName).HasColumnName("lastName");

                entity.Property(e => e.LastReferDate).HasColumnName("last_refer_date");

                entity.Property(e => e.Loop2014).HasColumnName("Loop_2014");

                entity.Property(e => e.Loop2015).HasColumnName("Loop_2015");

                entity.Property(e => e.Loop2016).HasColumnName("Loop_2016");

                entity.Property(e => e.Loop2017).HasColumnName("Loop_2017");

                entity.Property(e => e.Loop2018).HasColumnName("Loop_2018");

                entity.Property(e => e.Loop2019).HasColumnName("Loop_2019");

                entity.Property(e => e.Loop2020).HasColumnName("Loop_2020");

                entity.Property(e => e.MappedPhysicianId).HasColumnName("mappedPhysicianID");

                entity.Property(e => e.Novi2014).HasColumnName("Novi+_2014");

                entity.Property(e => e.Novi2015).HasColumnName("Novi+_2015");

                entity.Property(e => e.Novi2016).HasColumnName("Novi+_2016");

                entity.Property(e => e.Novi2017).HasColumnName("Novi+_2017");

                entity.Property(e => e.Novi2018).HasColumnName("Novi+_2018");

                entity.Property(e => e.Novi2019).HasColumnName("Novi+_2019");

                entity.Property(e => e.Novi2020).HasColumnName("Novi+_2020");

                entity.Property(e => e.Novi32014).HasColumnName("Novi3_2014");

                entity.Property(e => e.Novi32015).HasColumnName("Novi3_2015");

                entity.Property(e => e.Novi32016).HasColumnName("Novi3_2016");

                entity.Property(e => e.Novi32017).HasColumnName("Novi3_2017");

                entity.Property(e => e.Novi32018).HasColumnName("Novi3_2018");

                entity.Property(e => e.Novi32019).HasColumnName("Novi3_2019");

                entity.Property(e => e.Novi32020).HasColumnName("Novi3_2020");

                entity.Property(e => e.PocketEcg2014).HasColumnName("PocketECG_2014");

                entity.Property(e => e.PocketEcg2015).HasColumnName("PocketECG_2015");

                entity.Property(e => e.PocketEcg2016).HasColumnName("PocketECG_2016");

                entity.Property(e => e.PocketEcg2017).HasColumnName("PocketECG_2017");

                entity.Property(e => e.PocketEcg2018).HasColumnName("PocketECG_2018");

                entity.Property(e => e.PocketEcg2019).HasColumnName("PocketECG_2019");

                entity.Property(e => e.PocketEcg2020).HasColumnName("PocketECG_2020");

                entity.Property(e => e.Total2014).HasColumnName("total_2014");

                entity.Property(e => e.Total2015).HasColumnName("total_2015");

                entity.Property(e => e.Total2016).HasColumnName("total_2016");

                entity.Property(e => e.Total2017).HasColumnName("total_2017");

                entity.Property(e => e.Total2018).HasColumnName("total_2018");

                entity.Property(e => e.Total2019).HasColumnName("total_2019");

                entity.Property(e => e.Total2020).HasColumnName("total_2020");

                entity.Property(e => e.TotalReferral).HasColumnName("total_referral");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
