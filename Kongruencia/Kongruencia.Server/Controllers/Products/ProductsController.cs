using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Kongruencia.Server
{
    public class ProductsController : Controller
    {

        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

    }
}