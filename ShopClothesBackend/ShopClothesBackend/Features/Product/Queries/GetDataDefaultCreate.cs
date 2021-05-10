using Domain.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopClothesBackend.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShopClothesBackend.Features.Product.Queries
{
    public class GetDataDefaultCreate
    {
        public class DefaultDataCreate
        {
            public List<Selectable> TypeOpotions { get; set; }
            public List<Selectable> SizeOptions { get; set; }
        }
        public class Query : IRequest<BaseResponseModel<DefaultDataCreate>>
        {

        }
        public class Handler : IRequestHandler<Query, BaseResponseModel<DefaultDataCreate>>
        {
            private ShopClothesContext _context;
            public Handler(ShopClothesContext context)
            {
                _context = context;
            }
            public async Task<BaseResponseModel<DefaultDataCreate>> Handle(Query request, CancellationToken cancellationToken)
            {
                var typeList = await _context.Type.ToListAsync();
                var sizeList = await _context.Sizes.ToListAsync();

                //var test = GetTreeData(typeList);

                var types = typeList.Select(i => new Selectable() { Label = i.Name, Value = i.Id.ToString() }).ToList();

                
                return new BaseResponseModel<DefaultDataCreate>()
                {
                    IsSuccess = true,
                    Data = new DefaultDataCreate()
                    {
                        TypeOpotions = typeList.Select(i => new Selectable() { Label = i.Name, Value = i.Id.ToString() }).ToList(),
                        SizeOptions = sizeList.Select(i => new Selectable() { Label = i.Name, Value = i.Id.ToString() }).ToList()
                    }
                };
            }
            private List<Domain.Domain.Type> GetTreeData (List<Domain.Domain.Type> datas, int? parentId = null)
            {
                foreach (var item in datas)
                {
                    item.Children = datas.Where(i => i.ParentId == parentId).ToList();
                    if(item.ParentId != null)
                    {
                        item.Children = GetTreeData(datas, item.ParentId);
                    }
                }
                return datas;
            }
        }
    }
}
