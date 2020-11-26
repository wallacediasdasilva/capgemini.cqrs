namespace MediatRAPI.Application.AppTeam.Query.Response
{
    public class TeamGetResponse
    {
        public TeamGetResponse(string name, string modality, int qtdPlayers)
        {
            Name = name;
            Modality = modality;
            QtdPlayers = qtdPlayers;
        }

        public string Name { get; private set; }
        public string Modality { get; private set; }
        public int QtdPlayers { get; private set; }
    }
}
