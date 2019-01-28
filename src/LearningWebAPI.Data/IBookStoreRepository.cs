using System.Collections.Generic;

namespace LearningWebAPI.Data
{
    public interface IBookStoreRepository
    {
        IList<Book> GetAllBooks();

        IList<Book> GetAllBookswithAuthor();

        IList<Author> GetAllAuthors();

        IList<Author> GetAllAuthorswithBooks();

       
        Book FindBook(int _id, bool includeAuthor);

        Author FindAutor(int _id, bool includeBooks);

        Book AddBook(Book _newBook);

        bool DeleteBook(int id);

        bool UpdateBook(Book _booktoUpdate);

    }
}
