using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationGleasonNew.Models;

namespace WebApplicationGleasonNew.DAL.Interfaces
{
    public interface IUserRepository
    {
        void AddUser(UserModel user);

        UserModel GetUser(int userId);

        List<UserModel> GetAllUsers();

        bool CheckUserExists(string userName, string userPassword);

        void DeleteUser(int userId);
    }
}
