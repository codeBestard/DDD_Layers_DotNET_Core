using System;
using OSR.Domain.Common;

namespace OSR.Domain
{
    public class StudentDM : Entity<Guid>, IAggregateRoot
    {
        public static StudentDM EmptyStudent = new StudentDM();

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        private StudentDM()
        {
        }

        public StudentDM( Guid id , string firstName , string lastName )
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

    }
}