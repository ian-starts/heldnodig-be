using System;
using System.Threading.Tasks;
using HeldNodig.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HeldNodig
{
    public static class HostExtensions
    {

        
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetService<HeldNodigContext>();
                context.Database.Migrate();
            }

            return host;
        }

        public static IHost ConnectToDatabase(this IHost host, int maxRetryCount, TimeSpan retryDelay)
        {
            {
                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var context = services.GetService<HeldNodigContext>();
                    var connected = false;
                    var retries = 0;
                    while (!connected)
                    {
                        try
                        {
                            context.Database.CanConnect();
                            connected = true;
                        }
                        catch (Exception e)
                        {
                            retries++;
                            if (retries > maxRetryCount)
                            {
                                throw e;
                            }

                            Task.Delay(retryDelay).Wait();
                        }
                    }
                }

                return host;
            }
        }
    }
}