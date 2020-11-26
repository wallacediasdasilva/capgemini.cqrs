using MediatRAPI.Domain.Interfaces.TeamRepository;
using MediatRAPI.Domain.Team;
using MediatRAPI.Persistence.EFCore.Context;
using MediatRAPI.Persistence.EFCore.Repository.Core;

namespace MediatRAPI.Persistence.EFCore.Repository.TeamRepository
{
    public class TeamRepository : Repository<TeamEntity>, ITeamRepository
    {
        public TeamRepository(MediatRContext mediatRContext) : base(mediatRContext)
        {
        }
    }
}
