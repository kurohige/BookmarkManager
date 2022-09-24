using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookmarkManager.Data;
using BookmarkManager.Models;
 
namespace BookmarkManager.Repositories
{
  public class BookmarkRepository : IBookmarkRepository
  {
    private readonly IDataContext _context;
    public BookmarkRepository(IDataContext context)
    {
      _context = context;
 
    }
    public async Task Add(Bookmark bookmark)
    {        
      _context.Bookmarks.Add(bookmark);
      await _context.SaveChangesAsync();
    }
 
    public async Task Delete(int id)
    {
        var itemToRemove = await _context.Bookmarks.FindAsync(id);
        if (itemToRemove == null)
            throw new NullReferenceException();
         
        _context.Bookmarks.Remove(itemToRemove);
        await _context.SaveChangesAsync();
    }
 
    public async Task<Bookmark> Get(int id)
    {
        return await _context.Bookmarks.FindAsync(id);
    }
 
    public async Task<IEnumerable<Bookmark>> GetAll()
    {
        return await _context.Bookmarks.ToListAsync();
    }
 
    public async Task Update(Bookmark bookmark)
    {
        var itemToUpdate = await _context.Bookmarks.FindAsync(bookmark.BookmarkName);
        if (itemToUpdate == null)
            throw new NullReferenceException();
        itemToUpdate.BookmarkName = bookmark.BookmarkName;
        itemToUpdate.URL = bookmark.URL;
        await _context.SaveChangesAsync();
 
    }
  }
}