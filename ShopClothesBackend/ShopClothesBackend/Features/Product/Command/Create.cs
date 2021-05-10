using AutoMapper;
using Domain.Domain;
using Domain.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopClothesBackend.Common;
using ShopClothesBackend.Common.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShopClothesBackend.Features.Product.Command
{
    public class Create
    {
        public class CreateModel
        {
            public int TitleImageId { get; set; }
            public List<int> ImageIdList { get; set; }
            public List<ProductSize> ProductSizes { get; set; }
            public List<Description> Description { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int TypeId { get; set; }
        }
        public class Command : IRequest<BaseResponseModel>
        {
            [FromBody]
            public CreateModel Product { get; set; }
        }
        public class Handler : IRequestHandler<Command, BaseResponseModel>
        {
            private ShopClothesContext _context;
            private IMapper _mapper;
            public Handler(ShopClothesContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<BaseResponseModel> Handle(Command request, CancellationToken cancellationToken)
            {
                var product = _mapper.Map<Domain.Domain.Product>(request.Product);
                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                var titleImage = await _context.FileAttachments.FirstOrDefaultAsync(i => i.Id == request.Product.TitleImageId);
                if(titleImage != null)
                {
                    titleImage.ProductTitleId = product.Id;
                }
                var imgList = _context.FileAttachments.Where(i => request.Product.ImageIdList.Contains(i.Id));
                foreach(var item in imgList)
                {
                    item.ProductImageId = product.Id;
                }
                await _context.SaveChangesAsync();

                return new BaseResponseModel()
                {
                    IsSuccess = true
                };
            }
        }
    }
}
