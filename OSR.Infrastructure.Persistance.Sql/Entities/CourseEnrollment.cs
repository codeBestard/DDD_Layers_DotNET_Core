using System;

namespace OSR.Infrastructure.Persistance.Sql.Entities
{
    internal class CourseEnrollment 
    {
        public Guid StudentId     { get; set; }
        public Student Student    { get; set; }

        public Guid CourseId      { get; set; }
        public Course Course      { get; set; }
    }
}