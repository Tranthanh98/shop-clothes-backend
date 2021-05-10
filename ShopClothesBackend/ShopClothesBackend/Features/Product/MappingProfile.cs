using AutoMapper;
using ShopClothesBackend.Common;
using ShopClothesBackend.Features.Product.Command;
using ShopClothesBackend.Features.Product.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ShopClothesBackend.Features.Product.Queries.Get;
using static ShopClothesBackend.Features.Product.Queries.GetProductHomePage;

namespace ShopClothesBackend.Features.Product
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Create.CreateModel, Domain.Domain.Product>();
            CreateMap<Domain.Domain.Product, ProductHomePageModel>()
                .ForMember(des => des.ImageId, opt => opt.MapFrom(src => src.TitleImage.Id))
                .ForMember(des => des.Size, 
                            opt => opt
                                .MapFrom(src => src.ProductSizes
                                        .Select(i =>
                                                new Selectable(i.SizeId.ToString(), i.Size.Name))));
            CreateMap<Domain.Domain.Product, Detail.DetailProduct>()
                .ForMember(des => des.ImageId, opt => opt.MapFrom(src => src.TitleImage.Id))
                .ForMember(des => des.Size,
                            opt => opt
                                .MapFrom(src => src.ProductSizes
                                        .Select(i =>
                                                new Selectable(i.SizeId.ToString(), i.Size.Name))))
                .ForMember(des => des.Description, opt => opt.MapFrom(src => src.Decriptions.Select(i => i.Title)))
                .ForMember(des => des.ImageListId, opt => opt.MapFrom(src => src.Images.Select(i => i.Id)));

            CreateMap<Domain.Domain.Product, ProductModel>()
                .ForMember(des => des.ImageId, opt => opt.MapFrom(src => src.TitleImage.Id))
                .ForMember(des => des.Description, opt => opt.MapFrom(src => src.Decriptions.Select(i => i.Title)));
        }
    }
}
