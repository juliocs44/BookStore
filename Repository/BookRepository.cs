
using Dapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Repository
{
    public class BookRepository : IBookRepository
    {
        private string ConnStr { get; set; }

        private IList<Book> booksResult = new List<Book>();

        public BookRepository(string connStr)
        {
            ConnStr = connStr;
        }

        public IList<Book> GetBooks()
        {
            using (var sqlConnection = new SqlConnection(ConnStr))
            {
                var books = sqlConnection.Query<Book>(@"SELECT *
                                                        FROM Book
                                                        ORDER BY Name");

                foreach (Book book in books)
                    booksResult.Add(book);
            }

            return booksResult;
        }

        public Book GetById(int bookId)
        {
            using (var sqlConnection = new SqlConnection(ConnStr))
            {
                return sqlConnection.Query<Book>(@"SELECT * 
                                                   FROM Book 
                                                   WHERE Id = @Id", new { Id = bookId }).SingleOrDefault();
            }
        }

        public void Insert(Book book)
        {
            using (var sqlConnection = new SqlConnection(ConnStr))
            {
                sqlConnection.Execute(@"INSERT INTO Book (Name, Author, NumberPages, Year, Language, Brand)
                                        VALUES (@Name, @Author, @NumberPages, @Year, @Language, @Brand)", book);
            }
        }

        public void Update(Book book)
        {
            using (var sqlConnection = new SqlConnection(ConnStr))
            {
                sqlConnection.Execute(@"UPDATE Book 
                                        SET Name = @Name, Author = @Author, NumberPages = @NumberPages, Year = @Year, Language = @Language, Brand = @Brand 
                                        WHERE Id = @Id", book);
            }
        }

        public void Delete(Book book)
        {
            using (var sqlConnection = new SqlConnection(ConnStr))
            {
                sqlConnection.Execute(@"DELETE FROM Book
                                        WHERE Id = @Id", book);
            }
        }
    }
}
