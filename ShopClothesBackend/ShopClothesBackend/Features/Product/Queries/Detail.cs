using AutoMapper;
using Domain.Infrastructure;
using MediatR;
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
    public class Detail
    {
        public class DetailProduct : ProductHomePageModel
        {
            public List<int> ImageListId { get; set; }
            public List<string> LinkImageList
            {
                get;
                set;
            }
        }
        public class Query : IRequest<BaseResponseModel<DetailProduct>>
        {
            public int Id { get; set; }
            public string BaseUrl { get; set; }
        }
        public class Handler : IRequestHandler<Query, BaseResponseModel<DetailProduct>>
        {
            private ShopClothesContext _context;
            private IMapper _mapper;
            public Handler(ShopClothesContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<BaseResponseModel<DetailProduct>> Handle(Query request, CancellationToken cancellationToken)
            {
                var ack = new BaseResponseModel<DetailProduct>();
                var product = await _context.Products
                    .Include(i => i.ProductSizes)
                    .ThenInclude(i => i.Size)
                    .Include(i => i.TitleImage)
                    .Include(i => i.Decriptions)
                    .Include(i => i.Images)
                    .FirstOrDefaultAsync(i => i.Id == request.Id);
                if(product == null)
                {
                    ack.Messages.Add("Sản phẩm không tồn tại");
                }
                var proModel = _mapper.Map<DetailProduct>(product);
                proModel.ImageLink = "http://" + request.BaseUrl + "/api/file/GetFileByID/" + proModel.ImageId;
                proModel.ImageListId.ForEach(i =>
                {
                    var link = "http://" + request.BaseUrl + "/api/file/GetFileByID/" + i;
                    proModel.LinkImageList.Add(link);
                });
                ack.Data = proModel;
                ack.IsSuccess = true;
                return ack;
            }
        }
    }
}
