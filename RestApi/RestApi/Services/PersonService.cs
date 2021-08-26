using RestApi.Data;
using RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Services
{
    public class PersonService : ServiceBase
    {
        public PersonService(Context context) : base(context) { }

        public Person FindById(long id)
        {
            return _context.People.SingleOrDefault(p => p.Id == id);
        }

        public List<Person> FindAll()
        {
            return _context.People.ToList();
        }

        public Person Create(Person person)
        {
            try
            {
                _context.People.Add(person);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
            return person;
        }
        
        public Person Update(Person person)
        {
            if(!PersonExists(person.Id)) return new Person();

            var result = _context.People.SingleOrDefault(p => p.Id == person.Id);
            if(result == null) return new Person();

            try
            {
                _context.Entry(result).CurrentValues.SetValues(person);
                _context.SaveChanges();
            }
            catch { throw; }

            return person;
        }

        public void Delete(long id)
        {
            if (!PersonExists(id)) return;

            var result = _context.People.SingleOrDefault(p => p.Id == id);
            if (result == null) return;

            try
            {
                _context.People.Remove(result);
                _context.SaveChanges();
            }
            catch { throw; }
        }

        private bool PersonExists(long id)
        {
            return _context.People.Any(p => p.Id == id);
        }
    }
}
