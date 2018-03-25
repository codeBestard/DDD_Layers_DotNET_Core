using System;
using System.Collections;
using System.Collections.Generic;

namespace OSR.Infrastructure.Persistance.Sql.Entities
{
    internal sealed class Student
    {
        public Guid Id          { get; set; }
        public string FirstName { get; set; }
        public string LastName  { get; set; }

        public IList<CourseEnrollment> CourseEnrollments { get; set; }
    }
}