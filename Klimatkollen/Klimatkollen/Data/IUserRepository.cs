using Klimatkollen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klimatkollen.Data
{
    public interface IUserRepository
    {
        Person GetPerson(string id);
        Person EditPerson(Person model);
        void DeletePerson(Person model);
        List<Person> GetPeople();
    }
}
