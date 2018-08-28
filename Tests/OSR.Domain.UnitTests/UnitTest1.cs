using OSR.Application.ReadModels;
using System;
using System.Linq;
using FluentAssertions;
using OSR.Domain.Common.ValueObjects;
using Xunit;

namespace OSR.Domain.UnitTests
{
    public class CourseDMShould
    {
        [Fact]
        public void CreateCourse()
        {
            var numberOfDays = DateTimeRange.CreateOneWeekRange(DateTime.Now);
            var maxCapacity = new Capacity(20);
            var instructorId = Guid.NewGuid();
            var students = new[]
            {
                new StudentDM(Guid.NewGuid(), "John", "Adam"),
                new StudentDM(Guid.NewGuid(), "Marry", "Smith") 
            };
            var course = CourseDM.CreateCourse("Computer", numberOfDays, maxCapacity, instructorId, students);

            course.Should().NotBeNull();
        }


        [Fact]
        public void AddStudent()
        {
            var numberOfDays = DateTimeRange.CreateOneWeekRange( DateTime.Now );
            var maxCapacity = new Capacity( 20 );
            var instructorId = Guid.NewGuid();
            var students = Enumerable.Empty<StudentDM>();
            var course = CourseDM.CreateCourse( "Computer", numberOfDays, maxCapacity, instructorId, students );

            course.AddStudent( new StudentDM( Guid.NewGuid(), "John", "Adam" ));

            course.Students.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void RemoveStudent()
        {
            var numberOfDays = DateTimeRange.CreateOneWeekRange( DateTime.Now );
            var maxCapacity = new Capacity( 20 );
            var instructorId = Guid.NewGuid();
            var students = new[]
            {
                new StudentDM(Guid.NewGuid(), "John", "Adam"),
                new StudentDM(Guid.NewGuid(), "Marry", "Smith")
            };
            var course = CourseDM.CreateCourse( "Computer", numberOfDays, maxCapacity, instructorId, students );

            course.RemoveStudent(students.First().Id);

            course.Students.Count.Should().Be(1);
        }
    }
}
