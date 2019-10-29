using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Youtube.App_Start;
using YoutubeEntity.Class;
using YoutubeService.Interface;

namespace Youtube.Controllers
{
    public class VideoController : Controller
    {
        IVideoService videoService;
        ISubscriptionService subscriptionService;
        IChannelService channelService;
        ICommentService commentService;
        IPlaylistVideoService playlistVideoService;
        IReactService reactService;

        public VideoController()
        {
            this.videoService = Injector.Container.Resolve<IVideoService>();
            this.subscriptionService = Injector.Container.Resolve<ISubscriptionService>();
            this.channelService = Injector.Container.Resolve<IChannelService>();
            this.commentService = Injector.Container.Resolve<ICommentService>();
            this.playlistVideoService = Injector.Container.Resolve<IPlaylistVideoService>();
            this.reactService = Injector.Container.Resolve<IReactService>();
        }



        public ActionResult AllVideo(int id)
        {
            if (Session["UserId"] != null)
            {
                Subscription sub = new Subscription();
                sub.ChannelId = id;
                sub.SubscriberId = Convert.ToInt32(Session["UserId"]);

                TempData["SubscriptionStatus"] = subscriptionService.UserSubscriptionStatus(sub);
            }

            TempData["ChannelId"] = id;

            ViewData["Channel"] = channelService.Get(id);

            return View(videoService.GetVideoByChannelId(id));
        }


        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Video video, HttpPostedFileBase videoURL, HttpPostedFileBase Poster)
        {

            //fileUpload
            String sExt = Path.GetExtension(videoURL.FileName).ToLower();
            String videoPath = "/Content/Uploads/Videos/" + videoURL.FileName.Replace(sExt, "") + sExt + DateTime.Now.ToString("ddMMMyyhhmmsstt") + sExt;
            var fileName = Path.GetFileName(videoURL.FileName);
            var path = Path.Combine(Server.MapPath("~/Content/Uploads/Videos"), fileName);
            videoURL.SaveAs(path + DateTime.Now.ToString("ddMMMyyhhmmsstt") + sExt);

            //poster upload
            String sExtposter = Path.GetExtension(Poster.FileName).ToLower();
            String posterPath = "/Content/Uploads/images/Videoposter/" + Poster.FileName.Replace(sExtposter, "") + sExtposter + DateTime.Now.ToString("ddMMMyyhhmmsstt") + sExtposter;
            var posterName = Path.GetFileName(Poster.FileName);
            var pathposter = Path.Combine(Server.MapPath("~/Content/Uploads/images/Videoposter"), posterName);
            Poster.SaveAs(pathposter + DateTime.Now.ToString("ddMMMyyhhmmsstt") + sExtposter);


            video.UploadTime = Convert.ToString(DateTime.Now.ToString("MMMM dd, yyyy"));
            video.Status = 1;
            video.Poster = posterPath;
            video.VideoURL = videoPath;
            video.ViewCount = 0;
            video.Approve = 1;

            videoService.Insert(video);

            NotifyAllSubscribers(video.ChannelId,video);

            return RedirectToAction("AllVideo", "video", new { id = video.ChannelId });
        }

        private void NotifyAllSubscribers(int channelId,Video vdo)
        {

            List<Subscription> loSubscription = subscriptionService.SubcriptionByChannelId(channelId);


            foreach(var sub in loSubscription)
            {

                string username = sub.Subscriber.Name;
                string songName = vdo.Title;
                string channelName = sub.Channel.ChannelName;

                //generate random recovery code
                Random rnd = new Random();
                int recoverycode = rnd.Next(10000000, 99999999);

                MailMessage mm = new MailMessage("hdrbd1994@gmail.com", sub.Subscriber.Email.Trim());
                mm.Subject = "Password Recovery";
                mm.Body = string.Format("Hi {0},<br /><br />New song uploaded in {1}.<br /><br />" +
                    "Song Name: {2} <br /> Link: {3} <br /><br />Thank You.", username, channelName,songName,"/video/view/"+vdo.Id);
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential();
                NetworkCred.UserName = "hdrbd1994@gmail.com";
                NetworkCred.Password = "Born1994";
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);


            }




        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(videoService.Get(id));
        }


        [HttpPost]
        public ActionResult Edit(Video video)
        {
            video.Approve = 1;
            videoService.Update(video);
            return RedirectToAction("AllVideo", "Video", new { id = video.ChannelId });
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(videoService.Get(id));
        }


        [HttpPost]
        public ActionResult Delete(Video video)
        {
            Video vid = videoService.Get(video.Id);
            string tmp = Path.Combine(Server.MapPath(vid.Poster.ToString())).ToString();
            string tmp2 = Path.Combine(Server.MapPath(vid.VideoURL.ToString())).ToString();


            System.IO.File.Delete(tmp);
            System.IO.File.Delete(tmp2);
            videoService.Delete(video.Id);

            return RedirectToAction("AllVideo", "Video", new { id = video.ChannelId });
        }

        [HttpPost]
        public void Private(int id)
        {
            Video vid = videoService.Get(id);
            if (vid.Status == 0)
            {
                vid.Status = 1;
            }
            else
            {
                vid.Status = 0;
            }
            videoService.Update(vid);

        }



        [HttpGet]
        public ActionResult VideoByCategory(string id)
        {
            ViewData["Category"] = id;
            return View(videoService.GetVideoByCatagory(id));
        }

        [HttpGet]
        public ActionResult View(int id)
        {
            videoService.ViewCount(id);

            Video video = videoService.GetVideoWithDetails(id);


            ViewData["TotalSubscriber"] = subscriptionService.TotalSubscriberByChannelId(video.ChannelId);

            ViewData["CategoryVideo"] = videoService.GetVideoByCatagory(video.Type);

            ViewData["Comment"] = commentService.CommentByVideoId(id);


            if (Session["UserId"] != null)
            {
                Subscription sub = new Subscription();
                sub.ChannelId = video.ChannelId;
                sub.SubscriberId = Convert.ToInt32(Session["UserId"]);
                TempData["SubscriptionStatus"] = subscriptionService.UserSubscriptionStatus(sub);
                React rct = new React();

                    rct.UserId = Convert.ToInt32(Session["UserId"]);
                    rct.VideoId = id;
                
                TempData["ReactStatus"] = reactService.UserReactStatus(rct);
            }

            return View(video);
        }


        [HttpGet]
        public ActionResult Playlist(int id)
        {
            
            
            List<PlaylistVideo> plv = playlistVideoService.PlaylistSongs(id);

            List<Video> lov = new List<Video>();

            foreach(var item in plv)
            {
                Video vdo = new Video();
                vdo = videoService.GetVideoWithDetails(item.VideoId);
                lov.Add(vdo);
            }


            ViewData["CategoryVideo"] = lov;


            //List<PlaylistVideo> listOfPlayListVideo = ViewData["CategoryVideo"] as List<YoutubeEntity.Class.PlaylistVideo>;


            if (lov != null && plv!=null)
            {

                ViewData["PlaylistName"] = plv.FirstOrDefault().Playlist.Name;
                int videoId = lov.FirstOrDefault().Id;

                videoService.ViewCount(videoId);

                Video video = videoService.GetVideoWithDetails(videoId);

                ViewData["TotalSubscriber"] = subscriptionService.TotalSubscriberByChannelId(video.ChannelId);

                ViewData["Comment"] = commentService.CommentByVideoId(videoId);

                if (Session["UserId"] != null)
                {
                    Subscription sub = new Subscription();
                    sub.ChannelId = video.ChannelId;
                    sub.SubscriberId = Convert.ToInt32(Session["UserId"]);
                    TempData["SubscriptionStatus"] = subscriptionService.UserSubscriptionStatus(sub);
                }

                return View(video);
            }
            else
            {
                return null;
            }
        }



        [HttpGet]
        public JsonResult SearchByName(string term)
        {
            return Json(videoService.SearchByName(term), JsonRequestBehavior.AllowGet);
        }

        public ActionResult TrendingVideos()
        {
            return View(videoService.TrendingVideos());
        }
    }
}