using RestApi.Data.Converter;
using RestApi.Models;
using RestApi.Repository;
using RestApi.ValueObjects;
using System.Collections.Generic;

namespace RestApi.Business
{
    public class BookBusiness
    {
        private readonly Repository<Book> _repository;
        private readonly BookConverter _converter;

        public BookBusiness(Repository<Book> repository)
        {
            _repository = repository;
            _converter = new BookConverter();
        }

        public BookVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public List<BookVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public BookVO Create(BookVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _repository.Create(bookEntity);

            return _converter.Parse(bookEntity);
        }
        
        public BookVO Update(BookVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _repository.Update(bookEntity);

            return _converter.Parse(bookEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
