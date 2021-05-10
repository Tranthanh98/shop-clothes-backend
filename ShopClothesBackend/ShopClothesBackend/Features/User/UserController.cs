using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopClothesBackend.Common;
using ShopClothesBackend.Features.User.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ShopClothesBackend.Features.User.Queries.Authentication;

namespace ShopClothesBackend.Features.User
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [AllowAnonymous]
    public class UserController : ControllerBase
    {
        private IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost()]
        public async Task<IActionResult> GoogleAuthentication()
        {
            var properties = new AuthenticationProperties { RedirectUri = Url.Action("GoogleResponse") };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }
        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            var claims = result.Principal.Identities
                .FirstOrDefault().Claims.Select(claim => new
                {
                    claim.Issuer,
                    claim.OriginalIssuer,
                    claim.Type,
                    claim.Value
                });

            return Ok(claims);
        }
        [HttpPost]
        public async Task<BaseResponseModel> CreateUser([FromBody] Command.CreateUser.Command command)
        {
            var result = await _mediator.Send(command, default);
            return result;
        }
        [HttpPost]
        public async Task<BaseResponseModel<Login.ResponseLogin>> LoginUser([FromBody] Login.Query query)
        {
            var result = await _mediator.Send(query, default);
            return result;
        }
    }
}
