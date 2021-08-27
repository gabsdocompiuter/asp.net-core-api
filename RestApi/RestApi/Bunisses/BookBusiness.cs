using RestApi.Models;
using RestApi.Repository;
using System.Collections.Generic;

namespace RestApi.Business
{
    public class BookBusiness
    {
        private readonly Repository<Book> _repository;
        public BookBusiness(Repository<Book> repository)
        {
            _repository = repository;
        }

        public Book FindById(long id)
        {
            return _repository.FindById(id);
        }

        public List<Book> FindAll()
        {
            return _repository.FindAll();
        }

        public Book Create(Book Book)
        {
            return _repository.Create(Book);
        }
        
        public Book Update(Book Book)
        {
            return _repository.Update(Book);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
