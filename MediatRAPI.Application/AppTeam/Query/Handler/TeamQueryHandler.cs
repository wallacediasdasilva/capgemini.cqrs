using AutoMapper;
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
        private readonly IMapper _mapper;
        public TeamQueryHandler(ITeamRepository teamRepository, IMapper mapper)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
        }

        public async Task<TeamGetResponse> Handle(TeamGetCommand request, CancellationToken cancellationToken)
        {
            return _mapper.Map<TeamGetResponse>( await _teamRepository.GetById(request.Id).ConfigureAwait(false));
        }
    }
}
