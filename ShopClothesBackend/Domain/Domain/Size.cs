using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain
{
    public class Size
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ProductSize> ProductSizes { get; set; }
    }
}
