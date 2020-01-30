using Klimatkollen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public Person EditPerson(Person model)
        {
            var person = GetPerson(model.IdentityId);
                person.FirstName = model.FirstName;
                person.Lastname = model.Lastname;
                person.Email = model.Email;
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
    }
}
