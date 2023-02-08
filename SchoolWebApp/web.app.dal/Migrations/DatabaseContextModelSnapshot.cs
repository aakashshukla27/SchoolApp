﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using web.app.dal.DataContext;

#nullable disable

namespace web.app.dal.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("web.app.dal.Entities.Applicant", b =>
                {
                    b.Property<int>("Applicant_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("applicant_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Applicant_ID"));

                    b.Property<DateTime>("Applicant_BirthDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("applicant_birthdate");

                    b.Property<DateTime>("Applicant_CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 2, 8, 3, 14, 51, 25, DateTimeKind.Utc).AddTicks(6781))
                        .HasColumnName("applicant_creationdate");

                    b.Property<DateTime>("Applicant_ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                        .HasColumnName("applicant_modifieddate");

                    b.Property<string>("Applicant_Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("applicant_name");

                    b.Property<string>("Applicant_Surname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("applicant_surname");

                    b.Property<string>("Contact_Email")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("contact_email");

                    b.Property<string>("Contact_Number")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("contact_number");

                    b.HasKey("Applicant_ID");

                    b.ToTable("applicant", (string)null);
                });

            modelBuilder.Entity("web.app.dal.Entities.Application", b =>
                {
                    b.Property<int>("Application_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("application_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Application_ID"));

                    b.Property<int>("Applicant_ID")
                        .HasColumnType("int")
                        .HasColumnName("applicant_id");

                    b.Property<int>("ApplicationStatus_ID")
                        .HasColumnType("int")
                        .HasColumnName("application_status_id");

                    b.Property<DateTime>("Application_CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 2, 8, 3, 14, 51, 28, DateTimeKind.Utc).AddTicks(2735))
                        .HasColumnName("application_creationdate");

                    b.Property<DateTime>("Application_ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                        .HasColumnName("application_modifieddate");

                    b.Property<int>("Grade_ID")
                        .HasColumnType("int")
                        .HasColumnName("grade_id");

                    b.Property<int>("SchoolYear")
                        .HasColumnType("int")
                        .HasColumnName("application_schoolyear");

                    b.HasKey("Application_ID");

                    b.HasIndex("Applicant_ID");

                    b.HasIndex("ApplicationStatus_ID");

                    b.HasIndex("Grade_ID");

                    b.ToTable("application", (string)null);
                });

            modelBuilder.Entity("web.app.dal.Entities.ApplicationStatus", b =>
                {
                    b.Property<int>("ApplicationStatus_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("application_status_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ApplicationStatus_ID"));

                    b.Property<DateTime>("ApplicationStatus_CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 2, 8, 3, 14, 51, 26, DateTimeKind.Utc).AddTicks(5834))
                        .HasColumnName("application_status_creationdate");

                    b.Property<string>("ApplicationStatus_Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("application_status_name");

                    b.Property<DateTime>("ApplicationtStatus_ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                        .HasColumnName("application_status_modifieddate");

                    b.HasKey("ApplicationStatus_ID");

                    b.HasIndex("ApplicationStatus_Name")
                        .IsUnique();

                    b.ToTable("application_status", (string)null);
                });

            modelBuilder.Entity("web.app.dal.Entities.Grade", b =>
                {
                    b.Property<int>("Grade_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("grade_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Grade_ID"));

                    b.Property<int>("Grade_Capacity")
                        .HasColumnType("int")
                        .HasColumnName("grade_capacity");

                    b.Property<DateTime>("Grade_CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 2, 8, 3, 14, 51, 27, DateTimeKind.Utc).AddTicks(6471))
                        .HasColumnName("grade_creationdate");

                    b.Property<DateTime>("Grade_ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                        .HasColumnName("grade_modifieddate");

                    b.Property<string>("Grade_Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("grade_name");

                    b.Property<int>("Grade_Number")
                        .HasColumnType("int")
                        .HasColumnName("grade_number");

                    b.HasKey("Grade_ID");

                    b.HasIndex("Grade_Name")
                        .IsUnique();

                    b.HasIndex("Grade_Number")
                        .IsUnique();

                    b.ToTable("grade", (string)null);
                });

            modelBuilder.Entity("web.app.dal.Entities.Application", b =>
                {
                    b.HasOne("web.app.dal.Entities.Applicant", "Applicant")
                        .WithMany("Applications")
                        .HasForeignKey("Applicant_ID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("web.app.dal.Entities.ApplicationStatus", "ApplicationStatus")
                        .WithMany("Applications")
                        .HasForeignKey("ApplicationStatus_ID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("web.app.dal.Entities.Grade", "Grade")
                        .WithMany("Applications")
                        .HasForeignKey("Grade_ID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Applicant");

                    b.Navigation("ApplicationStatus");

                    b.Navigation("Grade");
                });

            modelBuilder.Entity("web.app.dal.Entities.Applicant", b =>
                {
                    b.Navigation("Applications");
                });

            modelBuilder.Entity("web.app.dal.Entities.ApplicationStatus", b =>
                {
                    b.Navigation("Applications");
                });

            modelBuilder.Entity("web.app.dal.Entities.Grade", b =>
                {
                    b.Navigation("Applications");
                });
#pragma warning restore 612, 618
        }
    }
}
