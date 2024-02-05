using Encinecarlos.PaymentManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Encinecarlos.PaymentManager.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>().ToContainer("Transactions");
        }
    }
}
