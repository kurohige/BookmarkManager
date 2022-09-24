using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookmarkManager.Models;
using BookmarkManager.Repositories;
using BookmarkManager.Dtos;

namespace BookmarkManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookmarkController : ControllerBase
    {
        private readonly IBookmarkRepository _bookmarkRepository;
    public BookmarkController(IBookmarkRepository bookmarkRepository)
    {
      _bookmarkRepository = bookmarkRepository;
    }
 
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Bookmark>>> GetBookmark()
    {
        var bookmarks = await _bookmarkRepository.GetAll();
        return Ok(bookmarks);
    }
 
    [HttpGet("{id}")]
    public async Task<ActionResult<Bookmark>> GetBookmark(int id)
    {
        var bookmark = await _bookmarkRepository.Get(id);
        if(bookmark == null)
            return NotFound();
 
        return Ok(bookmark);
    }
 
    [HttpPost]
    public async Task<ActionResult> CreateProduct(CreateBookmarkDto createBookmarkDto)
    {
        Bookmark bookmark = new()
        {
            BookmarkName = createBookmarkDto.Name,
            URL = createBookmarkDto.URL,
            CreationDate = DateTime.Now
        };
 
        await _bookmarkRepository.Add(bookmark);
        return Ok();
    }
 
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteBookmark(int id)
    {
        await _bookmarkRepository.Delete(id);
        return Ok();
    }
 
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateBookmark(int id, UpdateBookmarkDto updateBookmarkDto)
    {
        Bookmark bookmark = new()
        {
            ID = id,
            BookmarkName = updateBookmarkDto.Name,
            URL = updateBookmarkDto.URL
        };
 
        await _bookmarkRepository.Update(bookmark);
        return Ok();
    }
    }
}