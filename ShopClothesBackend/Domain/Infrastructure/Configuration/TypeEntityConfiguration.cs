using Domain.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Infrastructure.Configuration
{
    public class TypeEntityConfiguration : IEntityTypeConfiguration<Domain.Type>
    {
        public void Configure(EntityTypeBuilder<Domain.Type> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.HasOne(i => i.Parent)
                .WithMany(i => i.Children)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasForeignKey(i => i.ParentId);
            
            builder.HasData(
                new Domain.Type() {Id = 1, Name = "Đồ Nam" },
                new Domain.Type() {Id = 2, Name = "Đồ Nữ" },
                new Domain.Type() {Id = 3, Name = "Áo Nam", ParentId = 1 },
                new Domain.Type() {Id = 4, Name = "Quần Nam", ParentId = 1 },
                new Domain.Type() {Id = 5, Name = "Áo Nữ", ParentId  =2 },
                new Domain.Type() {Id = 6, Name = "Quần Nữ", ParentId = 2 }

                );
        }
    }
}
