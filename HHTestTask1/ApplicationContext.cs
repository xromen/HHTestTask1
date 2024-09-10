using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHTestTask1
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Query> Queries { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<SignInHistory> SignInHistory { get; set; }
        public ApplicationContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=postgres_db;Username=postgres;Password=123;Database=postgres");
        }
    }
}
