using Domain.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopClothesBackend.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace ShopClothesBackend.Features.Product.Command
{
    public class DummyData
    {
        public class ImportModel
        {
            [FromBody]
            public int Id { get; set; }
            [FromBody]
            public string Image { get; set; }
            [FromBody]
            public string Name { get; set; }
            [FromBody]
            public string Price { get; set; }
            [FromBody]
            public string Description { get; set; }
            [FromBody]
            public bool IsNew { get; set; }
            [FromBody]
            public bool IsHotSale { get; set; }
            [FromBody]
            public List<string> Size { get; set; }
        }
        public class Command : IRequest<BaseResponseModel>
        {
            public List<ImportModel> ImportModels { get; set; }
        }
        public class Handler : IRequestHandler<Command, BaseResponseModel>
        {
            private ShopClothesContext _context;
            private List<Domain.Domain.Size> Sizes;
            public Handler(ShopClothesContext context)
            {
                _context = context;
            }
            public async Task<BaseResponseModel> Handle(Command request, CancellationToken cancellationToken)
            {
                Sizes = await _context.Sizes.ToListAsync();

                var productList = new List<Domain.Domain.Product>();
                using (WebClient webClient = new WebClient())
                {
                    foreach (var product in request.ImportModels)
                    {
                        var pro = new Domain.Domain.Product()
                        {
                            Name = product.Name,
                            IsActive = true,
                            IsHotSale = product.IsHotSale,
                            IsNew = product.IsNew,
                            Decriptions = new List<Domain.Domain.Description>() { new Domain.Domain.Description() { Title = product.Description } },
                            Price = Decimal.Parse(product.Price),
                            ProductSizes = product.Size.Select(i => new Domain.Domain.ProductSize()
                            {
                                IsActive = true,
                                Quantity = 100,
                                SizeId = (int)(Sizes.FirstOrDefault(m => m.Name == i)?.Id)
                            }).ToList(),
                            TypeId = 1,
                        };
                        try
                        {
                            byte[] titleImage = await webClient.DownloadDataTaskAsync("http:" + product.Image);
                            pro.TitleImage = new Domain.Domain.FileAttachment()
                            {
                                CreatedBy = "me",
                                CreatedDate = DateTime.Now,
                                Ext = ".jpg",
                                Name = "image" + DateTime.Now.ToString(),
                                FileAttachmentData = new Domain.Domain.FileAttachmentData()
                                {
                                    Data = titleImage
                                }
                            };
                        }
                        catch (Exception e)
                        {

                        }
                        finally
                        {
                            productList.Add(pro);
                        }

                    }

                }
                _context.Products.AddRange(productList);
                await _context.SaveChangesAsync();
                return new BaseResponseModel() { IsSuccess = true };
            }
        }
    }
}
