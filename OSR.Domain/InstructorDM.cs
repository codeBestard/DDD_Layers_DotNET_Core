using System;
using OSR.Domain.Common;

namespace OSR.Domain
{
    public class InstructorDM : Entity<Guid>, IAggregateRoot
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public InstructorDM( Guid id , string firstName , string lastName )
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}