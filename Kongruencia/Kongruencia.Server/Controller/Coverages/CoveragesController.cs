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

        public CoveragesController(IMediator mediator)
            => (_mediator) = (mediator);

        [HttpPost]
        [Consumes("application/xml")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] AddCoverageResource addCoverageResource)
        {
            try
            {
                var command = new UploadCoverageCommand.Input(
                    addCoverageResource.ProductName,
                    addCoverageResource.BranchName,
                    addCoverageResource.Buildnumber,
                    addCoverageResource.Coverage
                );
                var build = await _mediator.Send(command);
                return Ok(build);
            }
            catch (Exception ex)
            {
                // TODO: Logging
                return BadRequest(ex.Message);
            }
        }
    }
}