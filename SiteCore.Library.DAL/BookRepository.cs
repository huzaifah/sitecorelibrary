using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SiteCore.Library.BAL.Entities;
using SiteCore.Library.BAL.Interfaces;

namespace SiteCore.Library.DAL
{
    public class BookRepository : IBookRepository
    {
        private readonly IConfiguration _configuration;

        public BookRepository(IConfiguration configuration)
        {
            _configuration = configuration;
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

            string connectionString = _configuration["ConnectionStrings:DefaultConnection"];

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "Select * From Books";
                

                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        bookList.Add(new Book
                        {
                            Id = Convert.ToInt32(dataReader["Id"]),
                            Title = dataReader["Title"].ToString(),
                            Author = dataReader["Author"].ToString()
                        });
                    }
                }
            }

            return bookList;
        }

        public void Update(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
