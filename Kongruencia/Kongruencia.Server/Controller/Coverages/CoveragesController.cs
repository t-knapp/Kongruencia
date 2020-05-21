using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Kongruencia.Server.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kongruencia.Server.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoveragesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CoveragesController(IMediator mediator, IMapper mapper)
            => (_mediator, _mapper) = (mediator, mapper);

        [HttpPost]
        [Consumes("application/xml")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] AddCoverageResource addCoverageResource)
        {
            try
            {
                // TODO: Ya ya, I know. More sophisticated usage of AutoMapper
                var command = new AddBuildCommand.Input(
                    addCoverageResource.ProductName,
                    addCoverageResource.BranchName,
                    addCoverageResource.Buildnumber,
                    _mapper.Map<Coverage>(addCoverageResource.Coverage)
                );
                var build = await _mediator.Send(command);
                return Ok(build);
            }
            catch (Exception ex)
            {
                // TODO: Logging
                return BadRequest();
            }
        }
    }
}