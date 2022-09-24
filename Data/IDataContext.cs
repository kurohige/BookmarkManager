using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookmarkManager.Models;

namespace BookmarkManager.Data
{
    public interface IDataContext
    {
        DbSet<Bookmark> Bookmarks{get; init;}
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
