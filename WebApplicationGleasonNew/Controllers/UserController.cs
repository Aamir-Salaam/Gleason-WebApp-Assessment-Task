using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationGleasonNew.DAL.Interfaces;
using WebApplicationGleasonNew.Models;

namespace WebApplicationGleasonNew.Controllers
{
    public class UserController : Controller
    {
        // GET: HomeController1
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [Route("")]
        [Route("User")]
        public ActionResult Index()
        {
            return View("CreateNewUser");
        }

        [Route("User/AllUsers")]
        public ActionResult AllUsers()
        {
            var users = _userRepository.GetAllUsers();

            return View("AllUsers", users);
        }

        // GET: HomeController1/Details/5
        [Route("User/UserDetails/{id:int}")]
        public ActionResult UserDetails(int id)
        {
            var user = _userRepository.GetUser(id);

            return View("UserDetails", user);
        }

        [HttpPost]
        public ActionResult CreateNewUser(UserModel newUser)
        {
            if (newUser != null)
            {
                if (!_userRepository.CheckUserExists(newUser.UserName, newUser.Password))
                {
                    _userRepository.AddUser(newUser);
                }
            }

            return RedirectToAction("UserDetails", "User", new { id = newUser.Id});
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Delete/5
        [Route("User/DeleteUser/{id:int}")]
        public ActionResult DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);

            return RedirectToAction("AllUsers", "User");
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
