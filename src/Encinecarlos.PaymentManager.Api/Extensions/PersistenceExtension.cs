using Encinecarlos.PaymentManager.Domain.Entities;
using Encinecarlos.PaymentManager.Domain.Interfaces;
using Encinecarlos.PaymentManager.Infrastructure.Data;
using Encinecarlos.PaymentManager.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Encinecarlos.PaymentManager.Api.Extensions
{
    public static class PersistenceExtension
    {
        public static void AddPersistenceContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(ctx =>
            {
                var dbConfiguration = configuration.GetSection("ConnectionStrings");
                ctx.UseCosmos(dbConfiguration["Connection"], dbConfiguration["DatabaseId"]);
            });

            services.AddScoped<IRepository<Category, Guid>, CategoryRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
        }
    }
}
