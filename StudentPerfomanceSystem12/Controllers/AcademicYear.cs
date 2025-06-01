using Microsoft.AspNetCore.Mvc;
using StudentPerfomanceSystem12.Data;
using StudentPerfomanceSystem12.Model;
using Microsoft.EntityFrameworkCore;

namespace StudentPerfomanceSystem12.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AcademicYearsController : ControllerBase
    {
        private readonly StudentDbContext _context;

        public AcademicYearsController(StudentDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAcademicYears()
        {
            var years = await _context.AcademicYears.ToListAsync();
            return Ok(years);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAcademicYear([FromBody] AcademicYear academicYear)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _context.AcademicYears.AddAsync(academicYear);
            await _context.SaveChangesAsync();

            return Ok(academicYear);
        }
    }
}
