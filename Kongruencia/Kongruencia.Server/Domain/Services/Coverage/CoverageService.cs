using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Server.Domain.Models;
using Server.Domain.Parsers;

namespace Server.Domain.Services.Coverage
{
    public class CoverageService : ICoverageService
    {
        public Task<ServiceResult<bool>> AddAsync(Models.Coverage coverage)
        {
            // TODO: Move file to target folder
            // TODO: Parse
            // TODO: Write to DB
            var coverageXml = new XmlDocument();
            coverageXml.Load(coverage.FilePath);

            // TODO: @PE: Idea for better parsing?
            var overallMetricsNode = coverageXml.SelectSingleNode("coverage/project/metrics");
            var statementsRaw = overallMetricsNode.Attributes["statements"].Value;
            var coveredStatementsRaw = overallMetricsNode.Attributes["coveredstatements"].Value;

            int statements;
            if (int.TryParse(statementsRaw, out statements))
                coverage.Statements = statements;
            int coveredStatements;
            if (int.TryParse(coveredStatementsRaw, out coveredStatements))
                coverage.CoveredStatements = coveredStatements;

            return Task.FromResult(new ServiceResult<bool>(true));
        }
    }
}
