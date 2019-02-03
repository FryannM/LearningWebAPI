using LearningWebAPI.Data;
using LearningWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace LearningWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class AuthorsController : Controller
    {
        private IBookStoreRepository bookrespositoy;
    
        public AuthorsController(IBookStoreRepository _bookStoreRepository)
        {
            this.bookrespositoy = _bookStoreRepository;
        }
        [HttpGet("books/{bookid:int}/Author")]
        [HttpGet("authors/{id:int}")]

        public IActionResult Get(int bookid, int? id)
        {
            if (id == null)
            {
                Book book = this.bookrespositoy.FindBook(bookid, true);
                if (book != null)
                {
                    return Ok(book.Author);
                }

            }
            else
            {
                return Ok(this.bookrespositoy.FindAutor(id.Value, true));
            }

            return NotFound();
        }
        //[HttpGet("authors")]
        public IEnumerable<Book> Get(string sort ="Id",string order ="Asc",int pageNo =1,int pageSize =5)
        {
            IList<Book> allBooks = this.bookrespositoy.GetAllBooks();
            var sortedbooks =  allBooks.ApplySorting(sort, order);

            return sortedbooks.Skip((pageNo - 1) * pageSize).Take(pageSize);

     

        } 
        
    }
   
}
