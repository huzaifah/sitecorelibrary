using System;
using System.Collections.Generic;
using System.Linq;
using SiteCore.Library.BAL.Entities;
using SiteCore.Library.BAL.Interfaces;

namespace SiteCore.Library.BAL.Services
{
    public class BookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public List<Book> GetAll()
        {
            return _bookRepository.GetAll().ToList();
        }

        public int AddNewBook(Book book)
        {
            int bookId = _bookRepository.AddNew(book);
            return bookId;
        }
    }
}
