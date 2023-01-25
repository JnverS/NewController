using Test.Interfaces;
using Test.Models;

namespace Test.Repository
{
    public class UsersRepository : IUser
    {
        private readonly UserContext _userContext;

        public UsersRepository(UserContext appContext)
        {
            _userContext = appContext;
        }

        public IEnumerable<User> AllUsers => _userContext.Users.ToList();

        public User? getObjUser(int userid)
        {
            var result = _userContext.Users.FirstOrDefault(p => p.Id == userid);
            return result;
        }

        public void AddUser(User user)
        {
            _userContext.Users.Add(user);
            _userContext.SaveChanges();
        }
    }
}
