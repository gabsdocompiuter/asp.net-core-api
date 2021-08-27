using RestApi.Data;
using RestApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestApi.Repository
{
    public class BookRepository
    {
        private readonly Context _context;

        public BookRepository(Context context)
        {
            _context = context;
        }

        public Book FindById(long id)
        {
            return _context.Books.SingleOrDefault(p => p.Id == id);
        }

        public List<Book> FindAll()
        {
            return _context.Books.ToList();
        }

        public Book Create(Book book)
        {
            try
            {
                _context.Books.Add(book);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
            return book;
        }

        public Book Update(Book book)
        {
            if (!Exists(book.Id)) return null;

            var result = _context.Books.SingleOrDefault(p => p.Id == book.Id);
            if (result == null) return new Book();

            try
            {
                _context.Entry(result).CurrentValues.SetValues(book);
                _context.SaveChanges();
            }
            catch { throw; }

            return book;
        }

        public void Delete(long id)
        {
            if (!Exists(id)) return;

            var result = _context.Books.SingleOrDefault(p => p.Id == id);
            if (result == null) return;

            try
            {
                _context.Books.Remove(result);
                _context.SaveChanges();
            }
            catch { throw; }
        }

        public bool Exists(long id)
        {
            return _context.Books.Any(p => p.Id == id);
        }
    }
}
