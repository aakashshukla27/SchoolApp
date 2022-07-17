using Microsoft.EntityFrameworkCore;
using neu.csye.dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neu.csye.dal.DataContext
{
    internal class DatabaseContext : DbContext
    {
        public class OptionsBuild
        {
            public DbContextOptionsBuilder<DatabaseContext> OptionsBuilder { get; set; }
            public DbContextOptions<DatabaseContext> DatabaseOptions { get; set; }
            private AppConfiguration Settings { get; set; }

            public OptionsBuild()
            {
                //AppConfiguration class with our connection string.
                Settings = new AppConfiguration();
                //Inits a class which allows us to configure the database connection for a db context.
                //In our case allocate the connection string that our DatabaseContext(Db Sessions) will use.
                OptionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
                //Allocates the connection string to be used when connecting to a Microsoft Sql Database
                //OptionsBuilder.UseSqlServer(Settings.SqlConnectionString);
                OptionsBuilder.UseSqlServer(Settings.SqlConnectionString);
                //Allocates the set options to be used by the DbContext [Eg our connection string it must use when DatabaseContext it is initiated]
                DatabaseOptions = OptionsBuilder.Options;
            }
        }

        // We want the DatabaseContext to expect to have a DbContextOptions object available when it is created
        // So we have set a static OptionsBuild constructor
        // A static constructor is called automatically to initialize the class before the first instance is created or any static members are referenced
        public static OptionsBuild Options = new OptionsBuild();

        // DatabaseContext constructor 
        // Initializes a new instance of DbContext but with specific options
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        // Dbsets
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<ApplicationStatus> ApplicationStatuses { get; set; }
        public DbSet<Grade> Grades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Set defaults 
            DateTime modifiedDate = DateTime.MinValue;

            #region Applicant

            modelBuilder.Entity<Applicant>().ToTable("applicant");
            // Primary key and identity columns
            modelBuilder.Entity<Applicant>().HasKey(a => a.ApplicantId);
            modelBuilder.Entity<Applicant>().Property(a => a.ApplicantId).UseIdentityColumn(1, 1).IsRequired().HasColumnName("applicant_id");
            // Column settings
            modelBuilder.Entity<Applicant>().Property(a => a.FirstName).IsRequired(true).HasMaxLength(100).HasColumnName("applicant_first_name");
            modelBuilder.Entity<Applicant>().Property(a => a.LastName).IsRequired(true).HasMaxLength(100).HasColumnName("applicant_last_name");
            modelBuilder.Entity<Applicant>().Property(a => a.DateOfBirth).IsRequired(true).HasColumnName("applicant_birthdate");
            modelBuilder.Entity<Applicant>().Property(a => a.Email).IsRequired(false).HasMaxLength(256).HasColumnName("applicant_email");
            modelBuilder.Entity<Applicant>().Property(a => a.PhoneNumber).IsRequired(true).HasMaxLength(25).HasColumnName("applicant_number");
            modelBuilder.Entity<Applicant>().Property(a => a.CreationDate).IsRequired(true).HasDefaultValue(DateTime.UtcNow).HasColumnName("applicant_creation_date");
            modelBuilder.Entity<Applicant>().Property(a => a.ModifiedDate).IsRequired(true).HasColumnName("applicant_modified_date");
            //Relationships
            modelBuilder.Entity<Applicant>()
                .HasMany<Application>(a => a.Applications)
                .WithOne(a => a.Applicant)
                .HasForeignKey(a => a.ApplicantId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region Application Status
            modelBuilder.Entity<ApplicationStatus>().ToTable("application_status");
            // Primary key anmd identity columns
            modelBuilder.Entity<ApplicationStatus>().HasKey(a => a.ApplicationStatusId);
            modelBuilder.Entity<ApplicationStatus>().Property(a => a.ApplicationStatusId).UseIdentityColumn(1, 1).IsRequired().HasColumnName("application_status_id");
            // Column settings
            modelBuilder.Entity<ApplicationStatus>().HasIndex(a => a.ApplicationStatusName).IsUnique();
            modelBuilder.Entity<ApplicationStatus>().Property(a => a.ApplicationStatusName).IsRequired(true).HasMaxLength(100).HasColumnName("application_status_name");
            modelBuilder.Entity<ApplicationStatus>().Property(a => a.ApplicationStatusCreationDate).IsRequired(true).HasDefaultValue(DateTime.UtcNow).HasColumnName("application_status_creationdate");
            modelBuilder.Entity<ApplicationStatus>().Property(a => a.ApplicationStatusModifiedDate).IsRequired(true).HasDefaultValue(modifiedDate).HasColumnName("application_status_modifieddate");

            //RelationShips
            modelBuilder.Entity<ApplicationStatus>()
                   .HasMany<Application>(a => a.Applications)
                   .WithOne(a => a.ApplicationStatus)
                   .HasForeignKey(a => a.ApplicationStatusId)
                   .OnDelete(DeleteBehavior.Restrict);//Can't delete an ApplicationStatus, We can update it though.
            #endregion

            #region Grade
            modelBuilder.Entity<Grade>().ToTable("grade");
            //Primary Key & Identity Column
            modelBuilder.Entity<Grade>().HasKey(g => g.GradeID);
            modelBuilder.Entity<Grade>().Property(g => g.GradeID).UseIdentityColumn(1, 1).IsRequired().HasColumnName("grade_id");
            //COLUMN SETTINGS
            modelBuilder.Entity<Grade>().Property(g => g.GradeName).IsRequired(true).HasMaxLength(100).HasColumnName("grade_name");
            modelBuilder.Entity<Grade>().Property(g => g.GradeNumber).IsRequired(true).HasColumnName("grade_number");
            modelBuilder.Entity<Grade>().HasIndex(g => g.GradeName).IsUnique(); // Grade Name is Unique
            modelBuilder.Entity<Grade>().HasIndex(g => g.GradeNumber).IsUnique(); // Grade Number is Unique
            modelBuilder.Entity<Grade>().Property(g => g.GradeCapacity).IsRequired(true).HasColumnName("grade_capacity");
            modelBuilder.Entity<Grade>().Property(g => g.GradeCreationDate).IsRequired(true).HasDefaultValue(DateTime.UtcNow).HasColumnName("grade_creationdate");
            modelBuilder.Entity<Grade>().Property(g => g.GradeModifiedDate).IsRequired(true).HasDefaultValue(modifiedDate).HasColumnName("grade_modifieddate");

            //RelationShips
            modelBuilder.Entity<Grade>()
                   .HasMany<Application>(g => g.Applications)
                   .WithOne(app => app.Grade)
                   .HasForeignKey(a => a.GradeId)
                   .OnDelete(DeleteBehavior.Restrict);//Can't delete a Grade Ever, We can update it though.
            #endregion

            #region Application
            modelBuilder.Entity<Application>().ToTable("application");
            //Primary Key & Identity Column
            modelBuilder.Entity<Application>().HasKey(a => a.ApplicationId);
            modelBuilder.Entity<Application>().Property(a => a.ApplicationId).UseIdentityColumn(1, 1).IsRequired().HasColumnName("application_id");
            //COLUMN SETTINGS
            modelBuilder.Entity<Application>().Property(a => a.ApplicantId).IsRequired(true).HasColumnName("applicant_id");
            modelBuilder.Entity<Application>().Property(a => a.GradeId).IsRequired(true).HasColumnName("grade_id");
            modelBuilder.Entity<Application>().Property(a => a.ApplicationStatusId).IsRequired(true).HasColumnName("application_status_id");
            modelBuilder.Entity<Application>().Property(a => a.ApplicationDate).IsRequired(true).HasDefaultValue(DateTime.UtcNow).HasColumnName("application_creationdate");
            modelBuilder.Entity<Application>().Property(a => a.ApplicationModifiedDate).IsRequired(true).HasDefaultValue(modifiedDate).HasColumnName("application_modifieddate");
            modelBuilder.Entity<Application>().Property(a => a.SchoolYear).IsRequired(true).HasColumnName("application_schoolyear");
            //Relationships

            //Applicant link
            modelBuilder.Entity<Application>()
                 .HasOne<Applicant>(a => a.Applicant)
                 .WithMany(a => a.Applications)//CAN HAVE MANY APPLICATIONS
                 .HasForeignKey(a => a.ApplicantId)
                 .OnDelete(DeleteBehavior.NoAction);//Can delete an application.

            //Grade link
            modelBuilder.Entity<Application>()
                 .HasOne<Grade>(a => a.Grade)
                 .WithMany(a => a.Applications)//Grade is linked to many applications
                 .HasForeignKey(a => a.GradeId)
                 .OnDelete(DeleteBehavior.NoAction);//Can delete an application.

            //Status link
            modelBuilder.Entity<Application>()
                .HasOne<ApplicationStatus>(a => a.ApplicationStatus)
                .WithMany(a => a.Applications)//Status is linked to many applications
                .HasForeignKey(a => a.ApplicationStatusId)
                .OnDelete(DeleteBehavior.NoAction);//Can delete an application.
            #endregion
        }

    }
}
