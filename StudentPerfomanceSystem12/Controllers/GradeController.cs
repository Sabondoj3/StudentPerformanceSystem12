using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPerfomanceSystem12.Data;
using StudentPerfomanceSystem12.Model;

namespace StudentPerfomanceSystem12.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GradesController : ControllerBase
    {
        private readonly StudentDbContext _context;

        public GradesController(StudentDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetGrades()
        {
            var grades = await _context.Grades
                .Include(g => g.Student)
                .Include(g => g.Subject)
                .Include(g => g.AcademicYear)
                .ToListAsync();

            return Ok(grades);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGrade(int id)
        {
            var grade = await _context.Grades
                .Include(g => g.Student)
                .Include(g => g.Subject)
                .Include(g => g.AcademicYear)
                .FirstOrDefaultAsync(g => g.GradeId == id);

            if (grade == null)
                return NotFound();

            return Ok(grade);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGrade([FromBody] Grade grade)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _context.Grades.AddAsync(grade);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGrade), new { id = grade.GradeId }, grade);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGrade(int id, [FromBody] Grade grade)
        {
            if (id != grade.GradeId)
                return BadRequest();

            _context.Entry(grade).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrade(int id)
        {
            var grade = await _context.Grades.FindAsync(id);
            if (grade == null)
                return NotFound();

            _context.Grades.Remove(grade);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
