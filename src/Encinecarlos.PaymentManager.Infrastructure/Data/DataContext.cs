using Encinecarlos.PaymentManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Encinecarlos.PaymentManager.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("payments");
        }
    }
}
