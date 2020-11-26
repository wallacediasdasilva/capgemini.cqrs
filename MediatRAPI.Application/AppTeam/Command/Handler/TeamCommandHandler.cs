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

        public TeamCommandHandler(IMediator mediator, ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<string> Handle(TeamCreateCommand request, CancellationToken cancellationToken)
        {
            var team = new TeamEntity(request.Name, request.Modality, request.QtdPlayers);

            await _teamRepository.Create(team);

            return await Task.FromResult("Cliente registrado com sucesso");
        }

        public async Task<string> Handle(TeamUpdateCommand request, CancellationToken cancellationToken)
        {
            var team = new TeamEntity( request.Name, request.Modality, request.QtdPlayers);
            team.Id = request.Id;
            await _teamRepository.Update(request.Id, team);

            _teamRepository.SaveChanges();

            return await Task.FromResult("Cliente atualizado com sucesso");
        }

        public async Task<string> Handle(TeamDeleteCommand request, CancellationToken cancellationToken)
        {
            var team = new TeamEntity(request.Id);

            await _teamRepository.Delete(request.Id, team);

            _teamRepository.SaveChanges();

            return await Task.FromResult("Cliente deletado com sucesso");
        }
    }
}
