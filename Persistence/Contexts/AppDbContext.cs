using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Entropia_CS_React.Domain.Models;

namespace Entropia_CS_React.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public DbSet<CustomItem> CustomItems { get; set; }
        public DbSet<StandartItem> StandartItems { get; set; }

        public DbSet<UserStandartItem> UserStandartItems { get; set; }

        private readonly IConfiguration Configuration;

        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlServer(Configuration.GetConnectionString("SignupVerTutorDatabase"));
        }
    }
}
