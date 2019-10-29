using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Youtube.App_Start;
using YoutubeEntity.Class;
using YoutubeService.Interface;

namespace Youtube.Controllers
{
    public class UserController : Controller
    {
        IUserService userService;

        public UserController()
        {
            this.userService = Injector.Container.Resolve<IUserService>();
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(User user)
        {
            userService.Insert(user);
            return RedirectToAction("Registration", "User");
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User loginInfo)
        {
            User user = userService.Login(loginInfo);

            if (user != null)
            {
                Session["UserId"] = user.Id;
                Session["UserName"] = user.Name;
                Session["UserEmail"] = user.Email;
                Session["UserAddress"] = user.Address;
                Session["UserPassword"] = user.Password;
                Session["UserImage"] = user.Image;
                return RedirectToAction("index", "Home");
            }
            else
            {
                TempData["ErrorMessage"] = "Invalid Email or Password";
                return RedirectToAction("login", "User");
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("index", "home");
        }

    }
}