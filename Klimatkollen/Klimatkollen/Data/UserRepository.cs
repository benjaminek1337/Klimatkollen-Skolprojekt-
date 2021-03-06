﻿using Klimatkollen.Models;
using Microsoft.EntityFrameworkCore;
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
            return context.Persons.FirstOrDefault(p => p.IdentityId.Equals(id));
        }

        public void AddPerson(Person person)
        {
            context.Add(person);
            context.SaveChanges();
        }

        public List<Person> GetPeople()
        {
            return context.Persons.ToList();
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
            context.UserTrackedLocations.Add(model);
            context.SaveChanges();
        }

        public List<UsersTrackedLocations> GetUsersTrackedLocations(Person person)
        {
            return context.UserTrackedLocations.Where(x => x.Person.Equals(person)).ToList();
        }

        public void DeleteUsersTrackedLocation(int id)
        {
            context.UserTrackedLocations.Remove(context.UserTrackedLocations.Where(l => l.Id.Equals(id)).FirstOrDefault());
            context.SaveChanges();

        }

        public Person GetPersonFromObservationId(int id)
        {
            var observation = context.Observations.Where(o => o.Id.Equals(id))
                .Include(o => o.Person)
                .FirstOrDefault();
            return context.Persons.Where(p => p.Id.Equals(observation.Person.Id)).FirstOrDefault();
        }
    }
}
