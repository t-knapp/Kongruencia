using AutoMapper;
using LinqKit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kongruencia.Server
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICoverageService _coverageService;

        public BranchesController(IMapper mapper, ICoverageService coverageService) =>
            (_mapper, _coverageService) = (mapper, coverageService);

        [HttpGet("{productName}")]
        public async Task<ActionResult<IEnumerable<BranchResource>>> Get(string productName)
        {
            var predicate = PredicateBuilder.New<Coverage>(true);
            if (!(productName is null))
                predicate = predicate.And(c => c.ProductName.Equals(productName));
            var result = await _coverageService.ListAsync(predicate);
            if (!result.isSuccess)
                return NotFound();

            var data = _mapper.Map<IEnumerable<BranchResource>>(result.result).Distinct().ToList();
            return Ok(data);
        }
    }
}
