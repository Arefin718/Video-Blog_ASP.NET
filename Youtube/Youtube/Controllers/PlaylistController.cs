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
    public class PlaylistController : Controller
    {
        IPlaylistService playlistService;

        public PlaylistController()
        {
            this.playlistService = Injector.Container.Resolve<IPlaylistService>();
        }

        [HttpGet]
        public ActionResult MyPlaylist()
        {
            int UserId = Convert.ToInt32(Session["UserId"]);
            return View(playlistService.GetPlaylistByUserId(UserId));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Playlist playlist)
        {
            playlist.UserId = Convert.ToInt32(Session["UserId"]);
            playlistService.Insert(playlist);
            return RedirectToAction("MyPlaylist", "Playlist", new { id = playlist.UserId });
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(playlistService.Get(id));
        }


        [HttpPost]
        public ActionResult Edit(Playlist playlist)
        {
            playlistService.Update(playlist);
            return RedirectToAction("MyPlaylist", "Playlist", new { id = playlist.UserId });
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(playlistService.Get(id));
        }

        [HttpPost,ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            playlistService.Delete(id);
            return RedirectToAction("MyPlaylist", "Playlist", new { id = Convert.ToInt32(Session["UserId"]) });
        }



        [HttpGet]
        public JsonResult GetPlaylistByUserId(int id)
        {
            return Json(playlistService.GetPlaylistByUserId(id),JsonRequestBehavior.AllowGet);
        }

    }
}