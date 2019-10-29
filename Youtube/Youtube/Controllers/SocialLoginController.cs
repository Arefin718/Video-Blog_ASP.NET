using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YoutubeService.Interface;
using Youtube.App_Start;
using YoutubeEntity.Class;

namespace FoodJournal.Controllers
{
    public class SocialLoginController : Controller
    {
        IUserService userService;


        public SocialLoginController()
        {
            this.userService = Injector.Container.Resolve<IUserService>();
            
        }
   

        public ActionResult GoogleLogin(User user)
        {
            this.userService.Insert(user);
            return RedirectToAction("login", "User");

        }
    }
}