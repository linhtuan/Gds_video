using System.Data.Entity;
using Gds.BusinessObject.TableModel;

namespace Gds.BusinessObject.DbContext
{
    public class DbContextBase : System.Data.Entity.DbContext
    {
        public DbContextBase()
            : base("name=DefaultConnection")
        {
        }

        public DbSet<Categorys> Categoryses { get; set; }

        public DbSet<CategoryDetails> CategoryDetails { get; set; }

        public DbSet<CategoryTypePrice> CategoryTypePrice { get; set; }

        public DbSet<CategoryTypes> CategoryTypes { get; set; }

        public DbSet<CategoryTypeGroup> CategoryTypeGroups { get; set; }

        public DbSet<PhysicalFiles> PhysicalFiles { get; set; }

        public DbSet<Author> Author { get; set; }

        public DbSet<CategoryByUser> CategoryByUser { get; set; }

        public DbSet<CategoryRating> CategoryRating { get; set; }

        public DbSet<Comment> CommentByUser { get; set; }

        public DbSet<PaymentLog> PaymentLog { get; set; }

        public DbSet<Role> Role { get; set; }

        public DbSet<UserManagement> UserManagement { get; set; }

        public DbSet<AgeOrder> AgeOrders { get; set; }

        public DbSet<FeedbackComment> FeedbackComments { get; set; }

    }
}
