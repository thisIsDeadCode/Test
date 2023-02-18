using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.Api.Data;
using Test.Api.Extensions;
using Test.Api.Models.Requests;
using Test.Api.Models.Responses;

namespace Test.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly TestApiContext _context;

        public AuthorsController(TestApiContext context)
        {
            _context = context;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorResponse>>> GetAuthors()
        {
            if (_context.Authors == null)
            {
                return NotFound();
            }
         
            return (await _context.Authors.ToListAsync()).ToAuthorReponse();
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorResponse>> GetAuthor(int id)
        {
            if (_context.Authors == null)
            {
                return NotFound();
            }
            var author = await _context.Authors.FindAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            return author.ToAuthorReponse();
        }

        // PUT: api/Authors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, AuthorRequest author)
        {
            if (id != author.Id)
            {
                return BadRequest();
            }

            _context.Entry(author.ToAuthorModel()).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Authors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AuthorResponse>> PostAuthor(AuthorRequest author)
        {
            if (_context.Authors == null)
            {
                return Problem("Entity set 'TestApiContext.Authors'  is null.");
            }
            var authorModel = author.ToAuthorModel();
            _context.Authors.Add(authorModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthor", new { id = authorModel.Id }, authorModel.ToAuthorReponse());
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            if (_context.Authors == null)
            {
                return NotFound();
            }
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AuthorExists(int id)
        {
            return (_context.Authors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
