
using EF01_Demo.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF01_Demo.Configration
{
    internal class DepartmentConfigration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(D => D.DeptID);

            builder.Property(d => d.DeptID).UseIdentityColumn(10, 10);

            builder.Property(D => D.Name)
                            .HasColumnName("DeptName") // name of table in database
                            .HasColumnType("varchar")
                            .HasMaxLength(50)
                            .HasDefaultValue("TestDefaultValue")
                            .IsRequired(false);

            
        }
    }
}
