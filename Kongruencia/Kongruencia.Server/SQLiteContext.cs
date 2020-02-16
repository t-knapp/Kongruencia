using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Kongruencia.Server {

    public class SQLiteContext : DbContext {

        //public DbSet<ClientDevice> ClientDevices { get; set; }
        //public DbSet<Licence> Licences { get; set; }

        protected override void OnConfiguring( DbContextOptionsBuilder options )
            => options.UseSqlite( "Data Source=Kongruencia.db" );
    }
}
