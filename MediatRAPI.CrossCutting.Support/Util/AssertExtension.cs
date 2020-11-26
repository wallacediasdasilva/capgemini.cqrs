using MediatRAPI.CrossCutting.Support.Util;
using Xunit;

namespace MediatR.Test.Util
{
    public static class AssertExtension
    {
        public static void WithMessage(this ExceptionDomain exception, string mensagem)
        {
            if(exception.ErrorMessage.Contains(mensagem))
                Assert.True(true);
            else
                Assert.False(true, $"Esperava a mensagem '{mensagem}'");
        }
    }
}
