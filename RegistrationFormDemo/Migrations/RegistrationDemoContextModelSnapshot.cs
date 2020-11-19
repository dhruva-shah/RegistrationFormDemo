﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RegistrationFormDemo.Models.Database;

namespace RegistrationFormDemo.Migrations
{
    [DbContext(typeof(RegistrationDemoContext))]
    partial class RegistrationDemoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RegistrationFormDemo.Models.Database.Events", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EventName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("Position")
                        .HasColumnType("int");

                    b.HasKey("EventId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("RegistrationFormDemo.Models.Database.Province", b =>
                {
                    b.Property<int>("ProvinceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProvinceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("ProvinceId");

                    b.ToTable("Province");
                });

            modelBuilder.Entity("RegistrationFormDemo.Models.Database.RegistrationEvent", b =>
                {
                    b.Property<int>("RegistrationEventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("RegistrationId")
                        .HasColumnType("int");

                    b.HasKey("RegistrationEventId");

                    b.HasIndex("EventId");

                    b.HasIndex("RegistrationId");

                    b.ToTable("RegistrationEvent");
                });

            modelBuilder.Entity("RegistrationFormDemo.Models.Database.Registrations", b =>
                {
                    b.Property<int>("RegistrationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressLine1")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("AddressLine2")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("DateRegistered")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("Dob")
                        .HasColumnName("DOB")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<bool?>("IsFirstTime")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(13)")
                        .HasMaxLength(13);

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(7)")
                        .HasMaxLength(7);

                    b.Property<int>("Province")
                        .HasColumnType("int");

                    b.Property<bool?>("SendConfirmationEmail")
                        .HasColumnType("bit");

                    b.HasKey("RegistrationId");

                    b.ToTable("Registrations");
                });

            modelBuilder.Entity("RegistrationFormDemo.Models.Database.RegistrationEvent", b =>
                {
                    b.HasOne("RegistrationFormDemo.Models.Database.Events", "Event")
                        .WithMany("RegistrationEvent")
                        .HasForeignKey("EventId")
                        .HasConstraintName("FK_RegistrationEvent_Events")
                        .IsRequired();

                    b.HasOne("RegistrationFormDemo.Models.Database.Registrations", "Registration")
                        .WithMany("RegistrationEvent")
                        .HasForeignKey("RegistrationId")
                        .HasConstraintName("FK_RegistrationEvent_Registrations")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
