using System;
using MediatR;

namespace OSR.Domain.Events.Course
{
    public class StudentUnenrolledDomainEvent : INotification
    {
        public Guid CourseId { get; }
        public Guid StudentId { get; }

        public StudentUnenrolledDomainEvent( 
            Guid courseId ,
            Guid studentId )
        {
            CourseId = courseId;
            StudentId          = studentId;
        }
    }
}
