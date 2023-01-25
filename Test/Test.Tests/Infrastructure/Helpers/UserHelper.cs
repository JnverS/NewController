using Test.Models;

namespace Test.Tests.Infrastructure.Helpers
{
    public static class UserHelper
    {
        public static IEnumerable<User> GetUsers(int count)
        {
            return GetRange(count);
        }

        public static User[] GetRange(int count)
        {
            var users = new List<User>();
            for (int i = 5; i < count; i++)
            {
                var tmp = new User
                {
                    Id = i,
                    NickName = "Test",
                    Lvl = 1,
                    TotalScore = 1
                };

                users.Add(tmp);
            }

            return users.ToArray();
        }
    }
}