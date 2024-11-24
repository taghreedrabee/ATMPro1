using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMapp
{
    internal class UserRepository : IUserRepository
    {
        private List<IUser> _users = new List<IUser>();

        public void AddUser(IUser user)
        {
            _users.Add(user);
        }

        public IUser GetUserByUsername(string username)
        {
            return _users.FirstOrDefault(u => u.Username == username);
        }

        public IUser GetUserById(Guid userId)
        {
            return _users.FirstOrDefault(u => u.UserId == userId);
        }

        public void UpdateUser(IUser user)
        {
            int index = _users.FindIndex(u => u.UserId == user.UserId);
            if (index != -1)
            {
                _users[index] = user;
            }
        }

        public bool UserExists(string username)
        {
            return _users.Any(u => u.Username == username);
        }

        public bool DeleteUser(string username, string password)
        {
            int initialCount = _users.Count;
            _users.RemoveAll(u => u.Username == username && u.Password == password);
            return _users.Count < initialCount;
        }
    }
}
