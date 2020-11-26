using MediatR;

namespace MediatRAPI.Application.AppTeam.Command
{
    public class TeamDeleteCommand : IRequest<string>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
