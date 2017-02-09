using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using TestApi1.Entity.Persons;
using TestApi1.Repository.Persons;

namespace TestApi1.Controllers
{
    [EnableCors(origins: "http://localhost:8000", headers: "*", methods: "*")]
    [RoutePrefix("api/person")]
    public class PersonController: ApiController
    {
        private IPersonRepository _repository;

        public PersonController(IPersonRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Person> Get()
        {
            return _repository.GetPersons();
        }

        [HttpPost]
        [Route("")]
        public void Post([FromBody] Person person)
        {
            _repository.EditPerson(person);
        }
        
    }
}