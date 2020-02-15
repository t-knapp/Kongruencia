using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers.Coverages
{
    public class AddCoverageResource
    {
        public string ProductName { set; get; }
        public string BranchName { set; get; }
        public int BuildNumber { set; get; }
        public string FilePath { set; get; } // TODO: Hm. Not Clever?
        public AddCoverageResource(string productName, string branchName, int buildNumber) =>
            (ProductName, BranchName, BuildNumber) = (productName, branchName, buildNumber);

        public bool Valid =>
            !string.IsNullOrEmpty(ProductName) &&
            !string.IsNullOrWhiteSpace(ProductName) &&
            !string.IsNullOrEmpty(BranchName) &&
            !string.IsNullOrWhiteSpace(BranchName) &&
            BuildNumber >= 0;
    }
}
