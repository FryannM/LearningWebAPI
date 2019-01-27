using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LearningWebAPI.Data
{
    public class BookStoreRepository : IBookStoreRepository
    {
        private BookStoreContext context;

        public BookStoreRepository(BookStoreContext _bookStoreContext)
        {
            context = _bookStoreContext;
        }

        public Author FindAutor(int _id, bool includeBooks = false)
        {
            if (includeBooks)
            {
                return context.Authors.Include(a => a.Books).FirstOrDefault<Author>(a => a.Id == _id);
            }
            return context.Authors.FirstOrDefault<Author>(a => a.Id == _id);
        }

        public Book FindBook(int _id, bool includeAuthor = false)
        {

            if (includeAuthor)
            {
                var book1 = context.Books.Include(b => b.Author).FirstOrDefault<Book>(b => b.Id == _id);

                return book1;
            }

            var book = context.Books.FirstOrDefault<Book>(b => b.Id == _id);
            return book;
        }

        public IList<Author> GetAllAuthors()
        {
            return context.Authors.ToList();
        }

        public IList<Author> GetAllAuthorswithBooks()
        {
            return context.Authors.Include(a => a.Books).ToList();
        }

        public IList<Book> GetAllBooks()
        {
            return context.Books.ToList();
        }

        public IList<Book> GetAllBookswithAuthor()
        {
            return context.Books.Include(b => b.Author).ToList();
        }

        public Book AddBook(Book _newBook)
        {
            var author = context.Authors.First(a => a.NickName == _newBook.Author.NickName);

            if (author != null)
            {
                _newBook.Author.Id = author.Id;
            }
            else
            {
                context.Authors.Add(_newBook.Author);
            }
            var addedBook = context.Books.Add(_newBook);

            int id = context.SaveChanges();

            return addedBook.Entity;
        }

        public bool DeleteBook(int Id)
        {
            var booktodete = context.Books.First(b => b.Id == Id);

            if (booktodete != null)
            {
                context.Remove(booktodete);
                context.SaveChanges();
                return true;
            }

            return false;
        }
        public bool UpdateBook(Book _booktoUpdate)
        {
            var updatedBook = context.Update(_booktoUpdate);

            int updatedObjectCount = context.SaveChanges();

            return true;
        }
    }
}
