using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLib.Model;

namespace RestItemServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private static List<Book> books = new List<Book>(){
            new Book("hej", "med", 13, "2854069781023"),
            new Book("dig", "yoman", 13, "2854069781s23")
    };
        // GET: api/Book
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return books;
        }

        // GET: api/Book/5
        [HttpGet("{id}", Name = "Get")]
        public Book Get(string isbn13)
        {
            return books.Find(i => i.Isbn13 == isbn13);
        }

        // POST: api/Book
        [HttpPost]
        public void Post([FromBody] Book value)
        {
            books.Add(value);
        }

        // PUT: api/Book/5
        [HttpPut("{id}")]
        public void Put(string isbn13, [FromBody] Book value)
        {
            Book book = Get(isbn13);
            if (book != null)
            {
                book.Isbn13 = value.Isbn13;
                book.Titel = value.Titel;
                book.Forfatter = value.Forfatter;
                book.Sidetal = value.Sidetal;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(string isbn13)
        {
            Book book = Get(isbn13);
            books.Remove(book);
        }
    }
}
