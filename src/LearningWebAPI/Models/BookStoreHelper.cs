using LearningWebAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LearningWebAPI.Models
{
    public static class BookStoreHelper
    {
        public static IList<Book> ApplySorting(this IList<Book> allBooks, string sortby, string order)
        {
            IList<Book> sortedBooks;

            if (allBooks == null)
            {
                throw new ArgumentNullException("books");
            }

            if (order.ToLowerInvariant() == "desc")
            {
                sortedBooks = allBooks.OrderByDescending(x => x.GetType().GetProperty(sortby, BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.IgnoreCase).GetValue(x, null)).ToList();
            }
            else if (order.ToLowerInvariant() == "asc")
            {
                sortedBooks = allBooks.OrderBy(x => x.GetType().GetProperty(sortby, BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.IgnoreCase).GetValue(x, null)).ToList();
            }
            else
            {
                sortedBooks = allBooks;
            }

            return sortedBooks.ToList();
        }
    }
}
