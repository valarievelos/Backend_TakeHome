using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatingEngine.Data.Models
{
    public class RatingEngineContext : DbContext
    {
        public RatingEngineContext(DbContextOptions<RatingEngineContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Define composite key.
            builder.Entity<JsonInputs>()
                .HasKey(x => new { x.Id });
        }

        public DbSet<JsonInputs> Inputs { get; set; }

    }
}