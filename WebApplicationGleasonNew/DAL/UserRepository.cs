using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationGleasonNew.DAL.Interfaces;
using WebApplicationGleasonNew.Models;

namespace WebApplicationGleasonNew.DAL
{
    public class UserRepository : IUserRepository
    {

        private List<UserModel> _usersList = null;

        public UserRepository()
        {
            if(_usersList == null)
                _usersList = new List<UserModel>();
        }

        public void AddUser(UserModel user)
        {
            user.Id = _usersList.Count + 1;
            _usersList.Add(user);
        }

        public UserModel GetUser(int userId)
        {
            return _usersList.SingleOrDefault(user => user.Id == userId);
        }

        public List<UserModel> GetAllUsers()
        {
            return _usersList;
        }

        public bool CheckUserExists(string userName, string userPassword)
        {
            var user = _usersList.SingleOrDefault(user => user.UserName == userName && user.Password == userPassword);
            if(user != null)
                return true;
            return false;
        }

        public void DeleteUser(int userId)
        {
            var user = _usersList.SingleOrDefault(user => user.Id == userId);

            if (user != null)
                _usersList.Remove(user);
        }
    }
}
