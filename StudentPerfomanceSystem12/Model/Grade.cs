using static StudentPerfomanceSystem12.Data.StudentDbContext;

namespace StudentPerfomanceSystem12.Model
{
    public class Grade
    {
        public int GradeId { get; set; }

        public int StudentId { get; set; }
        public Student? Student { get; set; }

        public int SubjectId { get; set; }
        public Subject? Subject { get; set; }

        public int AcademicYearId { get; set; }
        public AcademicYear? AcademicYear { get; set; }

        public double Term1Mean { get; set; }
        public double Term2Mean { get; set; }
        public double Term3Mean { get; set; }

        public double YearlyMean { get; set; }
    }
}
