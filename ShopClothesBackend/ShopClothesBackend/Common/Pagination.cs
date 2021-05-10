using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopClothesBackend.Common
{
    public class Pagination
    {
        public int PageIndex { get; set; }
        public int TotalItem { get; set; }
        public int PageSize { get; set; }
        public int TotalPage
        {
            get
            {
                try
                {
                    return (int)(Math.Ceiling((double)(TotalItem / PageSize)) + 1);
                }
                catch(DivideByZeroException ex)
                {
                    return 1;
                }
            }
        }
        public int Skip()
        {
            if(PageIndex >= 2)
            {
                return (PageIndex - 1) * PageSize;
            }
            else
            {
                return PageSize;
            }
        }
    }
    public class Pagination<T> : Pagination
    {
        public List<T> Data { get; set; }
    }
}
