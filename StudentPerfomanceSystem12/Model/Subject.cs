namespace StudentPerfomanceSystem12.Model
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string? SubjectName { get; set; }

        public ICollection<Assessment> Assessments { get; set; } = new List<Assessment>();
    }
}
