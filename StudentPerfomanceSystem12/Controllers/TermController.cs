using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPerfomanceSystem12.Data;
using StudentPerfomanceSystem12.Model;

namespace StudentPerfomanceSystem12.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TermsController : ControllerBase
    {
        private readonly StudentDbContext _context;

        public TermsController(StudentDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetTerms()
        {
            var terms = await _context.Terms
                                      .Include(t => t.AcademicYear)
                                      .Include(t => t.Subjects)
                                      .ToListAsync();
            return Ok(terms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTerm(int id)
        {
            var term = await _context.Terms
                                     .Include(t => t.AcademicYear)
                                     .Include(t => t.Subjects)
                                     .FirstOrDefaultAsync(t => t.TermId == id);

            if (term == null)
                return NotFound();

            return Ok(term);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTerm([FromBody] Term term)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _context.Terms.AddAsync(term);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTerm), new { id = term.TermId }, term);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTerm(int id, [FromBody] Term term)
        {
            if (id != term.TermId)
                return BadRequest();

            _context.Entry(term).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTerm(int id)
        {
            var term = await _context.Terms.FindAsync(id);
            if (term == null)
                return NotFound();

            _context.Terms.Remove(term);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
