using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public virtual ICollection<Description> Decriptions { get; set; }
        public int? TypeId { get; set; }
        public virtual Type Type { get; set; }
        //public int? ProductSizeId { get; set; }
        public virtual ICollection<ProductSize> ProductSizes { get; set; }
        public bool? IsActive { get; set; }
        public virtual FileAttachment TitleImage { get; set; }
        public virtual ICollection<FileAttachment> Images { get; set; }
        public bool IsNew { get; set; }
        public bool IsHotSale { get; set; }
        
    }
}
