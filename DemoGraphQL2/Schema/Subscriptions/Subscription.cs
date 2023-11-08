using DemoGraphQL2.Schema.Mutations;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;

namespace DemoGraphQL2.Schema.Subscriptions
{
    public class Subscription
    {
        [Subscribe]
        public CourseResult CourseTypeCreated([EventMessage] CourseResult course) => course;
    }
}
