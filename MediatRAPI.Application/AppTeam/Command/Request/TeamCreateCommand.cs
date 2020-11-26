using MediatR;

namespace MediatRAPI.Application.AppTeam.Command
{
    public class TeamCreateCommand : IRequest<string>
    {
        public string Name { get; set; }
        public string Modality { get; set; }
        public int QtdPlayers { get; set; }
    }
}
