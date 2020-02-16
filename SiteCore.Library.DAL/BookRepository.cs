using System;
using System.Collections.Generic;
using SiteCore.Library.BAL.Entities;
using SiteCore.Library.BAL.Interfaces;

namespace SiteCore.Library.DAL
{
    public class BookRepository : IBookRepository
    {
        public BookRepository()
        {
        }

        public int AddNew(Book book)
        {
            throw new NotImplementedException();
        }

        public void Delete(int bookId)
        {
            throw new NotImplementedException();
        }

        public IList<Book> GetAll()
        {
            var bookList = new List<Book>();

            bookList.Add(new Book
            {
                Id = 1,
                Title = "Book One",
                Author = "Shahrizal"
            });

            bookList.Add(new Book
            {
                Id = 2,
                Title = "Book Two",
                Author = "Shahrizal"
            });

            return bookList;
        }

        public void Update(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
