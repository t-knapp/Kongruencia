using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kongruencia.Server {

    public class CoverageResource
    {
        public string ProductName { get; set; }
        public string BranchName { get; set; }
        public int BuildNumber { get; set; }


        public CoverageResource(string productName, string branchName, int buildNumber) =>
            (ProductName, BranchName, BuildNumber) = (productName, branchName, buildNumber);

        // TODO: Coverage Values queried from DB.s
    }
}
