using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Model
{
    internal class SDDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString: @"server=localhost;database=SDDatabase;uid=root;password=5500;",
                new MySqlServerVersion(new Version(10, 4, 17)));
        }

        public DbSet<AccountDb> Accounts { get; set; }
    }
}
