﻿using DemoGraphQL2.Enums;

namespace DemoGraphQL2.Schema.Queries
{
    public class CourseType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Subject Subject { get; set; }
        public InstructorType Instructor { get; set; }
        public IEnumerable<StudentType> Students { get; set; }
    }
}
