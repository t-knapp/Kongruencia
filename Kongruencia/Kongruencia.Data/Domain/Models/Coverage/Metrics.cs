using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kongruencia.Data.Domain.Models
{
    [Owned]
    public class Metrics {
        public int statements { get; set; }
        public int coveredstatements { get; set; }
        public int conditionals { get; set; }
        public int coveredconditionals { get; set; }
        public int methods { get; set; }
        public int coveredmethods { get; set; }
    }
}
