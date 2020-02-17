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
            string connectionString = _configuration["ConnectionStrings:DefaultConnection"];
            int newId = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql =
                    $"Insert Into Books (Title, Author) OUTPUT INSERTED.Id Values ('{book.Title}', '{book.Author}')";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;

                    SqlParameter param = new SqlParameter("@Id", SqlDbType.Int, 4);
                    param.Direction = ParameterDirection.Output;
                    command.Parameters.Add(param);
                    command.ExecuteNonQuery();

                    //newId = Convert.ToInt32(param.Value);
                }
            }

            return newId;
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
