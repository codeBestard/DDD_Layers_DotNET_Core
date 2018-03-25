using System;
using System.Collections;
using System.Collections.Generic;
using OSR.Domain.Common;

namespace OSR.Infrastructure.Persistance.Sql.Entities
{
    internal class Instructor 
    {
        public Guid Id                                   { get; set; }
        public string FirstName                          { get;  set; }
        public string LastName                           { get;  set; }

        public IList<CourseAssignment> CourseAssignments { get; set; }
    }
}