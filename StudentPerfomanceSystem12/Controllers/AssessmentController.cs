using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPerfomanceSystem12.Data;
using StudentPerfomanceSystem12.Model;

namespace StudentPerfomanceSystem12.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssessmentsController : ControllerBase
    {
        private readonly StudentDbContext _context;

        public AssessmentsController(StudentDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAssessments()
        {
            var assessments = await _context.Assessments
                .Include(a => a.Student)
                .Include(a => a.Subject)
                .Include(a => a.Term)
                .ToListAsync();

            return Ok(assessments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAssessment(int id)
        {
            var assessment = await _context.Assessments
                .Include(a => a.Student)
                .Include(a => a.Subject)
                .Include(a => a.Term)
                .FirstOrDefaultAsync(a => a.AssessmentId == id);

            if (assessment == null)
                return NotFound();

            return Ok(assessment);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAssessment([FromBody] Assessment assessment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _context.Assessments.AddAsync(assessment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAssessment), new { id = assessment.AssessmentId }, assessment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAssessment(int id, [FromBody] Assessment assessment)
        {
            if (id != assessment.AssessmentId)
                return BadRequest();

            _context.Entry(assessment).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssessment(int id)
        {
            var assessment = await _context.Assessments.FindAsync(id);
            if (assessment == null)
                return NotFound();

            _context.Assessments.Remove(assessment);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
