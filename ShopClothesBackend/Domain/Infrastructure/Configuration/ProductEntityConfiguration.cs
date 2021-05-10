using Domain.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Infrastructure.Configuration
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(p => p.Price).HasColumnType("decimal(14,2)");

            //type
            //builder.HasMany(i => i.TypeProducts)
            //    .WithOne(s => s.Product)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasForeignKey(s => s.ProductId);
            builder.HasOne(i => i.Type)
                .WithMany(i => i.Products)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasForeignKey(i => i.TypeId);
            //desciption
            builder.HasMany(i => i.Decriptions)
                .WithOne(i => i.Product)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasForeignKey(i => i.ProductId);
            //titleimage
            builder.HasOne(s => s.TitleImage)
                .WithOne(s => s.ProductTitle)
                .HasForeignKey<FileAttachment>(i=>i.ProductTitleId);
            //list Image
            builder.HasMany(s => s.Images)
                .WithOne(s => s.ProductImage)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasForeignKey(s => s.ProductImageId);

        }
    }
}
