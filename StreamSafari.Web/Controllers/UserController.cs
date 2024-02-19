using StreamSafari.Service;
using StreamSafari.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace StreamSafari.Web.Controllers
{
    public class UserController : Controller
    {
         UserService userService = new UserService();
        
        public ActionResult Index()
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
          
            UserViewModel userViewModel = userService.CreateUser(p_userViewModel);
            if(userViewModel.UserId != 0)
            {

                return View("UserCreated",userViewModel);
            }

            return View();
        }
    }
}