using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminarz.Model
{
    class AppDbContext : DbContext
    {
        public DbSet<Event>? Events { get; set; }
    }
}
