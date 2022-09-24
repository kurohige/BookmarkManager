using Microsoft.EntityFrameworkCore;
using BookmarkManager.Models;
 
namespace BookmarkManager.Data
{
    public class DataContext: DbContext, IDataContext
    {
        public DataContext()
        {
        }
        // protected readonly IConfiguration Configuration;
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            if(!options.IsConfigured)
            {
                options.UseNpgsql("Server=localhost;Database=bookmarkdb;Port=5432;User Id=postgres;Password=2050");
            }
         }

        public DbSet<Bookmark> Bookmarks { get; init; }
    }
}