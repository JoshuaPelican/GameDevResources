using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GameDevResources.Models;

namespace GameDevResources.Data
{
    public class GameDevResourcesContext : DbContext
    {
        public GameDevResourcesContext (DbContextOptions<GameDevResourcesContext> options)
            : base(options)
        {
        }

        public DbSet<GameDevResources.Models.Resource> Resource { get; set; } = default!;
    }
}
