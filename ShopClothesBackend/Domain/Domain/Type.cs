using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain
{
    public class Type
    {
        public Type()
        {

        }
        public Type(Type type)
        {
            Id = type.Id;
            Name = type.Name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public virtual Type Parent { get; set; }
        public virtual ICollection<Type> Children { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
