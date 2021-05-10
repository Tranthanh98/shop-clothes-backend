using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopClothesBackend.Common
{
    public class BaseResponseModel
    {
        public bool IsSuccess { get; set; }
        public List<string> Messages { get; set; }
        public BaseResponseModel()
        {
            Messages = new List<string>();
        }

    }
    public class BaseResponseModel<T> : BaseResponseModel
    {
        public T Data { get; set; }
    }
}
