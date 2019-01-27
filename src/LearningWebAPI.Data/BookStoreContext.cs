using Microsoft.EntityFrameworkCore;

namespace LearningWebAPI.Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext()
        {
            Database.EnsureCreated();
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var connstring = Startup.Configuration["Data:BookContextConnection"];
            optionsBuilder.UseSqlServer("Server=FRYANNM;Database=BookDbTestUpdated1;Trusted_Connection=true;MultipleActiveResultSets=true");
            //Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;

            base.OnConfiguring(optionsBuilder);
        }
    }
}
