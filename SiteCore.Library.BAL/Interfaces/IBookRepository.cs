using System;
using System.Collections.Generic;
using SiteCore.Library.BAL.Entities;

namespace SiteCore.Library.BAL.Interfaces
{
    public interface IBookRepository
    {
        int AddNew(Book book);
        void Update(Book book);
        void Delete(int bookId);
        IList<Book> GetAll();
    }
}
