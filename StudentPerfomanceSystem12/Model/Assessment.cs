using static StudentPerfomanceSystem12.Data.StudentDbContext;

namespace StudentPerfomanceSystem12.Model
{
    public class Assessment
    {
        public int AssessmentId { get; set; }
        public string? TestType { get; set; }  // "Test1" or "Test2"
        public double Score { get; set; }

        public int StudentId { get; set; }
        public Student? Student { get; set; }

        public int SubjectId { get; set; }
        public Subject? Subject { get; set; }

        public int TermId { get; set; }
        public Term? Term { get; set; }
    }
}
