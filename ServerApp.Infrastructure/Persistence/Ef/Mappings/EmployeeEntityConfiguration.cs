using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerApp.Core.Entities;

namespace ServerApp.Infrastructure.Persistence.Ef.Mappings
{
    internal class EmployeeEntityConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Dob).HasColumnType("smalldatetime").IsRequired();
            builder.Property(x => x.FullName).HasColumnType("varchar(80)").IsRequired();
            builder.Property(x => x.Ssn).HasColumnType("varchar(15)").IsRequired();
            builder.Property(x => x.Salary).HasColumnType("money").IsRequired();
        }
    }
}
