namespace MediatRAPI.Application.AppTeam.Command
{
    public class TeamUpdateCommand : TeamCreateCommand
    {
        public int Id { get; set; }
    }
}
