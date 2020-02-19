using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.Extensions.Configuration;
using SiteCore.Library.BAL.Entities;
using SiteCore.Library.BAL.Interfaces;
using SiteCore.Library.DAL.DataModels;

namespace SiteCore.Library.DAL
{
    public class BookRepository : IBookRepository
    {
        private readonly IConfiguration _configuration;
        readonly string connectionString;

        public BookRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration["ConnectionStrings:DefaultConnection"];
        }

        public void AddNew(Book book)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql =
                    $"Insert Into Books (Title) Values (@Title)";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    SqlParameter titleParameter = new SqlParameter("Title", book.Title);
                    //SqlParameter authorParameter = new SqlParameter("Author", book.Author);

                    command.Parameters.Add(titleParameter);
                    //command.Parameters.Add(authorParameter);

                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int bookId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql =
                    $"Delete From Books Where Id=@Id";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    SqlParameter idParameter = new SqlParameter("Id", bookId);

                    command.Parameters.Add(idParameter);

                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }
        }

        public IList<Book> GetAll()
        {
            var bookList = new List<Book>();
            var bookData = new List<BookAuthor>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "select b.Id, b.Title, a.Name from Books as b JOIN BookAuthor as ba on b.Id = ba.BookId JOIN Authors AS a ON ba.AuthorId = a.Id";
                
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        bookData.Add(new BookAuthor
                        {
                            BookId = Convert.ToInt32(dataReader["Id"]),
                            BookTitle = dataReader["Title"].ToString(),
                            AuthorName = dataReader["Name"].ToString()
                        });
                    }
                }
            }

            var booksByTitle = bookData.GroupBy(b => b.BookTitle).ToList();

            foreach (var book in booksByTitle)
            {
                var record = new Book();

                foreach (var item in book)
                {
                    record.Id = item.BookId;
                    record.Title = item.BookTitle;
                    record.Author.Add(item.AuthorName);
                }

                bookList.Add(record);
            }

            return bookList;
        }

        public Book GetById(int id)
        {
            Book bookToEdit = new Book();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "Select * From Books Where Id = @Id";

                SqlCommand command = new SqlCommand(sql, connection);
                SqlParameter idParameter = new SqlParameter("Id", id);
                command.Parameters.Add(idParameter);

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        bookToEdit.Id = Convert.ToInt32(dataReader["Id"]);
                        bookToEdit.Title = dataReader["Title"].ToString();
                        //bookToEdit.Author = dataReader["Author"].ToString();
                    }
                }
            }

            return bookToEdit;
        }

        public void Update(int id, Book book)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql =
                    $"Update Books set Title=@Title Where Id=@Id";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    SqlParameter titleParameter = new SqlParameter("Title", book.Title);
                    //SqlParameter authorParameter = new SqlParameter("Author", book.Author);
                    SqlParameter idParameter = new SqlParameter("Id", id);

                    command.Parameters.Add(titleParameter);
                    //command.Parameters.Add(authorParameter);
                    command.Parameters.Add(idParameter);

                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
