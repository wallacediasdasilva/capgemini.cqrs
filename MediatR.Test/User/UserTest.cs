using Bogus;
using Bogus.Extensions.Brazil;
using ExpectedObjects;
using MediatR.Test.Builders;
using MediatR.Test.Util;
using MediatRAPI.CrossCutting.Support.Util;
using MediatRAPI.Domain.Team;
using Xunit;

namespace MediatR.Test.User
{
    public class UserTest
    {
        private readonly Faker _faker;

        public UserTest()
        {
            _faker = new Faker();
        }

        [Fact]
        public void ShouldCreateUser()
        {
            var userExpected = new
            {
                Name = _faker.Person.FullName,
                _faker.Person.Email,
                CPF = _faker.Person.Cpf(),
                Phone = _faker.Phone.ToString(),
            };

            var user = new TeamEntity(userExpected.Name, userExpected.CPF, userExpected.Email, userExpected.Phone);

            userExpected.ToExpectedObject().ShouldMatch(user);
        }

        [Fact]
        public void ShouldChangeName()
        {
            var newUserNameExpected = _faker.Person.FullName;
            var user = UserBuilder.Novo().Build();

            user.ChangeName(newUserNameExpected);

            Assert.Equal(newUserNameExpected, user.Name);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCreateWithInvalidName(string invalidName)
        {
            Assert.Throws<ExceptionDomain>(() =>
                    UserBuilder.Novo().WithName(invalidName).Build())
                .WithMessage(Resource.InvalidName);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCreateWithInvalidEmail(string invalidEmail)
        {
            Assert.Throws<ExceptionDomain>(() =>
                    UserBuilder.Novo().WithEmail(invalidEmail).Build())
                .WithMessage(Resource.InvalidEmail);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("0000000000")]
        public void ShouldNotCreateWithInvalidCpf(string invalidCpf)
        {
            Assert.Throws<ExceptionDomain>(() =>
                    UserBuilder.Novo().WithCpf(invalidCpf).Build())
                .WithMessage(Resource.InvalidCpf);
        }
    }
}