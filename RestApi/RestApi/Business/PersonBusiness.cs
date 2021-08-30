﻿using RestApi.Data.Converter;
using RestApi.Models;
using RestApi.Repository;
using RestApi.ValueObjects;
using System.Collections.Generic;

namespace RestApi.Business
{
    public class PersonBusiness
    {
        private readonly Repository<Person> _repository;
        private readonly PersonConverter _converter;
        public PersonBusiness(Repository<Person> repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }

        public PersonVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public List<PersonVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public PersonVO Create(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Create(personEntity);
            return _converter.Parse(personEntity);
        }
        
        public PersonVO Update(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Update(personEntity);

            return _converter.Parse(personEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
