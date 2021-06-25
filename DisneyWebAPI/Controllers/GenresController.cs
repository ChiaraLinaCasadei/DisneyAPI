using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DisneyWebAPI.Models;

namespace DisneyWebAPI.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly DisneyContext _context;

        public GenresController(DisneyContext context)
        {
            _context = context;
        }

        // GET: api/Genres
        /*[HttpGet]
        public async Task<ActionResult<IEnumerable<Genre>>> Getgenres()
        {
            return await _context.genres.ToListAsync();
        }*/

        // GET: api/Genres/5
        [HttpGet("api/movies/genre={idGenero}/order={order}")]
        [HttpGet("api/movies/genre={idGenero}")]
        public async Task<ActionResult<IEnumerable<Multimedia>>> GetGenre(Guid idGenero, string order)
        {
            var genre = await _context.genres.FindAsync(idGenero);

            if (genre == null)
            {
                return NotFound();
            }

            List<Multimedia> sortedMultimedias = new List<Multimedia>();

            if (order == "ASC")
            {
                sortedMultimedias = genre.GenreMult.OrderBy(m => m.MultDate).ToList();
            }

            else if (order == "DESC")
            {
                sortedMultimedias = genre.GenreMult.OrderByDescending(m => m.MultDate).ToList();
            }
            return sortedMultimedias;
        }

        // PUT: api/Genres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /*[HttpPut("{id}")]
        public async Task<IActionResult> PutGenre(Guid id, Genre genre)
        {
            if (id != genre.GenreID)
            {
                return BadRequest();
            }

            _context.Entry(genre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenreExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }*/

        // POST: api/Genres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        
        /*[HttpPost]
        public async Task<ActionResult<Genre>> PostGenre(Genre genre)
        {
            _context.genres.Add(genre);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGenre", new { id = genre.GenreID }, genre);
        }*/

        // DELETE: api/Genres/5
        /*[HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(Guid id)
        {
            var genre = await _context.genres.FindAsync(id);
            if (genre == null)
            {
                return NotFound();
            }

            _context.genres.Remove(genre);
            await _context.SaveChangesAsync();

            return NoContent();
        }*/

        private bool GenreExists(Guid id)
        {
            return _context.genres.Any(e => e.GenreID == id);
        }
    }
}
