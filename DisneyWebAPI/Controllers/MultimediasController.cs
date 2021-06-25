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
    //[Route("api/movies")]
    [ApiController]
    public class MultimediasController : ControllerBase
    {
        private readonly DisneyContext _context;

        public MultimediasController(DisneyContext context)
        {
            _context = context;
        }

        //Listado completo de peliculas

        [HttpGet]
        [Route("api/moviesList")]
        public async Task<ActionResult<IEnumerable<Multimedia>>> GetmultimediasComplete()
        {
            return await _context.multimedias.ToListAsync();

        }



        // Listado de películas, mostrando Imagen, Título y Fecha de Creacion

        [HttpGet]
        [Route("api/movies")]
        public async Task<ActionResult<IEnumerable<string[]>>> Getmultimedias()
        {
            var ListMultimedia = await _context.multimedias.ToListAsync();

            List<string[]> ListImgTtleDate = new List<string[]>();

            foreach (Multimedia m in ListMultimedia)
            {
                string[] ListImgTtleDateItem = { "", "", "" };

                ListImgTtleDateItem[0] = m.MultImage;

                ListImgTtleDateItem[1] = m.MultTitle;

                ListImgTtleDateItem[2] = m.MultDate.ToString();

                ListImgTtleDate.Add(ListImgTtleDateItem);
            }

            return ListImgTtleDate;
        }

        //Detalle de la película/serie con sus personajes

        [HttpGet]
        [Route("api/movies/{id}")]
        public async Task<ActionResult<Multimedia>> GetMultimedia(Guid id)
        {
            var multimedia = await _context.multimedias.FindAsync(id);

            if (multimedia == null)
            {
                return NotFound();
            }

            return multimedia;
        }
        //Criterio de búsqueda, personajes en base a la película en la que participaron

        [HttpGet]
        [Route("api/characters/movies={characterIDMovie}")]
        public async Task<ActionResult<IEnumerable<Character>>> GetCharactersByMultimedia(Guid characterIDMovie)
        {
            var multimedia = await _context.multimedias.FindAsync(characterIDMovie);

            if (multimedia == null)
            {
                return NotFound();
            }

            return multimedia.MultCast;
        }

        //Edición de la Pelicula/Serie

        [HttpPut]
        [Route("api/movies/{id}")]
        public async Task<IActionResult> PutMultimedia(Guid id, Multimedia multimedia)
        {
            if (id != multimedia.MultId)
            {
                return BadRequest();
            }

            _context.Entry(multimedia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MultimediaExists(id))
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

        //Creación de la película/serie

        [HttpPost]
        [Route("api/movies")]
        public async Task<ActionResult<Multimedia>> PostMultimedia(Multimedia multimedia)
        {
            _context.multimedias.Add(multimedia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMultimedia", new { id = multimedia.MultId }, multimedia);
        }

        // Eliminación de la película/serie

        [HttpDelete]
        [Route("api/movies/{id}")]
        public async Task<IActionResult> DeleteMultimedia(Guid id)
        {
            var multimedia = await _context.multimedias.FindAsync(id);
            if (multimedia == null)
            {
                return NotFound();
            }

            _context.multimedias.Remove(multimedia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MultimediaExists(Guid id)
        {
            return _context.multimedias.Any(e => e.MultId == id);
        }

        //Búsqueda de Películas/Series por titulo, género, y ordenar por fecha de forma ascendente o descendente

        [HttpGet]
        [Route("api/movies/name={_movieTitle}/order={order}")]
        [Route("api/movies/name={_movieTitle}")]
        public async Task<ActionResult<IEnumerable<Multimedia>>> GetMultimediaByName(string _movieTitle, string order)
        {
            var multimedias = await _context.multimedias.ToListAsync();

            if (_movieTitle == null)
            {
                return NotFound();
            }
            List<Multimedia> filteredMultimedias = new List<Multimedia>();

            //filtrado

            foreach(Multimedia m in multimedias)
            {
                if(m.MultTitle == _movieTitle)
                {
                    filteredMultimedias.Add(m);
                }
            }

            //ordenado
            
            List<Multimedia> sortedMultimedias = new List<Multimedia>();

            if (order == "ASC")
            {
               sortedMultimedias = filteredMultimedias.OrderBy(m => m.MultDate).ToList();
            }
            
            else if(order == "DESC")
            {
               sortedMultimedias = filteredMultimedias.OrderByDescending(m => m.MultDate).ToList();
            }


            return sortedMultimedias;
        }














    }

            
}
    
 

