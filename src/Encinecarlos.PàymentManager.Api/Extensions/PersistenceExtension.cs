using Encinecarlos.PaymentManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Encinecarlos.PàymentManager.Api.Extensions
{
    public static class PersistenceExtension
    {
        public static void AddPersistenceContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(opt => 
            {
                opt.UseInMemoryDatabase("finance_manager");
            }); 
        }
    }
}
