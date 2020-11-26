using AutoMapper;
using MediatR;
using MediatRAPI.Application.AppTeam.Command;
using MediatRAPI.Domain.Interfaces.TeamRepository;
using MediatRAPI.Domain.Team;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRAPI.Application.AppTeam.Handler
{
    public class TeamCommandHandler : IRequestHandler<TeamCreateCommand, string>, IRequestHandler<TeamUpdateCommand, string>, IRequestHandler<TeamDeleteCommand, string>
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;

        public TeamCommandHandler(IMediator mediator, ITeamRepository teamRepository, IMapper mapper)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(TeamCreateCommand request, CancellationToken cancellationToken)
        {
            await _teamRepository.Create(_mapper.Map<TeamEntity>(request));

            return await Task.FromResult("Cliente registrado com sucesso");
        }

        public async Task<string> Handle(TeamUpdateCommand request, CancellationToken cancellationToken)
        {
            var teams = _mapper.Map<TeamEntity>(request);

            teams.Id = request.Id;

            await _teamRepository.Update(teams);

            _teamRepository.SaveChanges();

            return await Task.FromResult("Cliente atualizado com sucesso");
        }

        public async Task<string> Handle(TeamDeleteCommand request, CancellationToken cancellationToken)
        {
            await _teamRepository.Delete(_mapper.Map<TeamEntity>(request));

            _teamRepository.SaveChanges();

            return await Task.FromResult("Cliente deletado com sucesso");
        }
    }
}
