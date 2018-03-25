using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace OSR.Domain.Events.Course
{
    public class AddCourseStartedDomainEvent : INotification
    {
        public Guid CourseId  { get; }
        public string Title   { get; }
        public DateTime Start { get; }
        public DateTime End   { get; }
        
        public AddCourseStartedDomainEvent(Guid courseId, string title, DateTime start, DateTime end )
        {
            CourseId = courseId;
            Title    = title;
            Start    = start;
            End      = end;
        }
    }
}
