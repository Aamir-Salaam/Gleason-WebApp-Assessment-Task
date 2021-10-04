using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationGleasonNew.DAL.Interfaces;
using WebApplicationGleasonNew.Models;

namespace WebApplicationGleasonNew.Controllers
{
    public class LoginController : Controller
    {
        private IUserRepository _userRepository;
        public LoginController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [Route("Login")]
        public IActionResult Index()
        {
            return View("Login");
        }
        
        [Route("Login/CheckUser")]
        public IActionResult CheckUser(UserModel user)
        {
            string userName = user.UserName;
            string userPassword = user.Password;

            if (_userRepository.CheckUserExists(userName, userPassword))
            {
                return RedirectToAction("AllUsers", "User");
            }
            else
            {
                return View("Shared/Error");
            }
        }
    }
}
