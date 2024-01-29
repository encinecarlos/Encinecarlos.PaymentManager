using System.Reflection;

namespace Encinecarlos.PaymentManager.Api.Extensions
{
    public static class MediatorExtension
    {
        public static void AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(Assembly.Load("Encinecarlos.PaymentManager.Application"));
            });
        }
    }
}
