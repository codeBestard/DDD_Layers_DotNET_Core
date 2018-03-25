using System;
using OSR.Infrastructure.Persistance.Sql.Entities;

namespace OSR.Infrastructure.Persistance.Sql.Seed
{
    public static class Seeder
    {
        public static void Seed(OSRDbContext context)
        {
            var course1 = new Course
            {
                Id = Guid.NewGuid(), Title = "Java", MaxCapacity = 20,
                StartDateTime = new DateTime( 2018, 7, 1, 9, 0 ,0 ),
                EndDateTime  = new DateTime( 2018 , 7 , 1 , 12 , 0 , 0 )
            };
            var course2 = new Course
            {
                Id = Guid.NewGuid(), Title = "JavaScript", MaxCapacity = 20 ,
                StartDateTime = new DateTime( 2018 , 7 , 2 , 13 , 0 , 0 ) ,
                EndDateTime = new DateTime( 2018 , 7 , 2 , 15 , 0 , 0 )
            };
            var course3 = new Course
            {
                Id = Guid.NewGuid() ,Title = "C#" , MaxCapacity = 20 ,
                StartDateTime = new DateTime( 2018 , 7 , 2 , 12 , 0 , 0 ) ,
                EndDateTime = new DateTime( 2018 , 7 , 2 , 14 , 0 , 0 )
            };

            var student1 = new Student
            {
                Id = Guid.NewGuid(), FirstName = "John", LastName = "Doe"
            };
            var student2 = new Student
            {
                Id = Guid.NewGuid(), FirstName = "Jame", LastName = "Green"
            };
            var student3 = new Student
            {
                Id = Guid.NewGuid(), FirstName = "Marry", LastName = "Chase"
            };
            var student4 = new Student
            {
                Id = Guid.NewGuid(), FirstName = "Kate", LastName = "Almond"
            };

            var instructor1 = new Instructor
            {
                Id = Guid.NewGuid(), FirstName = "Dan", LastName = "Johnson"
            };
            var instructor2 = new Instructor
            {
                Id = Guid.NewGuid(), FirstName = "Sam", LastName = "Hung"
            };
            var instructor3 = new Instructor
            {
                Id = Guid.NewGuid(), FirstName = "Gil", LastName = "Torre"
            };

            var couseEnrollment1 = new CourseEnrollment
            {
                Student = student1, Course = course1 
            };
            var couseEnrollment2 = new CourseEnrollment
            {
                Student = student2 , Course = course2
            };
            var couseEnrollment3 = new CourseEnrollment
            {
                Student = student3 , Course = course3
            };

            var courseAssignment1 = new CourseAssignment
            {
                Instructor = instructor1, Course = course1
            };
            var courseAssignment2 = new CourseAssignment
            {
                Instructor = instructor2 ,Course = course2
            };
            var courseAssignment3 = new CourseAssignment
            {
                Instructor = instructor3 ,Course = course3
            };

            context.AddRange(couseEnrollment1, couseEnrollment2,couseEnrollment3);
            context.AddRange(courseAssignment1, courseAssignment2, courseAssignment3);
        }
    }
}
