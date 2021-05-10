using MediatR;
using ShopClothesBackend.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShopClothesBackend.Features.User.Queries
{
    public class Authentication
    {
        public class UserLogin
        {
            public string Name { get; set; }
            public string UserName { get; set; }
            public string Token { get; set; }
        }
        public class Command : IRequest<BaseResponseModel<UserLogin>>
        {
            public string Password { get; set; }
            public string Email { get; set; }
            public Command(string password, string email)
            {
                Password = password;
                Email = email;
            }
        }
        public class Handler : IRequestHandler<Command, BaseResponseModel<UserLogin>>
        {
            public async Task<BaseResponseModel<UserLogin>> Handle(Command request, CancellationToken cancellationToken)
            {
                throw new Exception();
            }
        }
    }
}
