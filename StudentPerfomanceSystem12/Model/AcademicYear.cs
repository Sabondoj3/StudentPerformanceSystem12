public class AcademicYear
{
    public int AcademicYearId { get; set; }
    public string YearName { get; set; }

    public ICollection<Student> Students { get; set; }
}
