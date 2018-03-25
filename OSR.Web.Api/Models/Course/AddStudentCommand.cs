using System;


namespace OSR.Web.Api.Models.Course
{
    public class AddStudentCommand
    {
        public Guid StudentId { get; }
        public Guid CourseId { get; }

        public AddStudentCommand(Guid studentId, Guid courseId)
        {
            StudentId = studentId;
            CourseId = courseId;
        }
    }
}
