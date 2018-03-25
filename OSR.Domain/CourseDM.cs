using System;
using System.Collections.Generic;
using System.Linq;
using OSR.Domain.Common;
using OSR.Domain.Common.Exceptions;
using OSR.Domain.Common.ValueObjects;
using OSR.Domain.Events.Course;

namespace OSR.Domain
{
    public class CourseDM : Entity<Guid>, IAggregateRoot
    {
        private readonly List<StudentDM> _students;

        public string Title                { get; }
        public Guid InstructorId           { get; }
        public DateTimeRange DateTimeRange { get; }
        public Capacity MaxCapacity        { get; }
        public IReadOnlyCollection<StudentDM> Students => _students.AsReadOnly();
        public CourseDM( Guid id ,
            string title , 
            DateTimeRange dateTimeRange ,
            Capacity maxCapacity ,
            Guid instructorId ,
            IEnumerable<StudentDM> students, 
            bool isNew= false )
        {
            Id            = id;
            Title         = title;
            DateTimeRange = dateTimeRange;
            MaxCapacity   = maxCapacity;
            InstructorId  = instructorId;
            _students      = students is null ?   new List<StudentDM>() : students.ToList();

            if(isNew)
                this.AddDomainEvent( new AddCourseStartedDomainEvent( Id , title , dateTimeRange.Start , dateTimeRange.End ) );
        }

        public static CourseDM CreateCourse(
            string title,
            DateTimeRange dateTimeRange,
            Capacity maxCapacity,
            Guid instructorId,
            IEnumerable<StudentDM> students)
        {
            var course = new CourseDM(Guid.NewGuid(),title, dateTimeRange,maxCapacity,instructorId,students );
            return course;
        }
        public int CurrentHeadCount => _students.Count;
        public void RemoveStudent( Guid studentId )
        {
            if( studentId == Guid.Empty )
            {
                return;
            }

            var student = _students.FirstOrDefault( s => s.Id == studentId );
            if( !( student is null ) )
            {
               _students.Remove( student );

                this.AddDomainEvent( new StudentUnenrolledDomainEvent( this.Id , studentId ) );
            }
        }

        public void AddStudent( StudentDM student )
        {
            if( Students.Any( s => s.Id == student.Id ) )
            {
                throw new DomainLayerException( "can not enroll duplicate student to course" );
            }

            if( MaxCapacity.IsOverLimit( Students.Count ) )
            {
                throw new DomainLayerException( "can not add more student to course" );
            }

            _students.Add( student );

            this.AddDomainEvent( new StudentEnrolledDomainEvent( this.Id , student.Id ) );
        }

    }

}