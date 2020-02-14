using Klimatkollen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klimatkollen.Data
{
    public class MockUserRepository : IUserRepository
    {
        public void AddPerson(Person person)
        {
            throw new NotImplementedException();
        }

        public void AddUserTrackedLocation(UsersTrackedLocations model)
        {
            throw new NotImplementedException();
        }

        public void DeletePerson(Person model)
        {
            throw new NotImplementedException();
        }

        public void DeleteUsersTrackedLocation(int id)
        {
            throw new NotImplementedException();
        }

        public Person EditPerson(Person model)
        {
            var person = GetPerson(model.IdentityId);
            person.FirstName = model.FirstName;
            person.Lastname = model.Lastname;
            person.Email = model.Email;
            person.UserName = model.UserName;
            return person;
        }

        public List<Person> GetPeople()
        {
            throw new NotImplementedException();
        }

        public Person GetPerson(string id)
        {

            Person person = new Person
            {
                Email = "mrPincett@live.se",
                IdentityId = id,
                Id = 130,
                FirstName = "Mattias",
                Lastname = "Kenttä"
            }; return person;
        }

        public List<UsersTrackedLocations> GetUsersTrackedLocations(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
