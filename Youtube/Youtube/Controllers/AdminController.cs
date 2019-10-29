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
    public class AdminController : Controller
    {
        IAdminService adminService;

        public AdminController()
        {
            this.adminService = Injector.Container.Resolve<IAdminService>();
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(Admin admin)
        {
            adminService.Insert(admin);
            return RedirectToAction("login", "Admin");
        }


        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin loginInfo)
        {
            Admin admin = adminService.Login(loginInfo);

            if (admin != null)
            {
                Session["AdminId"] = admin.Id;
                Session["AdminName"] = admin.Name;
                Session["AdminEmail"] = admin.Email;
                Session["AdminAddress"] = admin.Address;
                Session["AdminPassword"] = admin.Password;
                Session["AdminImage"] = admin.Image;
                return RedirectToAction("index", "Admin");
            }
            else
            {
                TempData["ErrorMessage"] = "Invalid Email or Password";
                return RedirectToAction("login", "Admin");
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session["AdminId"] = null;
            Session["AdminName"] = null;
            Session["AdminEmail"] = null;
            Session["AdminAddress"] = null;
            Session["AdminPassword"] = null;
            Session["AdminImage"] = null;
            return RedirectToAction("Login", "Admin");
        }

        public ActionResult Alladmins()
        {
            return View(adminService.GetAll());
        }

        public ActionResult Edit(int id)
        {
            return View(adminService.Get(id));
        }
        [HttpPost]
        public ActionResult Edit(Admin admin)
        {
            Session["AdminName"] = admin.Name;

            Session["AdminEmail"] = admin.Email;
            Session["AdminAddress"] = admin.Address;

            adminService.Update(admin);
            return RedirectToAction("Index", "Admin");

        }

    }
}