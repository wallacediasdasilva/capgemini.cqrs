namespace MediatR.Test.User
{
    internal class UserDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public object PublicoAlvo { get; set; }
    }
}