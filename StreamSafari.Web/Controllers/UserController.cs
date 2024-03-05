using StreamSafari.Service;
using StreamSafari.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace StreamSafari.Web.Controllers
{
    public class UserController : Controller
    {
        UserService userService = new UserService();

        public ActionResult List()
        {
            return View();
        }

        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUser(UserViewModel p_userViewModel)
        {
            UserViewModel userViewModel = userService.GetUser(p_userViewModel);
            if(userViewModel.UserId == 0)
            {
                userViewModel = userService.CreateUser(p_userViewModel);
                if (userViewModel.UserId != 0)
                {
                    List<UserViewModel> userViewModels = userService.ListUsers();
                    return View("UserCreated", userViewModels);
                }
                else
                {
                    //Unable to create user <Please implement later>
                }
            }
            else
            {
                if (p_userViewModel.UserName == userViewModel.UserName)
                {

                    ViewBag.IsUserNameAvailable = true;
                }
            }

           
            return View();
        }

        public ActionResult EditUser(int id)
        {

          
            UserViewModel userViewModel = new UserViewModel();

            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                userViewModel = userService.FindUser(id);

            }
            return View(userViewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( UserViewModel p_userViewModel)
        {
            if (ModelState.IsValid)
            {
                UserViewModel userViewModel = userService.EditUser(p_userViewModel);
                List<UserViewModel> userViewModels = userService.ListUsers();
                return View("UserCreated", userViewModels);
            }
              
            return View("EditUser");
        }

       
        public ActionResult Delete(int? id)
        {
            UserViewModel userViewModel = new UserViewModel();

            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                userViewModel = userService.FindUser(id);

            }
            return View(userViewModel);
           
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(UserViewModel p_userViewModel)
        {
         
               userService.DeleteUser(p_userViewModel);

            List<UserViewModel> userViewModels = userService.ListUsers();
            return View("UserCreated", userViewModels);


        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserViewModel p_userViewModel)
           
        {
            if (ModelState.IsValid)
            {
                UserViewModel isUserValidate = userService.LoginUserValid(p_userViewModel);
                if (isUserValidate != null)
                {
                    return View("LoginDetails", p_userViewModel);
                }
                else
                {

                    ViewBag.IsUserNotCreated = true;
                    return View("Login");
                }
            }
           

            return View(p_userViewModel);
           

        }

    }
}