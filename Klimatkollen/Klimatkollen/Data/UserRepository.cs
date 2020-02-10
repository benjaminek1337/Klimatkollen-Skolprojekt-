using Klimatkollen.Models;
using System.Collections.Generic;
using System.Linq;

namespace Klimatkollen.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;
        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Person GetPerson(string id)
        {
            var person = context.Persons.FirstOrDefault(p => p.IdentityId.Equals(id));
            return person;
        }

        public List<Person> GetPeople()
        {
            var people = new List<Person>();
            foreach (var person in context.Persons)
            {
                people.Add(person);
            }
            return people;
        }

        public Person EditPerson(Person model)
        {
            var person = GetPerson(model.IdentityId);
            person.FirstName = model.FirstName;
            person.Lastname = model.Lastname;
            person.Email = model.Email;
            person.UserName = model.Email;
            context.Update(person);
            context.SaveChanges();
            return person;
        }

        public void DeletePerson(Person model)
        {
            var person = GetPerson(model.IdentityId);
            context.Remove(person);
            context.SaveChanges();
        }

        public void AddUserTrackedLocation(UsersTrackedLocations model)
        {
            //Kod för att spara till databas
            context.UserTrackedLocations.Add(model);
            context.SaveChanges();
        }

        public List<UsersTrackedLocations> GetUsersTrackedLocations(Person person)
        {
            var locations = new List<UsersTrackedLocations>();
            foreach (var loc in context.UserTrackedLocations)
            {
                if(loc.Person.Id == person.Id)
                {
                    locations.Add(loc);
                }
            }

            return locations;
        }
    }
}
