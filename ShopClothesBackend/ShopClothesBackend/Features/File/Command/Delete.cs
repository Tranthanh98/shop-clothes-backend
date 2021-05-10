using Domain.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopClothesBackend.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShopClothesBackend.Features.File.Command
{
    public class Delete
    {
        public class Command : IRequest<BaseResponseModel>
        {
            public int Id { get; set; }
        }
        public class Handler : IRequestHandler<Command, BaseResponseModel>
        {
            private ShopClothesContext _context;
            public Handler(ShopClothesContext context)
            {
                _context = context;
            }
            public async Task<BaseResponseModel> Handle(Command request, CancellationToken cancellationToken)
            {
                var response = new BaseResponseModel();
                var file = await _context.FileAttachments
                                .Include(i => i.FileAttachmentData)
                                .Where(i => i.Id == request.Id)
                                .FirstOrDefaultAsync();
                if(file == null)
                {
                    response.Messages.Add("File không tồn tại");
                    return response;
                }
                _context.FileAttachments.Remove(file);
                await _context.SaveChangesAsync();
                return new BaseResponseModel()
                {
                    IsSuccess = true
                };
            }
        }
    }
}
