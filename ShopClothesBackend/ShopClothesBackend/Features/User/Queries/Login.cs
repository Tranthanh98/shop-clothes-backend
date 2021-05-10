using AutoMapper;
using Domain.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopClothesBackend.Common;
using ShopClothesBackend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShopClothesBackend.Features.User.Queries
{
    public class Login
    {
        public class ResponseLogin
        {
            public string UserName { get; set; }
            public string FullName { get; set; }
            public string Token { get; set; }
        }
        public class Query : IRequest<BaseResponseModel<ResponseLogin>>
        {
            [FromBody]
            public string Email { get; set; }
            [FromBody]
            public string Password { get; set; }
        }
        public class Handler : IRequestHandler<Query, BaseResponseModel<ResponseLogin>>
        {
            private ShopClothesContext _context;
            private IMapper _mapper;
            public Handler(ShopClothesContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<BaseResponseModel<ResponseLogin>> Handle(Query request, CancellationToken cancellationToken)
            {
                var ack = new BaseResponseModel<ResponseLogin>();
                var user = await _context.Users.FirstOrDefaultAsync(i => i.Email == request.Email);
                if(user == null)
                {
                    ack.Messages.Add("Email hoặc mật khẩu không đúng");
                    return ack;
                }
                if (!HashPasswordService.VerifyPassword(user, request.Password))
                {
                    ack.Messages.Add("Mật khẩu không đúng");
                    return ack;
                }
                var token = TokenService.CreateToken(user);
                ack.Data = _mapper.Map<ResponseLogin>(user);
                ack.Data.Token = token;
                ack.IsSuccess = true;
                return ack;
            }
        }
    }
}
