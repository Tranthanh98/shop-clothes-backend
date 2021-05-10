using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain
{
    public class FileAttachmentData
    {
        public int FileId { get; set; }
        public byte[] Data { get; set; }
        public virtual FileAttachment FileAttachment { get; set; }
    }
}
