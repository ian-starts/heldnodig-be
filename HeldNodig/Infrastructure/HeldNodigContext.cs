using System.Threading;
using System.Threading.Tasks;
using HeldNodig.Entities.HelpRequest;
using HeldNodig.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HeldNodig.Infrastructure
{
    public class HeldNodigContext : DbContext, IUnitOfWork
    {
        public HeldNodigContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<HelpRequest> HelpRequests { get; set; }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}