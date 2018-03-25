using System;
using System.Collections.Generic;

namespace OSR.Application.ReadModels
{
    public class CourseRM
    {
        public Guid CourseId                           { get; set; }
        public string Title                            { get;  set; }
        public DateTime StarttDateTime                 { get;  set; }
        public DateTime EndDateTime                    { get;  set; }
        public int MaxCapacity                         { get;  set; }
        public IEnumerable<StudentRM> Students         { get;  set; }
    }
}