using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain
{
    public class FileAttachment
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Ext { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public virtual FileAttachmentData FileAttachmentData { get; set; }
        public virtual Product ProductTitle { get; set; }
        public int? ProductTitleId { get; set; }
        public virtual Product ProductImage { get; set; }
        public int? ProductImageId { get; set; }

    }
}
