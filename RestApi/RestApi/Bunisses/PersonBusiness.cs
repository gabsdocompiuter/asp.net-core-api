using RestApi.Data;
using RestApi.Models;
using RestApi.Repository;
using System.Collections.Generic;
using System.Linq;

namespace RestApi.Business
{
    public class PersonBusiness
    {
        private readonly PersonRepository _repository;
        public PersonBusiness(PersonRepository repository)
        {
            _repository = repository;
        }

        public Person FindById(long id)
        {
            return _repository.FindById(id);
        }

        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }

        public Person Create(Person person)
        {
            return _repository.Create(person);
        }
        
        public Person Update(Person person)
        {
            return _repository.Update(person);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
