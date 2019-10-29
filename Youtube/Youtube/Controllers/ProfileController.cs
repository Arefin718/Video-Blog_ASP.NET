using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Youtube.App_Start;
using YoutubeEntity.Class;
using YoutubeService.Interface;

namespace Youtube.Controllers
{
    public class ProfileController : Controller
    {
        IUserService userService;

        public ProfileController()
        {
            this.userService = Injector.Container.Resolve<IUserService>();
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View(userService.Get(Convert.ToInt32(Session["UserId"])));
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            userService.Update(user);
            return RedirectToAction("index","Home");
        }

        [HttpGet]
        public ActionResult ChangeProfilePicture()
        {
            return View(userService.Get(Convert.ToInt32(Session["UserId"])));
        }

        [HttpPost]
        public ActionResult ChangeProfilePicture(User user, HttpPostedFileBase Image)
        {
            String sExtposter = Path.GetExtension(Image.FileName).ToLower();
            String posterPath = "/Content/Uploads/images/Videoposter/" + Image.FileName.Replace(sExtposter, "") + sExtposter + DateTime.Now.ToString("ddMMMyyhhmmsstt") + sExtposter;
            var posterName = Path.GetFileName(Image.FileName);
            var pathposter = Path.Combine(Server.MapPath("~/Content/Uploads/images/Videoposter"), posterName);
            Image.SaveAs(pathposter + DateTime.Now.ToString("ddMMMyyhhmmsstt") + sExtposter);

            user.Image = posterPath;
            userService.Update(user);

            Session["UserImage"] = posterPath;

            return RedirectToAction("index", "Home");
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View(userService.Get(Convert.ToInt32(Session["UserId"])));
        }
        [HttpPost]
        public ActionResult ChangePassword(User user)
        {
            User u = userService.Get(Convert.ToInt32(Session["UserId"]));
            u.Password = user.Password;
            userService.Update(u);
            return RedirectToAction("index", "Home");
        }


    }
}