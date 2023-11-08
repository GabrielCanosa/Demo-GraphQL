using DemoGraphQL2.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DemoGraphQL2.Services
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
        {
        }

        public DbSet<CourseDto> CourseDtos { get; set; }
        public DbSet<InstructorDto> InstructorDtos { get; set; }
        public DbSet<StudentDto> StudentDtos { get; set; }

    }
}
