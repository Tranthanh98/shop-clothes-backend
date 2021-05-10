using Domain.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Infrastructure.Configuration
{
    public class FileAttachmentEntityConfiguration : IEntityTypeConfiguration<FileAttachment>
    {
        public void Configure(EntityTypeBuilder<FileAttachment> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.HasOne(i => i.FileAttachmentData)
                .WithOne(i => i.FileAttachment)
                .HasForeignKey<FileAttachmentData>(p=>p.FileId);

        }
    }
}
