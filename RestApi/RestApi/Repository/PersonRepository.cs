using RestApi.Data;
using RestApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestApi.Repository
{
    public class PersonRepository
    {
        private readonly Context _context;

        public PersonRepository(Context context)
        {
            _context = context;
        }

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
            if(!Exists(person.Id)) return null;

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
            if (!Exists(id)) return;

            var result = _context.People.SingleOrDefault(p => p.Id == id);
            if (result == null) return;

            try
            {
                _context.People.Remove(result);
                _context.SaveChanges();
            }
            catch { throw; }
        }

        public bool Exists(long id)
        {
            return _context.People.Any(p => p.Id == id);
        }
    }
}
