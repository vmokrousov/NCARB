using System;
using System.Collections.Generic;
using TestApi1.Entity.Persons;

namespace TestApi1.Repository.Persons
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetPersons();
        void AddPerson(Person person);

        void EditPerson(Person person);
    }
}
