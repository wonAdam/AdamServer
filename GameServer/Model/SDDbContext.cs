using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Model
{
    internal class SDDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public DbSet<DummyDBUpdate> DummyDBUpdates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString: @"server=localhost;database=SDDatabase;uid=root;password=root;",
                new MySqlServerVersion(new Version(8, 0, 28)));
        }
    }
}
