using System;
using System.Collections.Generic;
using System.Linq;

namespace LearningWebAPI.Data
{
    public class BookContextSeeder
    {
        BookStoreContext context;
        public BookContextSeeder(BookStoreContext _bookStoreContext)
        {
            context = _bookStoreContext;
        }
        public void Seed()
        {
            if (!context.Books.Any())
            {
                var designAuthor = new Author()
                {
                    FirstName = "Martin",
                    LastName = "Fowler",
                    NickName = "M Fowler"
                };
                var JSAuthor = new Author()
                {
                    FirstName = "Douglas",
                    LastName = "Crockford",
                    NickName = "Douglas Crockford"
                };
                var aspnetAuthor = new Author()
                {
                    FirstName = "Adam",
                    LastName = "Freeman",
                    NickName = "Adam Freeman"
                };
                var hfAuthor = new Author()
                {
                    FirstName = "Eric",
                    LastName = "Freeman",
                    NickName = "Eric Freeman"
                };
                var jsAuthor2 = new Author()
                {
                    FirstName = "David",
                    LastName = "Flanagan",
                    NickName = "David Flanagan "
                };
                var ccAuthor = new Author()
                {
                    FirstName = "Robert",
                    LastName = "Martin",
                    NickName = "Robert C. Martin"
                };
                var csharpAuthor = new Author()
                {
                    FirstName = "Andrew",
                    LastName = "Troelsen",
                    NickName = "Andrew W. Troelsen"
                };
                var jsAuthor3 = new Author()
                {
                    FirstName = "Jon",
                    LastName = "Duckett",
                    NickName = "Jon Duckett"
                };
                List<Book> listofBooks = new List<Book>()
                {
                    new Book()
                    {
                        Title = "Patterns of Enterprise Applications Architecture",
                        Genre = "Technology",
                        ISBN = "978-8131794029",
                        NoofPages = 560,
                        PublishedOn = new DateTime(2013,1,1),
                        Author = designAuthor
                    },
                    new Book()
                    {
                        Title = "Domain-Specific Languages",
                        Genre = "Technology",
                        ISBN = "978-0321712943",
                        NoofPages = 581,
                        PublishedOn = new DateTime(2011,1,1),
                        Author = designAuthor
                    },//------------
                    new Book()
                    {
                        Title = "JavaScript: The Good Parts",
                        Genre = "Technology",
                        ISBN = "978-0596517748",
                        NoofPages = 581,
                        PublishedOn = new DateTime(2008,5,1),
                        Author = JSAuthor
                    },
                    new Book()
                    {
                        Title = "Pro ASP.NET MVC 5",
                        Genre = "Technology",
                        ISBN = "978-1430265290",
                        NoofPages = 785,
                        PublishedOn = new DateTime(2012,1,1),
                        Author = aspnetAuthor
                    },
                    new Book()
                    {
                        Title = "Clean Code: A Handbook of Agile Software Craftsmanship",
                        Genre = "Technology",
                        ISBN = "978-0132350884",
                        NoofPages = 413,
                        PublishedOn = new DateTime(2009,1,1),
                        Author = ccAuthor
                    },
                    new Book()
                    {
                        Title = "UML Distilled: A Brief Guide to the Standard Object Modeling Language",
                        Genre = "Technology",
                        ISBN = "078-5342193688",
                        NoofPages = 385,
                        PublishedOn = new DateTime(2004,1,1),
                        Author = designAuthor
                    },
                    new Book()
                    {
                        Title = "JavaScript: The Definitive Guide: Activate Your Web Pages ",
                        Genre = "Technology",
                        ISBN = "000-0596007124",
                        NoofPages = 1019,
                        PublishedOn = new DateTime(2011,4,1),
                        Author = jsAuthor2
                    },
                    new Book()
                    {
                        Title = "Head First Design Patterns",
                        Genre = "Technology",
                        ISBN = "000-0596007124",
                        NoofPages = 617,
                        PublishedOn = new DateTime(2014,6,30),
                        Author = hfAuthor
                    },
                    new Book()
                    {
                        Title = "Pro C# 5.0 And The .Net 4.5 Framework",
                        Genre = "Technology",
                        ISBN = "000-9781430242338",
                        NoofPages = 1560,
                        PublishedOn = new DateTime(2012,8,27),
                        Author = csharpAuthor
                    },
                    new Book()
                    {
                        Title = "JavaScript and JQuery: Interactive Front-End Web Development",
                        Genre = "Technology",
                        ISBN = "978-1118531648",
                        NoofPages = 640,
                        PublishedOn = new DateTime(2014,7,18),
                        Author = jsAuthor3
                    },
                    new Book()
                    {
                        Title = "Applied ASP.NET 4",
                        Genre = "Technology",
                        ISBN = "B005PZ08SE",
                        NoofPages = 952,
                        PublishedOn = new DateTime(2011,9,11),
                        Author = aspnetAuthor
                    }

                };

                context.Books.AddRange(listofBooks);
                context.Authors.Add(listofBooks[0].Author);
                context.Authors.Add(listofBooks[1].Author);
                context.Authors.Add(listofBooks[2].Author);
                context.Authors.Add(listofBooks[3].Author);
                context.Authors.Add(listofBooks[4].Author);
                context.Authors.Add(listofBooks[5].Author);
                context.Authors.Add(listofBooks[6].Author);
                context.Authors.Add(listofBooks[7].Author);
                context.Authors.Add(listofBooks[8].Author);
                context.Authors.Add(listofBooks[9].Author);

                context.Authors.Add(listofBooks[10].Author);

                context.SaveChanges();
            }


            //  SeedUsers().Wait();
        }
    }
}
