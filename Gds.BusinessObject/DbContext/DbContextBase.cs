using System.Data.Entity;
using Gds.BusinessObject.TableModel;

namespace Gds.BusinessObject.DbContext
{
    public class DbContextBase : System.Data.Entity.DbContext
    {
        public DbContextBase()
            : base("name=DefaultConnection")
        {
            //Configuration.AutoDetectChangesEnabled = false;
            //Configuration.ValidateOnSaveEnabled = false;
        }

        public DbSet<Categorys> Categoryses { get; set; }
        public DbSet<CategoryDetails> CategoryDetails { get; set; }
        public DbSet<CategoryTypePrice> CategoryTypePrice { get; set; }
        public DbSet<CategoryTypes> CategoryTypes { get; set; }
        public DbSet<PhysicalFiles> PhysicalFiles { get; set; }
    }
}
