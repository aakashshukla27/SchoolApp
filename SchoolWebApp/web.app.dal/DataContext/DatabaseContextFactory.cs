using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web.app.dal.DataContext
{
    //Allows for db migrations and db structure updates and changes from this DAL project 
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        //We simply providing the Database Context which must be used when performing a database migration.
        public DatabaseContext CreateDbContext(string[] args)
        {
            // Get our connection string - VIA AppConfiguration Class
            AppConfiguration Settings = new AppConfiguration();
            // Init A new options builder so we can tell it what information it must use when connecting the the db
            DbContextOptionsBuilder<DatabaseContext> OptionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            // Tell the options builder what type of database its connecting to and which connection string it must use
            OptionsBuilder.UseSqlServer(Settings.SqlConnectionString);
            // We return a new instance of the database context with the all required db connection info
            // So it can then be used to do a db migrations.
            return new DatabaseContext(OptionsBuilder.Options);
        }
    }
}
