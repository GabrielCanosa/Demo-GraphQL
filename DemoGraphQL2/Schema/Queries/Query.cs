using Bogus;

namespace DemoGraphQL2.Schema.Queries
{
    public class Query
    {
        private readonly Faker<InstructorType> _instructorFaker;
        private readonly Faker<StudentType> _studentFaker;
        private readonly Faker<CourseType> _courseFaker;

        public Query()
        {
            _instructorFaker = new Faker<InstructorType>()
                .RuleFor(c => c.Id, r => Guid.NewGuid())
                .RuleFor(c => c.FirstName, r => r.Name.FirstName())
                .RuleFor(c => c.LastName, r => r.Name.LastName())
                .RuleFor(c => c.Salary, r => (double)r.Finance.Amount());

            _studentFaker = new Faker<StudentType>()
                .RuleFor(c => c.Id, r => Guid.NewGuid())
                .RuleFor(c => c.FirstName, r => r.Name.FirstName())
                .RuleFor(c => c.LastName, r => r.Name.LastName())
                .RuleFor(c => c.GPA, r => (double)r.Finance.Amount(0, 100, 0));

            _courseFaker = new Faker<CourseType>()
                .RuleFor(c => c.Id, r => Guid.NewGuid())
                .RuleFor(c => c.Name, r => r.Name.JobTitle())
                .RuleFor(c => c.Subject, r => r.PickRandom<Subject>())
                .RuleFor(c => c.Instructor, r => _instructorFaker.Generate())
                .RuleFor(c => c.Students, r => _studentFaker.Generate(5));
        }

        public IEnumerable<CourseType> GetCourses()
        {
            var courses = _courseFaker.Generate(5);
            return courses;
        }

        public async Task<CourseType> GetCourseByIdAsync(Guid id)
        {
            await Task.Delay(1000);

            var course = _courseFaker.Generate();
            course.Id = id;
            return course;
        }

        [GraphQLDeprecated("This query is not in use")]
        public string SayHelloToMyLittleFriend => "Boom!";
    }
}
