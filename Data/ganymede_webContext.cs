using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ganymede_web.Models;

namespace ganymede_web.Data
{
    public class ganymede_webContext : DbContext
    {
        public ganymede_webContext (DbContextOptions<ganymede_webContext> options)
            : base(options)
        {
        }

        public DbSet<ganymede_web.Models.Horaire> Horaire { get; set; } = default!;
        public DbSet<ganymede_web.Models.Benevole> Benevole { get; set; } = default!;
        public DbSet<ganymede_web.Models.Itineraire> Itineraire { get; set; } = default!;
    }
}
