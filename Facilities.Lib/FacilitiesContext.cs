using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Facilities
{
    public class FacilitiesContext : DbContext
    {
        public virtual DbSet<Building> Buildings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    //.UseSqlServer(@"Data Source=IN01N01079\SQLEXPRESS;Initial Catalog=myTestDB;User Id=testuser; Password=sa;")
                    .UseSqlite(@"Data Source=..\~$BlazorCrud.Facilities.sqlite")
                    ;
            }
        }

        public static async Task EnsureDatabase(CancellationToken cancellationToken = default)
        {
            using (var context = new FacilitiesContext())
            {
                await context.Database.EnsureCreatedAsync(cancellationToken);
            }
        }
    }
}