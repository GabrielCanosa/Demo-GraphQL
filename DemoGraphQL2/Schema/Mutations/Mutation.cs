using DemoGraphQL2.Schema.Queries;
using DemoGraphQL2.Schema.Subscriptions;
using HotChocolate.Subscriptions;

namespace DemoGraphQL2.Schema.Mutations
{
    public class Mutation
    {
        private readonly List<CourseResult> _courses;

        public Mutation()
        {
            _courses = new List<CourseResult>();
        }

        public async Task<CourseResult> CreateCourse(string name, Subject subject, Guid instructorId, [Service] ITopicEventSender topicEventSender)
        {
            var courseResult = new CourseResult
            {
                Id = Guid.NewGuid(),
                Name = name,
                Subject = subject,
                InstructorId = instructorId
            };

            _courses.Add(courseResult);
            await topicEventSender.SendAsync(nameof(Subscription.CourseTypeCreated), courseResult);

            return courseResult;
        }

        public async Task<CourseResult> UpdateCourse(Guid id,string name, Subject subject)
        {
            var course = _courses.FirstOrDefault(c => c.Id == id);

            if (course == null)
                throw new Exception("This couse does not exists");

            course.Name = name;
            course.Subject = subject;

            return course;
        }

        public List<CourseResult> DeleteCourse(Guid id)
        {
            var course = _courses.FirstOrDefault(c => c.Id == id);

            if (course == null)
                throw new GraphQLException(new Error("Course not found", "COURSE_NOT_FOUND"));

            _courses.Remove(course);

            return _courses;
        }
    }
}
