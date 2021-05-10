using AutoMapper;
using Domain.Domain;
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
    public class GetProductHomePage
    {
        public class ProductHomePageModel
        {
           
            public int Id { get; set; }
           
            public int ImageId { get; set; }
            public string ImageLink {
                get
                {
                    return "http://localhost:57750/api/file/GetFileByID/" + ImageId;
                }
            }
           
            public string Name { get; set; }
           
            public decimal Price { get; set; }
           
            public List<string> Description { get; set; }
           
            public bool IsNew { get; set; }
           
            public bool IsHotSale { get; set; }
           
            public List<Selectable> Size { get; set; }
        }
        public class HomeModel
        {
            public List<ProductHomePageModel> NewProductList { get; set; }
            public List<ProductHomePageModel> HotSaleList { get; set; }
        }
        public class Query : IRequest<BaseResponseModel<HomeModel>>
        {
            
        }
        public class Handler : IRequestHandler<Query, BaseResponseModel<HomeModel>>
        {
            private ShopClothesContext _context;
            private IMapper _mapper;
            public Handler(ShopClothesContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<BaseResponseModel<HomeModel>> Handle(Query request, CancellationToken cancellationToken)
            {
                var ack = new BaseResponseModel<HomeModel>();
                var query = _context.Products
                    .Include(i => i.ProductSizes)
                    .ThenInclude(i => i.Size)
                    .Include(i => i.TitleImage)
                    .Where(i => i.ProductSizes.Any(m=> (bool)(m.IsActive)))
                    .AsQueryable();
                var queryHotSale = await query.Where(i => i.IsHotSale).ToListAsync();
                var queryIsNew = await query.Where(i => i.IsNew).ToListAsync();
                var hotSales = _mapper.Map<List<ProductHomePageModel>>(queryHotSale);
                var newProducts = _mapper.Map<List<ProductHomePageModel>>(queryIsNew);
                ack.IsSuccess = true;
                ack.Data = new HomeModel()
                {
                    HotSaleList = hotSales,
                    NewProductList = newProducts
                };
                return ack;

            }
        }
    }
}
