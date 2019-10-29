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
    public class APIController : Controller
    {
        IAPIKeyService apiService;

        public APIController()
        {
            this.apiService = Injector.Container.Resolve<IAPIKeyService>();
        }

        //public ActionResult Index()
        //{
        //    ViewData["ClientId"] = apiService.GenerateClientId(Convert.ToInt32(Session["UserId"]));
        //    return View();
        //}

        public ActionResult Login(string id)
        {
            ViewData["RedirectURL"]=apiService.GetRedirectURLByClientId(id);
            ViewData["ClientId"] = id;
            return View();
        }


        public ActionResult MyKeys()
        {
            return View(apiService.GetKeysByUserId(Convert.ToInt32(Session["UserId"])));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(APIKey apikey)
        {
            DateTime d1 = new DateTime(1970, 1, 1);
            DateTime d2 = DateTime.Now;
            TimeSpan ts = new TimeSpan(d2.Ticks - d1.Ticks);
            int sTimeStamp = Convert.ToInt32(ts.TotalSeconds);


            string hash;

            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                hash = String.Concat(md5.ComputeHash(BitConverter
                  .GetBytes(sTimeStamp))
                  .Select(x => x.ToString("x2")));
            }


            apikey.UserId = Convert.ToInt32(Session["UserId"]);
            apikey.ClientId = hash;



            apiService.Insert(apikey);

            return RedirectToAction("MyKeys", "API");
        }


    }
}