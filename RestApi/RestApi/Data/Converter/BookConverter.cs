using RestApi.Models;
using RestApi.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace RestApi.Data.Converter
{
    public class BookConverter : IParser<Book, BookVO>, IParser<BookVO, Book>
    {
        public BookVO Parse(Book origin)
        {
            if (origin == null) return null;

            return new BookVO
            {
                Id = origin.Id,
                Title = origin.Title,
                Description = origin.Description,
                Author = origin.Author,
            };
        }

        public Book Parse(BookVO origin)
        {
            if (origin == null) return null;

            return new Book
            {
                Id = origin.Id,
                Title = origin.Title,
                Description = origin.Description,
                Author = origin.Author,
            };
        }

        public List<BookVO> Parse(List<Book> origin)
        {
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<Book> Parse(List<BookVO> origin)
        {
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
