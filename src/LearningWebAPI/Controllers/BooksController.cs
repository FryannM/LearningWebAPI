using LearningWebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LearningWebAPI.Controllers
{
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

        [HttpGet("{id:int}/{includeAuthor:bool?}")]
        public Book Get(int id, bool includeAuthor = false)
        {
            return this.repository.FindBook(id, includeAuthor);
        }
        [HttpGet("{id:int}/author")]
        public Author Get(int id) {
            return this.repository.FindBook(id,true).Author;
        }
    }
}
