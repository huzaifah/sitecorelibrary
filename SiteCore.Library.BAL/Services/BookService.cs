﻿using System;
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

        public void AddNewBook(Book book)
        {
            _bookRepository.AddNew(book);
        }

        public Book GetById(int id)
        {
            var book = _bookRepository.GetById(id);
            return book;
        }

        public void UpdateBook(int id, Book book)
        {
            _bookRepository.Update(id, book);
        }

        public void DeleteBook(int id)
        {
            _bookRepository.Delete(id);
        }

        public List<Author> GetAuthors()
        {
            return _bookRepository.GetAllAuthors().ToList();
        }
    }
}
