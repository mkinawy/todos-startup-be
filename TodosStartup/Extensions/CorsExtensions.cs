using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodosStartup.Constants;

namespace TodosStartup.Extensions
{
    public static class CorsExtensions
    {
        public static IServiceCollection ConfigureCors(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var configuration = serviceProvider.GetService<IConfiguration>();

            var originsAllowed = configuration.GetSection(CorsConstants.CorsOriginSectionKey)
                .GetChildren()
                .Select(c => c.Value)
                .ToArray();

            if (!originsAllowed.Any())
                return services;

            services.AddCors(options =>
            {
                options.AddPolicy(CorsConstants.CorsPolicyName, policy =>
                {
                    policy
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .WithOrigins(originsAllowed);
                });
            });

            return services;
        }
    }
}