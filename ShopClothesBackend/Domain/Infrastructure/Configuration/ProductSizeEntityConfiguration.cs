using Domain.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Infrastructure.Configuration
{
    public class ProductSizeEntityConfiguration : IEntityTypeConfiguration<ProductSize>
    {
        public void Configure(EntityTypeBuilder<ProductSize> builder)
        {
            builder.HasKey(i => new { i.SizeId, i.ProductId });
            builder.HasOne(i => i.Product)
                .WithMany(i => i.ProductSizes)
                .OnDelete(DeleteBehavior.ClientSetNull)

                .HasForeignKey(i => i.ProductId);
            //
            builder.HasOne(i => i.Size)
                .WithMany(i => i.ProductSizes)
                .OnDelete(DeleteBehavior.ClientSetNull)

                .HasForeignKey(i => i.SizeId);

        }
    }
}
