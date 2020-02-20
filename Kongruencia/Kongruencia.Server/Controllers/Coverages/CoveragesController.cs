using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Kongruencia.Server {
    [Route("api/[controller]")]
    [ApiController]
    public class CoveragesController : ControllerBase
    {
        private readonly ILogger<CoveragesController> _logger;
        private readonly IMapper _mapper;
        private readonly ICoverageService _coverageService;

        public CoveragesController(ILogger<CoveragesController> logger, IMapper mapper, ICoverageService coverageService)
            => (_logger, _mapper, _coverageService) = (logger, mapper, coverageService);

        [HttpGet("{id}")]
        public async Task<ActionResult<CoverageResource>> Get(int id)
        {
            var getResult = await _coverageService.GetAsync(id);

            if (!getResult.isSuccess)
                return NotFound();

            return Ok(getResult);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoverageResource>>> Get(
            [FromQuery] string productName = null,
            [FromQuery] string branchName = null,
            [FromQuery] int buildNumber = -1
        )
        {
            var result = await _coverageService.ListAsync(productName, branchName, buildNumber);
            if (!result.isSuccess)
                return NotFound();

            return Ok(result.result);
        }

        [HttpPost]
        [Consumes("application/xml")]
        [ProducesResponseType( StatusCodes.Status201Created )]
        [ProducesResponseType( StatusCodes.Status400BadRequest )]
        public async Task<IActionResult> Post([FromBody] AddCoverageResource addCoverageResource)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var coverage = _mapper.Map<Coverage>(addCoverageResource);
            var addResult = await _coverageService.AddAsync(coverage);
            if (!addResult.isSuccess)
                return BadRequest();

            return CreatedAtAction( nameof( Get ), new { id = addResult.result.Id } );
        }
    }
}