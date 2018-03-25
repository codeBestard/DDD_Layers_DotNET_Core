using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OSR.Domain;
using OSR.Domain.Common;
using OSR.Infrastructure.Persistance.Sql.Entities;
using OSR.Infrastructure.Persistance.Sql.EntityConfigurations;
using OSR.Infrastructure.Persistance.Sql.Extensions;
using OSR.Infrastructure.Persistance.Sql.Extensions.MediatR;

namespace OSR.Infrastructure.Persistance.Sql
{
    public class OSRDbContext : DbContext
    {
        private readonly IMediator _mediator;

        //private OnlineSchoolRegistrationDbContext(DbContextOptions<OnlineSchoolRegistrationDbContext> options) : base(options){}


        public OSRDbContext(
            DbContextOptions<OSRDbContext> options,
            IMediator mediator)
            : base(options)
        {
            this._mediator = mediator;
        }

        internal DbSet<Course> Courses                                   { get; set; }
        internal DbSet<CourseEnrollment> CourseEnrollments               { get; set; }
        internal DbSet<Instructor> Instructors                           { get; set; }
        internal DbSet<Student> Students                                 { get; set; }
        internal DbSet<CourseAssignment> CourseAssignments               { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("OSR");

            modelBuilder.RemovePluralizingTableNameConvention();

            modelBuilder.ApplyConfiguration( new CourseConfiguration() );
            modelBuilder.ApplyConfiguration(new InstructorConfiguration() );
            modelBuilder.ApplyConfiguration(new StudentConfiguration() );
            modelBuilder.ApplyConfiguration(new CourseAssignmentConfiguration());
            modelBuilder.ApplyConfiguration(new CourseEnrollmentConfiguration());
        }

        public async Task<int> SaveChangesWithNoticationsAsync(IAggregateRoot aggregateRoot, CancellationToken cancellationToken = default )
        {
            if ( aggregateRoot is null )
            {
                throw new ArgumentNullException(nameof( aggregateRoot ) );
            }

            await _mediator.DispatchDomainEventsAsync( aggregateRoot.DomainEvents );

            int result = await base.SaveChangesAsync( cancellationToken );

            aggregateRoot.ClearEvents();

            return result;
        }
    }
}
