using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Youtube.App_Start;
using YoutubeService.Interface;

namespace Youtube.Controllers
{
    public class HomeController : Controller
    {
        IVideoService videoService;
        IPlaylistService playlistService;

        public HomeController()
        {
            this.videoService = Injector.Container.Resolve<IVideoService>();
            this.playlistService = Injector.Container.Resolve<IPlaylistService>();
        }

        public ActionResult Index()
        {
            if (Session["UserId"] != null)
            {
                ViewData["Playlist"] = playlistService.GetPlaylistByUserId(Convert.ToInt32(Session["UserId"]));
            }

            return View(videoService.GetAllWithDetails());
        }


    }
}