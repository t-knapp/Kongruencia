using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Domain.Services.FormFileStorage
{
    public interface IFormFileStorage
    {
        Task<ServiceResult<string>> Save(IFormFile formFile);
    }
}
