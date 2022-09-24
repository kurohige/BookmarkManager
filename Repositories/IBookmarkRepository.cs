using System.Threading.Tasks;
using BookmarkManager.Models;
using System.Collections.Generic;

namespace BookmarkManager.Repositories
{
    public interface IBookmarkRepository
    {
         Task<Bookmark> Get(int id);
         Task<IEnumerable<Bookmark>> GetAll();
         Task Add(Bookmark bookmark);
         Task Delete(int id);
         Task Update(Bookmark bookmark);
    }
}