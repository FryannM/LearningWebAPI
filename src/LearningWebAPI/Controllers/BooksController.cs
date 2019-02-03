using LearningWebAPI.Data;
using LearningWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LearningWebAPI.Controllers
{
    [Route("api/books")]
    public class BooksController : Controller
    {
        private IBookStoreRepository repository;
        private IUrlHelper urlHelper;
        const int maxPageSize = 5;

        public BooksController(IBookStoreRepository _repository, IUrlHelper _urlHelperFactory)
        {
            this.repository = _repository;
            this.urlHelper = _urlHelperFactory;
        }
        //[HttpGet]
        //public IEnumerable<Book> Get()
        //{
        //    return this.repository.GetAllBooks();
        //}


        [HttpGet(Name = "GetBooks")]
        public IEnumerable<Book> Get(string sort = "Id", string order = "Asc", int pageNo = 1, int pageSize = maxPageSize)
        {
            IList<Book> allbooks = this.repository.GetAllBooks();

            // Reset page size to max page size if requested page size is greater than max page size
            if (pageSize > maxPageSize)
            {
                pageSize = maxPageSize;
            }

            // Implement sorting
            IList<Book> sortedBooks = allbooks.ApplySorting(sort, order);

            // creating metadata for paging
            int totalBooks = sortedBooks.Count;
            int totalPages = (int)Math.Ceiling((double)totalBooks / pageSize);

            var prevPageLink = pageNo == 1 ? string.Empty : this.urlHelper.Link("GetBooks",
                new
                {
                    sort = sort,
                    order = order,
                    pageNo = pageNo - 1,
                    pageSize = pageSize
                });

            var nextPageLink = pageNo == totalPages ? string.Empty : this.urlHelper.Link("GetBooks",
                new
                {
                    sort = sort,
                    order = order,
                    pageNo = pageNo + 1,
                    pageSize = pageSize
                });

            // page header info
            var pageInfoHeader = new
            {
                pageNo = pageNo,
                pageSize = pageSize,
                totalbooks = totalBooks,
                totalPages = totalPages,
                prevPageLink = prevPageLink,
                nextPageLink = nextPageLink
            };

            // adding page details in header
            Response.Headers.Add("X-PageInfo", JsonConvert.SerializeObject(pageInfoHeader));

            // 
            return sortedBooks.Skip((pageNo - 1) * pageSize).Take(pageSize);
        }


        [HttpGet]
        [Route("getname")]

        public IEnumerable<string> Getname()
        {
            return new List<string>() { "Fryann", "Martinez" };
        }

        [HttpGet("{id:int}/{includeAuthor:bool?}",Name ="GetBooksById")]
        public Book Get(int id, bool includeAuthor = false)
        {
            return this.repository.FindBook(id, includeAuthor);
        }
        [HttpGet("{id:int}/author")]
        public Author Get(int id)
        {
            return this.repository.FindBook(id,true).Author;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Book newBook)
        {
            if (newBook == null)
            {
                return NotFound(" Error has Occurred");
            }
            var book = this.repository.AddBook(newBook);

            if (book == null) {
                return NotFound("Error Adding  Your Book!");
            }

            return CreatedAtRoute("GetBooks", new { controller = "Books", id = book.Id }, book);
        }
        [HttpPatch("{id:int}")]
        [HttpPut("{id:int}")]
         public IActionResult put (int id, [FromBody] Book book)
        {
            if (book == null)
            {
                return NotFound("Error Has Occurer");
              
            }
           bool bookupdated =   this.repository.UpdateBook(book);
             if (!bookupdated)
            {
                return NotFound("Error Updating the Book");
            }

            return Ok();
        }

        [HttpDelete ("{id:int}")]
        public IActionResult  delete(int  id)
        {
             if (id == 0)
            {
                return NotFound("Error has Occurrer deleting this book");
            }
            var book = this.repository.FindBook(id,false);

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
