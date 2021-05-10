using Domain.Domain;
using Domain.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Infrastructure
{
    public class ShopClothesContext : DbContext
    {
        public ShopClothesContext()
        {
        }

        public ShopClothesContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<Domain.Type> Type { get; set; }
        public DbSet<TypeProduct> TypeProducts { get; set; }
        public DbSet<Description> Descriptions { get; set; }
        public DbSet<FileAttachment> FileAttachments { get; set; }
        public DbSet<FileAttachmentData> FileAttachmentDatas { get; set; }
        public DbSet<User> Users { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProductSizeEntityConfiguration());
            modelBuilder.ApplyConfiguration(new SizeEntityConfiguration());
            modelBuilder.ApplyConfiguration(new FileAttachmentEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.Entity<FileAttachmentData>(option =>
                option.HasKey(i => i.FileId)
                );
            modelBuilder.Entity<TypeProduct>(option =>
            {
                option.HasKey(i => new { i.TypeId, i.ProductId });
            });
        }
    }
}
