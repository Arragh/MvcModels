using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MvcModels.Models.Person;

namespace MvcModels.Models
{
    public interface IRepository
    {
        IEnumerable<Person> People { get; }
        Person this[int id] { get;set; }
    }

    public class MemoryRepository : IRepository
    {
        private Dictionary<int, Person> people = new Dictionary<int, Person>
        {
            [1] = new Person
            {
                PersonId = 1,
                FirstName = "Bob",
                LastName = "Smith",
                PersonRole = Role.Admin
            },
            [2] = new Person
            {
                PersonId = 2,
                FirstName = "Anne",
                LastName = "Douglas",
                PersonRole = Role.User
            },
            [3] = new Person
            {
                PersonId = 3,
                FirstName = "Joe",
                LastName = "Able",
                PersonRole = Role.User
            },
            [4] = new Person
            {
                PersonId = 4,
                FirstName = "Mary",
                LastName = "Peters",
                PersonRole = Role.Guest
            }
        };

        public Person this[int id]
        {
            get => people.ContainsKey(id) ? people[id] : null;
            set => people[id] = value;
        }

        public IEnumerable<Person> People => people.Values;
    }
}
