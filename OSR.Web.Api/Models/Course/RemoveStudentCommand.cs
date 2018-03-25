using System;

namespace OSR.Web.Api.Models.Course
{
    public class RemoveStudentCommand
    {
        public Guid StudentId { get; }
        public Guid CourseId { get; }

        public RemoveStudentCommand( Guid studentId , Guid courseId )
        {
            StudentId = studentId;
            CourseId = courseId;
        }
    }
}