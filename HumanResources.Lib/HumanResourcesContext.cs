using System;
using Microsoft.EntityFrameworkCore;

namespace HumanResources
{
    public class HumanResourcesContext : DbContext
    {
        public HumanResourcesContext()
        { }

        public HumanResourcesContext(DbContextOptions<HumanResourcesContext> options)
        : base(options)
        { }

        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                throw new Exception($"Options not configured for {nameof(HumanResourcesContext)}");
            }
        }
    }
}