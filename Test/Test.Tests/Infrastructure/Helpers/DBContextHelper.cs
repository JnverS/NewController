using Microsoft.EntityFrameworkCore;
using System;

namespace Test.Tests.Infrastructure.Helpers
{
    public class DBContextHelper
    {
        public UserContext Context { get; set; }
        public DBContextHelper() 
        {
            var builder = new DbContextOptionsBuilder<UserContext>();
                builder.UseInMemoryDatabase("1");
            var options = builder.Options;
            Context = new UserContext(options);
            Context.Database.EnsureDeleted();
            AddUsers(10);
           
        }
        public void AddUsers(int count)
        {
            Context.AddRange(UserHelper.GetUsers(count));
            Context.SaveChanges();
            foreach (var entity in Context.ChangeTracker.Entries())
            {
                entity.State = EntityState.Detached;
            }
        }
    }
}
