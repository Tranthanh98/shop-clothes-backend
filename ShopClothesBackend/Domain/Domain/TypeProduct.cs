using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain
{
    public class TypeProduct
    {
        public int ProductId { get; set; }
        public int TypeId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Type Type { get; set; }
    }
}
