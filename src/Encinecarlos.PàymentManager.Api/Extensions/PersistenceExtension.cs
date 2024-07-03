using Encinecarlos.PaymentManager.Application.Interfaces;
using Encinecarlos.PaymentManager.Domain.Entities;
using Encinecarlos.PaymentManager.Domain.Interfaces;
using Encinecarlos.PaymentManager.Infrastructure.Data;
using Encinecarlos.PaymentManager.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Encinecarlos.PàymentManager.Api.Extensions
{
    public static class PersistenceExtension
    {
        public static void AddPersistenceContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
        }
    }
}
