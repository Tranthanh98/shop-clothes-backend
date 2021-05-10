using Domain.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Infrastructure.Configuration
{
    public class SizeEntityConfiguration : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder.HasKey(i => i.Id);
            builder.HasData(
                new Size() { Id = 1, Name = "XS" },
                new Size() { Id = 2, Name = "S" },
                new Size() { Id = 3, Name = "M" },
                new Size() { Id = 4, Name = "L" },
                new Size() { Id = 5, Name = "XL" }
                );
        }
    }
}
