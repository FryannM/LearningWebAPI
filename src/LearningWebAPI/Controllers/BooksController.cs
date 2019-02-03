using LearningWebAPI.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace LearningWebAPI.Controllers
{
    [EnableCors("AllowSpecific")]
    [Route("api/books")]
    public class BooksController : Controller
    {
        private IBookStoreRepository repository;

        public BooksController(IBookStoreRepository _repository)
        {
            this.repository = _repository;
        }
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return this.repository.GetAllBooks();
        }
        [HttpGet]
        [Route("getname")]

        public IEnumerable<string> Getname()
        {
            return new List<string>() { "Fryann", "Martinez" };
        }
        [RequireHttps]
        [HttpGet("{id:int}/{includeAuthor:bool?}", Name = "GetBooksById")]
        public Book Get(int id, bool includeAuthor = false)
        {
            return this.repository.FindBook(id, includeAuthor);
        }
        [HttpGet("{id:int}/author")]
        public Author Get(int id)
        {
            return this.repository.FindBook(id, true).Author;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Book newBook)
        {
            if (newBook == null)
            {
                return NotFound(" Error has Occurred");
            }
            var book = this.repository.AddBook(newBook);

            if (book == null)
            {
                return NotFound("Error Adding  Your Book!");
            }

            return CreatedAtRoute("GetBooks", new { controller = "Books", id = book.Id }, book);
        }
        [HttpPatch("{id:int}")]
        [HttpPut("{id:int}")]
        public IActionResult put(int id, [FromBody] Book book)
        {
            if (book == null)
            {
                return NotFound("Error Has Occurer");

            }
            bool bookupdated = this.repository.UpdateBook(book);
            if (!bookupdated)
            {
                return NotFound("Error Updating the Book");
            }

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public IActionResult delete(int id)
        {
            if (id == 0)
            {
                return NotFound("Error has Occurrer deleting this book");
            }
            var book = this.repository.FindBook(id, false);

            if (book == null)
            {
                return NotFound("Id was no Found");
            }
            bool isDeleted = this.repository.DeleteBook(id);
            if (isDeleted)
            {
                return StatusCode(204);
            }
            else
            {
                return BadRequest("Error Deleting this book");
            }


        }




    }
}
