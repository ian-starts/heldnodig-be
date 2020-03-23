using System;
using HeldNodig.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HeldNodig
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddPostgreSqlHeldNodigContext(
            this IServiceCollection services,
            string queryString,
            string migrationsAssemblyName,
            bool enableSensitiveDataLogging = false)
        {
            return services.AddDbContext<HeldNodigContext>(
                options =>
                {
                    options.EnableSensitiveDataLogging(enableSensitiveDataLogging);
                    options.UseNpgsql(
                        queryString,
                        parameters =>
                        {
                            parameters.EnableRetryOnFailure(10);
                            parameters
                                .MigrationsAssembly(migrationsAssemblyName);
                        });
                });
        }
    }
}