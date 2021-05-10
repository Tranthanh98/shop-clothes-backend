using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain
{
    public class Description
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
