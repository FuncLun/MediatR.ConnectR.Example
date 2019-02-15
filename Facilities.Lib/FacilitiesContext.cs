using System;
using Microsoft.EntityFrameworkCore;

namespace Facilities
{
    public class FacilitiesContext : DbContext
    {
        public FacilitiesContext()
        { }

        public FacilitiesContext(DbContextOptions<FacilitiesContext> options)
            : base(options)
        { }

        public virtual DbSet<Building> Buildings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                throw new Exception($"Options not configured for {nameof(FacilitiesContext)}");
            }
        }
    }
}