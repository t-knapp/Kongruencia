using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Server.Domain.Services.FormFileStorage
{
    public class FileSystemStorage : IFormFileStorage
    {
        // TODO: Configure path in ctor

        public async Task<ServiceResult<string>> Save(IFormFile formFile)
        {
            var filePath = Path.GetTempFileName();

            using (var stream = File.Create(filePath))
            {
                await formFile.CopyToAsync(stream);
            }

            return new ServiceResult<string>(filePath);
        }
    }
}
