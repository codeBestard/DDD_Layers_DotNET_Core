using System;

namespace OSR.Application.ReadModels
{
    public class StudentRM
    {
        public Guid StudentId   { get; set; }
        public string FirstName { get; set; }
        public string LastName  { get; set; }
    }
}
