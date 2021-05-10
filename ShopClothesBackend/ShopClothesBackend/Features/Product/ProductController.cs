using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopClothesBackend.Common;
using ShopClothesBackend.Features.Product.Command;
using ShopClothesBackend.Features.Product.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ShopClothesBackend.Features.Product.Queries.Detail;
using static ShopClothesBackend.Features.Product.Queries.Get;
using static ShopClothesBackend.Features.Product.Queries.GetDataDefaultCreate;

namespace ShopClothesBackend.Features.Product
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [AllowAnonymous]

    public class ProductController : ControllerBase
    {
        private IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Authorize]
        public async Task<BaseResponseModel> CreateNewProduct([FromBody]Create.Command command)
        {
            var result = await _mediator.Send(command, default);
            return result;
        }
        [HttpGet]
        public async Task<BaseResponseModel<DefaultDataCreate>> GetDefaultDataForCreate()
        {
            var result = await _mediator.Send(new Queries.GetDataDefaultCreate.Query(), default);
            return result;
        }
        [HttpPost]
        public async Task<BaseResponseModel> DummyDataProduct([FromBody] DummyData.Command command)
        {
            var result = await _mediator.Send(command, default);
            return result;
        }
        [HttpGet]
        public async Task<BaseResponseModel> GetHomePageProduct()
        {
            var result = await _mediator.Send(new GetProductHomePage.Query(), default);
            return result;
        }
        [HttpGet("{id}")]
        public async Task<BaseResponseModel<DetailProduct>> Detail(int id)
        {
            var result = await _mediator.Send(new Detail.Query() { Id = id }, default);
            return result;
        }
        [HttpPost]
        public async Task<BaseResponseModel<Pagination<ProductModel>>> Get([FromBody]Get.Query query)
        {
            var result = await _mediator.Send(query, default);
            return result;
        }
    }
}
