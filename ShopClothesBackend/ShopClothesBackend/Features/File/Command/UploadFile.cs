using Domain.Domain;
using Domain.Infrastructure;
using MediatR;
using ShopClothesBackend.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShopClothesBackend.Features.File.Command
{
    public class UploadFile
    {
        public class Command : IRequest<BaseResponseModel<FileAttachment>>
        {
            public byte[] FileByte { get; set; }
            public string Name { get; set; }
            public string Ext { get; set; }

        }
        public class Handler : IRequestHandler<Command, BaseResponseModel<FileAttachment>>
        {
            private ShopClothesContext _context;
            public Handler(ShopClothesContext context)
            {
                _context = context;
            }
            public async Task<BaseResponseModel<FileAttachment>> Handle(Command request, CancellationToken cancellationToken)
            {
                var fileAttachment = new FileAttachment()
                {
                    Name = request.Name,
                    CreatedDate = DateTime.Now,
                    Ext = request.Ext,
                    FileAttachmentData = new FileAttachmentData()
                    {
                        Data = request.FileByte
                    }
                };

                _context.FileAttachments.Add(fileAttachment);
                await _context.SaveChangesAsync();

                fileAttachment.FileAttachmentData = null;
                return new BaseResponseModel<FileAttachment>() { 
                    IsSuccess = true,
                    Data = fileAttachment
                };
            }
        }
    }
}
