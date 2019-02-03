using LearningWebAPI.Data;
using LearningWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace LearningWebAPI.Controllers
{
    [Route("api")]
    public class AuthorsController : Controller
    {
        private IBookStoreRepository authorRespository;
    
        public AuthorsController(IBookStoreRepository _authorRespositoryRepository)
        {
            this.authorRespository = _authorRespositoryRepository;
        }

        [HttpGet("authors")]
        public IEnumerable<Author> Get()
        {
            return this.authorRespository.GetAllAuthors();
        }


        [HttpGet("books/{bookid:int}/Author")]
        [HttpGet("authors/{id:int}")]

        public IActionResult Get(int bookid, int? id)
        {
            if (id == null)
            {
                Book book = this.authorRespository.FindBook(bookid, true);
                if (book != null)
                {
                    return Ok(book.Author);
                }
            }
            else
            {
                return Ok(this.authorRespository.FindAutor(id.Value, true));
            }

            return NotFound();
        }
  
    }

}
