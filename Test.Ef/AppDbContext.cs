using System;
using System.Data.Entity;
using System.Linq;
using Task.Core.Models;

namespace Test.Ef
{
    public class AppDbContext : DbContext
    {
        
        public AppDbContext()
            : base("name=AppDbContext")
        {
        }

        public DbSet<Expense> Expenses { get; set; }

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

}