public class Student
{
    public int StudentId { get; set; }
    public string? FullName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? Level { get; set; }

    public int AcademicYearId { get; set; }   // FK
    public AcademicYear? AcademicYear { get; set; }

    public ICollection<StudentSubject> StudentSubjects { get; set; }
}
