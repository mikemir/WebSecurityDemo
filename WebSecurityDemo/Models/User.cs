using Bogus;
using System.Collections;
using System.Collections.Generic;

namespace WebSecurityDemo.Models
{
    public enum GenderUser
    {
        Male,
        Female
    }

    public class User
    {
        public static List<User> CreateList(int cantidad)
        {
            var userIds = 1;
            var testUsers = new Faker<User>()
                    .CustomInstantiator(f => new User(userIds++))
                    .RuleFor(u => u.Gender, f => f.PickRandom<GenderUser>())
                    .RuleFor(u => u.FirstName, (f, u) => f.Name.FirstName())
                    .RuleFor(u => u.LastName, (f, u) => f.Name.LastName())
                    .RuleFor(u => u.UserName, (f, u) => f.Internet.UserName(u.FirstName, u.LastName))
                    .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
                    .RuleFor(u => u.SomethingUnique, f => $"Value {f.UniqueIndex}");

            return testUsers.Generate(cantidad);
        }

        public User(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
        public GenderUser Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName { get => $"{FirstName} {LastName}"; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string SomethingUnique { get; set; }
    }
}
