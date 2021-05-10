using AutoMapper;
using Domain.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopClothesBackend.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static ShopClothesBackend.Features.Product.Queries.GetProductHomePage;

namespace ShopClothesBackend.Features.Product.Queries
{
    public class Get
    {
        public class ProductModel : ProductHomePageModel
        {

        }
        public class Request : Pagination
        {
            public string SearchText { get; set; }
            public int OrderBy { get; set; }
        }
        public class Query : IRequest<BaseResponseModel<Pagination<ProductModel>>>
        {
            [FromBody]
            public Request RequestModel { get; set; }
        }
        public class Handler : IRequestHandler<Query, BaseResponseModel<Pagination<ProductModel>>>
        {
            private ShopClothesContext _context;
            private IMapper _mapper;
            public Handler(ShopClothesContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<BaseResponseModel<Pagination<ProductModel>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var ack = new BaseResponseModel<Pagination<ProductModel>>();
                var query = _context.Products
                    .Include(i => i.TitleImage)
                    .Include(i => i.Decriptions).AsQueryable();
                if (!String.IsNullOrEmpty(request.RequestModel.SearchText))
                {
                    query = query.Where(i => i.Name.Contains(request.RequestModel.SearchText));
                }
                var data = new List<Domain.Domain.Product>();
                if(request.RequestModel.PageIndex == default || request.RequestModel.PageSize == default)
                {
                    data = await query.ToListAsync();
                }
                else
                {
                    data = await query.Skip(request.RequestModel.Skip()).Take(request.RequestModel.PageSize).ToListAsync();
                }

                ack.Data = new Pagination<ProductModel>()
                {
                    PageIndex = request.RequestModel.PageIndex,
                    PageSize = request.RequestModel.PageSize,
                    TotalItem = query.Count(),
                    Data = _mapper.Map<List<ProductModel>>(data)
                };
                ack.IsSuccess = true;
                return ack;
            }
        }
    }
}
