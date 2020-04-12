using ProjectManagement.Data.Tools;
using Microsoft.EntityFrameworkCore;

namespace ProjectManagement.Data.Contexts
{
    public class DesignTimeProjectManagementContext : ProjectManagementContext
    {
        //HACK: this class was added to enable design-time database creation and filling
        //in Package Manager Console run: 'Update-Database -Context DesignTimeProjectManagementContext
        public DesignTimeProjectManagementContext() : this(new DbContextOptionsBuilder<ProjectManagementContext>()
                .UseSqlServer(@"Data Source=.;Initial Catalog=projects;Integrated Security=true;")
                .Options) { }

        public DesignTimeProjectManagementContext(DbContextOptions<ProjectManagementContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Seed();
        }
    }
}
