using HeldNodig.Entities.HelpRequest;

namespace HeldNodig.Infrastructure.Repositories.HelpRequest
{
    public class HelpRequestRepository: BaseRepository<Entities.HelpRequest.HelpRequest>, IHelpRequestRepository
    {
        public HelpRequestRepository(HeldNodigContext context)
            : base(context)
        {
        }
    }
}