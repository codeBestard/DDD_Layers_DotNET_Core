using System;
using MediatR;

namespace OSR.Domain.Events.Course
{
    public class StudentEnrolledDomainEvent : INotification
    {
        public Guid CourseId { get; }
        public Guid StudentId { get; }

        public StudentEnrolledDomainEvent(
            Guid courseId ,
            Guid studentId )
        {
            CourseId = courseId;
            StudentId = studentId;
        }
    }
}