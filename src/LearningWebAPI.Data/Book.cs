using System;

namespace LearningWebAPI.Data
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }

        public DateTime PublishedOn { get; set; }

        public int NoofPages { get; set; }

        public string ISBN { get; set; }

        public Author Author { get; set; }
    }
}
