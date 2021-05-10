using Domain.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopClothesBackend.Common;
using ShopClothesBackend.Features.File.Command;
using ShopClothesBackend.Features.File.Queries;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ShopClothesBackend.Features.File
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private IMediator _mediator;
        public FileController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<BaseResponseModel<FileAttachment>> UploadFile(IFormFile file)
        {
            var response = new BaseResponseModel<FileAttachment>();
            var command = new UploadFile.Command();
            if (file.Length > 0)
            {
                command.Name = file.FileName;
                command.Ext = file.ContentType;
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    command.FileByte = fileBytes;
                }
                response = await _mediator.Send(command, default);
                return response;
            }

            return response;
        }
        [HttpGet]
        public async Task<BaseResponseModel> DeleteFile(int id)
        {
            var response = await _mediator.Send(new Delete.Command() { Id = id }, default);
            return response;
        }
        [HttpGet("{id}")]
        [ResponseCache(Duration = 2592000, Location = ResponseCacheLocation.Any, NoStore = false)]
        public async Task<IActionResult> GetFileById(int id)
        {
            try
            {
                var file = await _mediator.Send(new GetFileById.Query() { Id = id}, default);
                Response.Headers.Add("Content-Disposition", DateTime.Now.ToString());

                return new FileContentResult(file, "image/jpeg");
                //return File(
                //        file, System.Net.Mime.MediaTypeNames.Application.Octet, "image"+DateTime.Now.ToString());
            }
            catch(Exception e)
            {
                return this.NotFound(e.Message.ToString()); 
            }
        }
        
    }
}
