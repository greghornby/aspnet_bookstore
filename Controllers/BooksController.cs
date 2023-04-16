using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStore.Models;

namespace BookStoreApi.Controllers
{
    [Route("books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookStoreContext _context;

        public BooksController(BookStoreContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<BooksModel>>> GetBooks()
        {
          if (_context.Books == null)
          {
              return NotFound();
          }
            return await _context.Books.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<BooksModel>> GetBooksModel(long id)
        {
            if (_context.Books == null)
            {
                return NotFound();
            }
            var query = _context.Books
                .Include(b => b.author)
                .Include(b => b.reviews)
                .IgnoreAutoIncludes()
                .AsNoTracking()
                .Select(book => new BooksModel {
                    id = book.id,
                    title = book.title,
                    isbn = book.isbn,
                    authorID = book.authorID,
                    author = book.author,
                    reviews = book.reviews
                });

            var booksModel = await query.FirstOrDefaultAsync(b => b.id == id);

            if (booksModel == null)
            {
                return NotFound();
            }

            return booksModel;
        }

        // [HttpGet("test")]
        // public async Task<ActionResult<List<BookAndAuthor>>> Test()
        // {
        //     if (_context.Books == null)
        //     {
        //         return NotFound();
        //     }

        //     var query = from book in _context.Books
        //         join author in _context.Authors on book.authorID equals author.id
        //         select new BookAndAuthor {book = book, author = author};

        //     return await query.ToListAsync();
        // }
    }
}

public class BookAndAuthor {
    public BooksModel book {get;set;} = null!;
    public AuthorsModel author {get;set;} = null!;
}