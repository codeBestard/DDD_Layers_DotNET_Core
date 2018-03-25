using System;

namespace OSR.Infrastructure.Persistance.Sql.Entities
{
    internal class CourseAssignment
    {
        public Guid InstructorId     { get; set; }
        public Instructor Instructor { get; set; }

        public Guid CourseId         { get; set; }
        public Course Course         { get; set; }
    }
}