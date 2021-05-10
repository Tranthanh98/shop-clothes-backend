using AutoMapper;
using Domain.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopClothesBackend.Common;
using ShopClothesBackend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShopClothesBackend.Features.User.Command
{
    public class CreateUser
    {
        public class CreateUserModel
        {
            public string FullName { get; set; }
            public string Password { get; set; }
            public string ConfirmPassword { get; set; }
            public string Email { get; set; }
            public string UserName { get; set; }
        }
        public class Command : IRequest<BaseResponseModel>
        {
            [FromBody]
            public CreateUserModel CreateUserModel { get; set; }
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
                var ack = new BaseResponseModel();
                if(request.CreateUserModel.Password.Length <= 6)
                {
                    ack.Messages.Add("Password phải có độ dài hơn 6 ký tự");
                    return ack;
                }
                if(request.CreateUserModel.Password != request.CreateUserModel.ConfirmPassword)
                {
                    ack.Messages.Add("Password nhập lại không chính xác");
                    return ack;
                }
                request.CreateUserModel.Password = HashPasswordService.HashPassword(new Domain.Domain.User(), request.CreateUserModel.Password);
                var user = _mapper.Map<Domain.Domain.User>(request.CreateUserModel);
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return new BaseResponseModel()
                {
                    IsSuccess = true
                };
            }
        }
    }
}
