using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LinqKit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kongruencia.Server
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICoverageService _coverageService;

        public ProductsController(IMapper mapper, ICoverageService coverageService) =>
            (_mapper, _coverageService) = (mapper, coverageService);

        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            var predicate = PredicateBuilder.New<Coverage>(true);
            var result = await _coverageService.ListAsync(predicate);
            if (!result.isSuccess)
                return NotFound();

            return Ok(result.result.Select((c) => c.ProductName).Distinct().ToList());
        }
    }
}