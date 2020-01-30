﻿using Klimatkollen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klimatkollen.Data
{
    public class MockUserRepository : IUserRepository
    {
        public Person EditPerson(Person model)
        {
            var person = GetPerson(model.IdentityId);
            person.FirstName = model.FirstName;
            person.Lastname = model.Lastname;
            person.Email = model.Email;
            person.UserName = model.UserName;
            return person;
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
    }
}
