﻿using System;
using System.Collections.Generic;
using SiteCore.Library.BAL.Entities;

namespace SiteCore.Library.BAL.Interfaces
{
    public interface IBookRepository
    {
        void AddNew(Book book);
        void Update(int id, Book book);
        void Delete(int bookId);
        Book GetById(int id);
        IList<Book> GetAll();
        IList<Author> GetAllAuthors();
    }
}
