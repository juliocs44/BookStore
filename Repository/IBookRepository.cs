using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public interface IBookRepository
    {
        IList<Book> GetBooks();

        Book GetById(int bookId);

        void Insert(Book book);

        void Update(Book book);

        void Delete(Book book);
    }
}
