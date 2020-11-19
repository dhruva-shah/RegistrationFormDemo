using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace RegistrationFormDemo.Models.Database
{
    public partial class RegistrationDemoContext : DbContext
    {
        private readonly IConfiguration _config;

        public RegistrationDemoContext()
        {
        }

        public RegistrationDemoContext(DbContextOptions<RegistrationDemoContext> options, IConfiguration configuration)
            : base(options)
        {
            _config = configuration;
        }
        //public RegistrationDemoContext(DbContextOptions<RegistrationDemoContext> options)
        //    : base(options)
        //{
        //}        //public RegistrationDemoContext(DbContextOptions<RegistrationDemoContext> options)
        //    : base(options)
        //{
        //}

        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<Province> Province { get; set; }
        public virtual DbSet<RegistrationEvent> RegistrationEvent { get; set; }
        public virtual DbSet<Registrations> Registrations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_config.GetConnectionString("RegistrationDemoEntities"));
                //optionsBuilder.UseSqlServer("Server=localhost\\MSSQLSERVER01;Database=RegistrationDemo;User Id=UFRegistrationDemo;Password=regDemo1234$;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Events>(entity =>
            {
                entity.HasKey(e => e.EventId);

                entity.Property(e => e.EventName).HasMaxLength(100);
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.HasKey(e=>e.ProvinceId);

                entity.Property(e => e.ProvinceName)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<RegistrationEvent>(entity =>
            {
                entity.HasKey(e=>e.RegistrationEventId);
                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.RegistrationEvent)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RegistrationEvent_Events");

                entity.HasOne(d => d.Registration)
                    .WithMany(p => p.RegistrationEvent)
                    .HasForeignKey(d => d.RegistrationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RegistrationEvent_Registrations");
            });

            modelBuilder.Entity<Registrations>(entity =>
            {
                entity.HasKey(e => e.RegistrationId);

                entity.Property(e => e.AddressLine1).HasMaxLength(500);

                entity.Property(e => e.AddressLine2).HasMaxLength(500);

                entity.Property(e => e.City).HasMaxLength(200);

                entity.Property(e => e.DateRegistered).HasColumnType("datetime");

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(500);

                entity.Property(e => e.FirstName).HasMaxLength(200);

                entity.Property(e => e.LastName).HasMaxLength(200);

                entity.Property(e => e.PhoneNumber).HasMaxLength(13);

                entity.Property(e => e.PostalCode).HasMaxLength(7);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
