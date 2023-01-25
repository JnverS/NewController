using Test.Models;

namespace Test.Interfaces
{
    public interface IUser
    {
        IEnumerable<User> AllUsers { get; }

        User? getObjUser(int userid);
        void AddUser(User user);
    }
}
