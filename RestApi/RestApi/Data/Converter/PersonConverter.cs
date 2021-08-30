using RestApi.Models;
using RestApi.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace RestApi.Data.Converter
{
    public class PersonConverter : IParser<Person, PersonVO>, IParser<PersonVO, Person>
    {
        public Person Parse(PersonVO origin)
        {
            if (origin == null) return null;

            return new Person
            {
                Id = origin.Id,
                Name = origin.Name,
                Email = origin.Email,
                Password = origin.Password,
            };
        }

        public PersonVO Parse(Person origin)
        {
            if (origin == null) return null;

            return new PersonVO
            {
                Id = origin.Id,
                Name = origin.Name,
                Email = origin.Email,
                Password = origin.Password,
            };
        }
        public List<Person> Parse(List<PersonVO> origin)
        {
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<PersonVO> Parse(List<Person> origin)
        {
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
