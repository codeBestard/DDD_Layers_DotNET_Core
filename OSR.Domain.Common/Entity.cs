using System;
using System.Collections.Generic;
using MediatR;

namespace OSR.Domain.Common
{
    public abstract class Entity<TId> : IEquatable<Entity<TId>>
    {
        public virtual TId Id { get; protected set; }

        protected Entity( TId id )
        {
            if( object.Equals( id , default( TId ) ) )
            {
                throw new ArgumentException( "The ID cannot be the type's default value." , nameof( id ) );
            }

            this.Id = id;
        }

        protected Entity( )
        {
        }

        // for optimistic locking
        //public virtual int Version { get; protected set; }

        // domain events for aggreate during its lifetime
        private List<INotification> _domainEvents;
        public IList<INotification> DomainEvents => _domainEvents;

        public void AddDomainEvent( INotification eventItem )
        {
            _domainEvents = _domainEvents ?? new List<INotification>();
            _domainEvents.Add( eventItem );
        }
        public void RemoveDomainEvent( INotification eventItem )
        {
            _domainEvents?.Remove( eventItem );
        }

        // MUST clear Events after each use
        public virtual void ClearEvents( )
        {
            _domainEvents.Clear();
        }

        public override bool Equals( object other )
        {
            if( other is Entity<TId> entity )
            {
                return this.Equals( entity );
            }
            return base.Equals( other );
        }

        public virtual bool Equals( Entity<TId> other )
        {
            if( other is null )
            {
                return false;
            }
            return this.Id.Equals( other.Id );
        }
        public static bool operator ==( Entity<TId> x , Entity<TId> y )
        {
            return x.Equals( y );
        }

        public static bool operator !=( Entity<TId> x , Entity<TId> y )
        {
            return !( x == y );
        }

        public override int GetHashCode( )
        {
            return ( GetType().ToString() + this.Id ).GetHashCode();
        }
    }
}
