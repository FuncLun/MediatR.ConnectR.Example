using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HumanResources
{
    public class HumanResourcesContext : DbContext
    {
        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    //.UseSqlServer(@"Data Source=IN01N01079\SQLEXPRESS;Initial Catalog=myTestDB;User Id=testuser; Password=sa;")
                    .UseSqlite(@"Data Source=..\~$BlazorCrud.HumanResources.sqlite")
                    ;
            }
        }

        public static async Task EnsureDatabase(CancellationToken cancellationToken = default)
        {
            using (var context = new HumanResourcesContext())
            {
                await context.Database.EnsureCreatedAsync(cancellationToken);
            }
        }
    }
}