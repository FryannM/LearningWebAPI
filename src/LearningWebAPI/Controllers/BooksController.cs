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

        public IEnumerable<Book> Get()
        {
            return this.repository.GetAllBooks();
        }

        //public IEnumerable<string> Get()
        //{
        //    return new List<string>() { "Brij", "John" };
        //}
    }
}
