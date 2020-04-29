using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Kongruencia.Server
{
    public class BranchResource : IEquatable<BranchResource>
    {
        public string BranchName { get; set; }
        public string ProductName { get; set; }

        public bool Equals([AllowNull] BranchResource other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(this, other)) return true;
            return BranchName.Equals(other.BranchName) && ProductName.Equals(other.ProductName);
        }

        public override int GetHashCode()
        {
            int hashProduct = ProductName == null ? 0 : ProductName.GetHashCode();
            int hashBranch = BranchName == null ? 0 : BranchName.GetHashCode();
            return hashProduct ^ hashBranch;
        }
    }
}
