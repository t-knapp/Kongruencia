using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Domain.Services.Coverage;
using Server.Domain.Services.FormFileStorage;

namespace Server.Controllers.Coverages
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoveragesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICoverageService _coverageService;
        private readonly IFormFileStorage _formFileStorage;

        public CoveragesController(IMapper mapper, ICoverageService coverageService, IFormFileStorage formFileStorage)
        {
            _mapper = mapper;
            _coverageService = coverageService;
            _formFileStorage = formFileStorage;
        }

        [HttpPost("{productName}/{branchName}/{buildNumber}")]
        public async Task<IActionResult> Post(string productName, string branchName, int buildNumber, IFormFile coverageFile)
        {
            var addResource = new AddCoverageResource(productName, branchName, buildNumber);
            if (Object.ReferenceEquals(coverageFile, null) || coverageFile.Length == 0 || !addResource.Valid)
                return BadRequest();

            var storageResult = await _formFileStorage.Save(coverageFile);
            if (!storageResult.isSuccess)
                return BadRequest();

            addResource.FilePath = storageResult.result;
            var coverage = _mapper.Map<Domain.Models.Coverage>(addResource);
            var addResult = await _coverageService.AddAsync(coverage);
            if (addResult.isSuccess)
                return Ok("Stored to: " + storageResult.result + "; " + coverage.CoveredStatements + "/" + coverage.Statements);

            return BadRequest();
        }
    }
}