using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Orchestrator.Data
{
    public class OrchestratorDbContext : DbContext
    {
        public OrchestratorDbContext(DbContextOptions<OrchestratorDbContext> options)
            : base(options) { }

        public DbSet<Models.Workflow> Workflows { get; set; }
    }
}
