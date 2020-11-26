using MediatR;
using MediatRAPI.Application.AppTeam.Query.Response;

namespace MediatRAPI.Application.AppTeam.Query.Request
{
    public class TeamGetCommand : IRequest<TeamGetResponse>
    {
        public int Id { get; set; }
    }
}
