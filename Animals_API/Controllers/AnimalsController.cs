using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Animals_API.Model;

namespace Animals_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly animals_DB _context;
        private readonly ILogger<AnimalsController> _logger;

        public AnimalsController(animals_DB context, ILogger<AnimalsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Animals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Animal>>> GetAnimals()
        {
          if (_context.Animals == null)
          {
                _logger.LogCritical($"Database is empty?!");
                return NotFound();
          }
            return await _context.Animals.ToListAsync();
        }

        // GET: api/Animals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Animal>> GetAnimal(int id)
        {
          if (_context.Animals == null)
          {
              return NotFound();
          }
            var animal = await _context.Animals.FindAsync(id);

            if (animal == null)
            {
                _logger.LogInformation($"User input {id} was used to search and returned no results.");

                return NotFound();
            }

            _logger.LogError("Error log!");
            _logger.LogCritical("Critical log!");
            _logger.LogDebug("Debug log!");
            _logger.LogTrace("Trace log!");

            return animal;
          }

        // PUT: api/Animals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimal(int id, Animal animal)
        {
            if (id != animal.Id)
            {
                return BadRequest();
            }

            _context.Entry(animal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalExists(id))
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

        // POST: api/Animals
        [HttpPost]
        public async Task<ActionResult<Animal>> PostAnimal(Animal animal)
        {
          if (_context.Animals == null)
          {
              return Problem("Entity set 'animals_DB.Animals'  is null.");
          }
            _context.Animals.Add(animal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnimal", new { id = animal.Id }, animal);
        }

        // DELETE: api/Animals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimal(int id)
        {
            if (_context.Animals == null)
            {
                return NotFound();
            }
            var animal = await _context.Animals.FindAsync(id);
            if (animal == null)
            {
                return NotFound();
            }

            _context.Animals.Remove(animal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnimalExists(int id)
        {
            return (_context.Animals?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
