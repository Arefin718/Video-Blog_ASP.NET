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
    public class PlaylistVideoController : Controller
    {

        IPlaylistVideoService playlistVideoService;
  
        public PlaylistVideoController()
        {
            this.playlistVideoService = Injector.Container.Resolve<IPlaylistVideoService>();
          
        }

        public JsonResult Insert(PlaylistVideo playVideo)
        {

            bool exist = playlistVideoService.SongExistOrNot(playVideo);

            if (exist == true)
            {
                return Json(exist, JsonRequestBehavior.AllowGet);
            }
            else
            {
            playlistVideoService.Insert(playVideo);

                return Json(exist, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult PlaylistSongs(int id)
        {
            return View(playlistVideoService.PlaylistSongs(id));
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(playlistVideoService.GetPlaylistVideoWithDetails(id));
        }


        [HttpPost,ActionName("Delete")]
        public ActionResult ConfirmDelete(int Id, int PlayListId)
        {
            playlistVideoService.Delete(Id);
            return RedirectToAction("PlaylistSongs", "PlaylistVideo", new { id = PlayListId });
        }

    }
}