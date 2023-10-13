using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StickWizards.Models;

namespace StickWizards.Data
{
    public class StickWizardsContext : DbContext
    {
        public StickWizardsContext(DbContextOptions<StickWizardsContext> options)
            : base(options)
        {
        }

        public DbSet<Stick> Stick { get; set; }
    }
}
