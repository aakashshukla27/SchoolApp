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


            #endregion
        }

    }
}
