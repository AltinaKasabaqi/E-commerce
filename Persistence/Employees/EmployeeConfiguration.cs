using LMS.Domain.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Employees
{
    public class EmployeeConfiguration
           : IEntityTypeConfiguration<Employee>
    {

        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(p => p.Id);

            // Add any additional configuration here
            builder.Property(p => p.Firstname).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Lastname).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Position).IsRequired().HasMaxLength(100);
            builder.Property(p => p.DateOfBirth).IsRequired();
            builder.Property(p => p.DateJoined).IsRequired();

            builder.HasOne<Employee>(e => e.ReportsTo)
                   .WithMany()
                   .HasForeignKey(e => e.ReportsTo)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
