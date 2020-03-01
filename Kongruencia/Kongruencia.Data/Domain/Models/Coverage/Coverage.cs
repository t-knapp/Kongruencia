﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kongruencia.Data.Domain.Models 
{
    public class Coverage
    {
        public int Id { get; private set; } 
        public DateTime Timestamp { get; private set; }
        public Metrics Metrics { get; private set; }
        public string ProductName { get; private set; }
        public string BranchName { get; private set; }
        public int BuildNumber { get; private set; }
    }
}
