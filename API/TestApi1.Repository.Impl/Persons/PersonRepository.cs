using System;
using System.Linq;
using System.Collections.Generic;
using TestApi1.Entity.Persons;
using TestApi1.Repository.Persons;

namespace TestApi1.Repository.Impl.Persons
{
    public class PersonRepository : IPersonRepository
    {
        public static List<Person> persons = new List<Person>
        {
            new Person {  PersonId = 1, FirstName = "John", LastName= "Doe", JobTitle = "Dev Lead"},
            new Person { PersonId = 2, FirstName = "Larry", LastName= "King", JobTitle = "Radio Host"}
        };

        public IEnumerable<Person> GetPersons()
        {
            return persons;
        }

        public void AddPerson(Person person)
        {
            persons.Add(person);
        }

      

        void IPersonRepository.EditPerson(Person person)
        {
            foreach (var x in persons)
            {
                if (x.PersonId == person.PersonId)
                {
                    x.FirstName = person.FirstName;
                    x.LastName = person.LastName;
                    x.JobTitle = person.JobTitle;
                }
            }
        }
    }
}
