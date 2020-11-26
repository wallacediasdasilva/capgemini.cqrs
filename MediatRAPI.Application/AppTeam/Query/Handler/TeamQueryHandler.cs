using MediatR;
using MediatRAPI.Application.AppTeam.Query.Request;
using MediatRAPI.Application.AppTeam.Query.Response;
using MediatRAPI.Domain.Interfaces.TeamRepository;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRAPI.Application.AppTeam.Query.Handler
{
    public class TeamQueryHandler : IRequestHandler<TeamGetCommand, TeamGetResponse>
    {
        private readonly ITeamRepository _teamRepository;
        public TeamQueryHandler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<TeamGetResponse> Handle(TeamGetCommand request, CancellationToken cancellationToken)
        {
            var teams = await _teamRepository.GetById(request.Id);

            TeamGetResponse teamGetResponse = new TeamGetResponse(teams.Name, teams.Modality, teams.QtdPlayers);

            return teamGetResponse;
        }
    }
}
