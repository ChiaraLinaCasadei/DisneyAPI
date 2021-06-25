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
    //[Route("api/characters")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly DisneyContext _context;

        public CharactersController(DisneyContext context)
        {
            _context = context;
        }

        //Lista de Personajes mostrando todo

        [HttpGet]
        [Route("api/charactersList")]
        public async Task<ActionResult<IEnumerable<Character>>> GetcharactersComplete()
        {
            return await _context.characters.ToListAsync();

        }

        //Listado de Personajes, mostrando solo Nombre e Imagen 

        [HttpGet]
        [Route("api/characters")]
        public async Task<ActionResult<IEnumerable<string[]>>> Getcharacters()
        {
            var ListCharacters = await _context.characters.ToListAsync();

            List<string[]> ListImgName = new List<string[]>();

            foreach(Character c in ListCharacters)
            {
                string[] ListImgNameItem = { "", "" };

                ListImgNameItem[0] = c.CharacterImage;

                ListImgNameItem[1] = c.CharacterName;

                ListImgName.Add(ListImgNameItem);
            }

            return ListImgName;
        }

        // GET: api/characters/5
        //Detalle del Personaje

        [HttpGet("api/characters/{id}")]
        public async Task<ActionResult<Character>> GetCharacter(Guid id)
        {
            var character = await _context.characters.FindAsync(id);

            if (character == null)
            {
                return NotFound();
            }

            return character;
        }


        //Búsqueda de Personajes por Nombre, Edad y Peso (el id de pelicula está en MultimediasController)
        //GET: api/characters/5

        [HttpGet]
        [Route("api/characters/name={characterName}")]
        [Route("api/characters/age={characterAge}")]
        [Route("api/characters/weight={characterWeight}")]

        public async Task<ActionResult<IEnumerable<Character>>> GetCharacterByFilter (string characterName, int characterAge, int characterWeight)
        {
            var characters = await _context.characters.ToListAsync();

            List<Character> filteredCharacters = new List<Character>();

            //selecting the filter and adding to a new list

            if (characterName != null)
            {
                foreach(Character c in characters)
                {
                    if(c.CharacterName == characterName)
                    {
                        filteredCharacters.Add(c);
                    }
                }

            }
            else if (characterAge != 0) 
            {
                foreach (Character c in characters)
                {
                    if(c.CharacterAge == characterAge)
                    {
                        filteredCharacters.Add(c);
                    }
                }

            }
            else if (characterWeight != 0)
            {
                foreach (Character c in characters)
                {
                    if (c.CharacterWeight == characterWeight)
                    {
                        filteredCharacters.Add(c);
                    }
                }

            }

            return filteredCharacters;
        }



        // PUT: api/characters/5

        //Edicion de Personaje

        [HttpPut("api/characters/{id}")]
        public async Task<IActionResult> PutCharacter(Guid id, Character character)
        {
            if (id != character.CharacterID)
            {
                return BadRequest();
            }

            _context.Entry(character).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterExists(id))
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

        // POST: api/characters
        // Creación de Personaje

        [HttpPost]
        [Route("api/characters")]
        public async Task<ActionResult<Character>> PostCharacter(Character character)
        {
            _context.characters.Add(character);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCharacter", new { id = character.CharacterID }, character);
        }

        // DELETE: api/characters/5
        //Eliminación de Personajes

        [HttpDelete("api/characters/{id}")]
        public async Task<IActionResult> DeleteCharacter(Guid id)
        {
            var character = await _context.characters.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }

            _context.characters.Remove(character);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CharacterExists(Guid id)
        {
            return _context.characters.Any(e => e.CharacterID == id);
        }
    }
}
