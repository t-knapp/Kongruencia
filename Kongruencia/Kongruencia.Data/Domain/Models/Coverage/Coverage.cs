using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kongruencia.Data.Domain.Models 
{
    public class Coverage
    {
        public int Id { get; set; } 
        public DateTime Timestamp { get; set; }
        public Metrics Metrics { get; set; }
        public string ProductName { get; set; }
        public string BranchName { get; set; }
        public int BuildNumber { get; set; }
    }
}
