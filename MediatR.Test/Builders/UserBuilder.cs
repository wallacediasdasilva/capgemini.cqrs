using Bogus;
using Bogus.Extensions.Brazil;
using MediatRAPI.Domain.Team;
using System;

namespace MediatR.Test.Builders
{
    public class UserBuilder
    {
        protected int Id;
        protected string Name;
        protected string Email;
        protected string Phone;
        protected string Cpf;

        public static UserBuilder Novo()
        {
            var faker = new Faker();

            return new UserBuilder
            {
                Name = faker.Person.FullName,
                Email = faker.Person.Email,
                Phone = faker.Phone.ToString(),
                Cpf = faker.Person.Cpf(),
            };
        }

        public UserBuilder WithName(string name)
        {
            Name = name;
            return this;
        }

        public UserBuilder WithEmail(string email)
        {
            Email = email;
            return this;
        }

        public UserBuilder WithCpf(string cpf)
        {
            Cpf = cpf;
            return this;
        }

        public UserBuilder WithId(int id)
        {
            Id = id;
            return this;
        }

        public TeamEntity Build()
        {
            var user = new TeamEntity(Name, Cpf, Email, Phone);

            if (Id <= 0) return user;

            var propertyInfo = user.GetType().GetProperty("Id");
            propertyInfo.SetValue(user, Convert.ChangeType(Id, propertyInfo.PropertyType), null);

            return user;
        }

        
    }
}