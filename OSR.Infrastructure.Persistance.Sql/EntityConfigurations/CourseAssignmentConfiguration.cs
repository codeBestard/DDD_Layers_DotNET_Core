using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OSR.Infrastructure.Persistance.Sql.Entities;

namespace OSR.Infrastructure.Persistance.Sql.EntityConfigurations
{
    internal sealed class CourseAssignmentConfiguration : IEntityTypeConfiguration<CourseAssignment>
    {
        public void Configure( EntityTypeBuilder<CourseAssignment> builder )
        {
            builder.HasKey( ca => new { ca.CourseId , ca.InstructorId } );

            builder.HasOne( ca => ca.Instructor )
                .WithMany( ca => ca.CourseAssignments )
                .HasForeignKey( ca => ca.InstructorId )
                .OnDelete( deleteBehavior: DeleteBehavior.Restrict );

            builder.HasOne( ca => ca.Course )
                .WithMany( ca => ca.CourseAssignments )
                .HasForeignKey( ca => ca.CourseId )
                .OnDelete( deleteBehavior: DeleteBehavior.Restrict );
        }
    }
}