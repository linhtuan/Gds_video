namespace Gds.BusinessObject.DbContext
{
    public interface IDbContextFactory
    {
        DbContextBase GetContext<T>();
    }

    public class DbContextFactory : IDbContextFactory
    {

        public DbContextBase GetContext<T>()
        {
            var dbContext = new DbContextBase();
            return dbContext;
        }
    }
}
