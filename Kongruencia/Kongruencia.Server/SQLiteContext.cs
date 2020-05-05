using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Kongruencia.Server {

    public class SQLiteContext : DbContext {

        //public DbSet<Product> Products { get; set; }
        //public DbSet<Branch> Branches { get; set; }
        //public DbSet<Build> Builds { get; set; }
        public DbSet<Coverage> Coverages { get; set; }
        
        public SQLiteContext(DbContextOptions<SQLiteContext> options)
            : base(options) { }
    }
}
