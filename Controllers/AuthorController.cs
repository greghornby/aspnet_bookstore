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
    [Route("authors")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly BookStoreContext _context;

        public AuthorController(BookStoreContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorsModel>>> GetAuthors()
        {
          if (_context.Authors == null)
          {
              return NotFound();
          }
            return await _context.Authors.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorsModel>> GetAuthorModel(long id)
        {
          if (_context.Authors == null)
          {
              return NotFound();
          }
            var authorModel = await _context.Authors.FindAsync(id);

            if (authorModel == null)
            {
                return NotFound();
            }

            return authorModel;
        }

        private bool AuthorModelExists(long id)
        {
            return (_context.Authors?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
