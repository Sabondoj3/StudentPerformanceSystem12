using System.Reactive.Subjects;
using Microsoft.EntityFrameworkCore;
using StudentPerfomanceSystem12.Model;

namespace StudentPerfomanceSystem12.Data
{
    public class StudentDbContext : DbContext
    {
        internal object Grade;

        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Model.Subject> Subjects { get; set; }


        public DbSet<Term> Terms { get; set; }
        public DbSet<AcademicYear> AcademicYears { get; set; }
        public DbSet<Assessment> Assessments { get; set; }

        public DbSet<Grade> Grades { get; set; }   // <-- Add this line for Grades table
    }
}
