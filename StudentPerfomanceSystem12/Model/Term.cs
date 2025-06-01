using StudentPerfomanceSystem12.Model;
using static StudentPerfomanceSystem12.Data.StudentDbContext;

namespace StudentPerfomanceSystem12.Model
{
    public class Term
    {
        public int TermId { get; set; }
        public int TermNumber { get; set; }  // Values: 1, 2, or 3

        public int AcademicYearId { get; set; }
        public AcademicYear? AcademicYear { get; set; }

        public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
    }
}
