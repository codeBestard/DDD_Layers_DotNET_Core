using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OSR.Infrastructure.Persistance.Sql.Entities;

namespace OSR.Infrastructure.Persistance.Sql.EntityConfigurations
{
    internal sealed class CourseEnrollmentConfiguration : IEntityTypeConfiguration<CourseEnrollment>
    {
        public void Configure( EntityTypeBuilder<CourseEnrollment> builder )
        {
            builder.HasKey( c => new { c.CourseId, c.StudentId} );

            builder.HasOne(c => c.Student)
                .WithMany(c => c.CourseEnrollments)
                .HasForeignKey(c => c.StudentId)
                .OnDelete(deleteBehavior: DeleteBehavior.Restrict);

            builder.HasOne( c => c.Course )
                .WithMany( c => c.CourseEnrollments )
                .HasForeignKey( c => c.CourseId )
                .OnDelete( deleteBehavior: DeleteBehavior.Restrict );
        }
    }
}