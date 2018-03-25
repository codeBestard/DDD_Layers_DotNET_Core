using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OSR.Infrastructure.Persistance.Sql.Entities
{
    internal class Course
    {
        public Guid Id                                   { get; set; }
        public string Title                              { get; set; }
        public DateTime StartDateTime                    { get; set; }
        public DateTime EndDateTime                      { get; set; }       
        public int MaxCapacity                           { get; set; }

        public IList<CourseEnrollment> CourseEnrollments { get; set; }
        public IList<CourseAssignment> CourseAssignments { get; set; }
    }
}