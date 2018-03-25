using System;
using System.Collections.Generic;

namespace OSR.Domain.Common.ValueObjects
{
    public class Capacity : ValueObject
    {
        public int MaxOccupant { get; }
        private Capacity( ) { }

        public Capacity(int maxOccupant)
        {
            if (maxOccupant < 1)
            {
                throw new InvalidOperationException();
            }

            MaxOccupant = maxOccupant;
        }

        public static Capacity operator +( Capacity capicity , int increaseCount )
        {
            return new Capacity(capicity.MaxOccupant + increaseCount);
        }

        public static Capacity operator -( Capacity capacity , int decreaseCount )
        {
            var newCount = capacity.MaxOccupant - decreaseCount;
            var result = new Capacity( newCount < 1 ? 0 : newCount);
            return result;
        }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return MaxOccupant;
        }

        public bool IsOverLimit(int newMax)
        {
            var result = newMax > this.MaxOccupant ;
            return result;
        }
    }
}