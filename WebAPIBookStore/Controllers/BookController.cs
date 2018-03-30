using Domain;
using Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebAPIBookStore.Controllers
{
    public class BookController : ApiController
    {
        BookRepository bookRepo;

        public BookController()
        {
            string connStr = ConfigurationManager.ConnectionStrings["connStr"].ToString();
            bookRepo = new BookRepository(connStr);
        }

        [HttpGet]
        public IList<Book> Get()
        {
            return bookRepo.GetBooks();
        }

        [HttpGet]
        public Book Get(int id)
        {
            return bookRepo.GetById(id);
        }

        [HttpPost]
        [ResponseType(typeof(Book))]
        public IHttpActionResult PostBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bookRepo.Insert(book);

            return Ok(book);
        }

        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBook(int id, Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != book.Id)
            {
                return BadRequest();
            }

            bookRepo.Update(book);

            return Ok(book);
        }
        
        [HttpDelete]
        [ResponseType(typeof(Book))]
        public IHttpActionResult Delete(int id)
        {
            Book book = bookRepo.GetById(id);
            if (book == null)
            {
                return NotFound();
            }

            bookRepo.Delete(book);

            return Ok(book);
        }
    }
}
