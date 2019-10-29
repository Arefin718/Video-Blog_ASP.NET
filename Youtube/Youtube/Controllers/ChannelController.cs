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
    public class ChannelController : Controller
    {
        IChannelService channelService;

        public ChannelController()
        {
            this.channelService = Injector.Container.Resolve<IChannelService>();
        }


        //public JsonResult jMyChannel()
        //{
        //    return Json(channelService.GetChannelByUserId(Convert.ToInt32(Session["UserId"])), JsonRequestBehavior.AllowGet);
        //}

        public ActionResult MyChannel(int id=-5)
        {
            if (id == -5)
            {
                id = Convert.ToInt32(Session["UserId"]);
            }

            return View(channelService.GetChannelByUserId(id));
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Channel channel, HttpPostedFileBase ChannelImage)
        {


            String sExt = Path.GetExtension(ChannelImage.FileName).ToLower();
            String channelImage = "/Content/Uploads/images/Channel/" + ChannelImage.FileName.Replace(sExt, "") + sExt + DateTime.Now.ToString("ddMMMyyhhmmsstt") + sExt;
            var fileName = Path.GetFileName(ChannelImage.FileName);
            var path = Path.Combine(Server.MapPath("~/Content/Uploads/images/Channel"), fileName);
            ChannelImage.SaveAs(path + DateTime.Now.ToString("ddMMMyyhhmmsstt") + sExt);


            channel.Status = 1;
            channel.ChannelImage = channelImage;
            channel.UserId = Convert.ToInt32(Session["UserId"]);
            channelService.Insert(channel);
            return RedirectToAction("mychannel", "channel");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(channelService.Get(id));
        }




        [HttpPost]
        public ActionResult Edit(Channel channel)
        {
            channelService.Update(channel);
            return RedirectToAction("mychannel", "channel");
        }


        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(channelService.Get(id));
        }



        [HttpGet]
        public ActionResult Deactive(int id)
        {
            return View(channelService.Get(id));
        }



        [HttpPost]
        public ActionResult Deactive(Channel channel)
        {
            Channel toBeUpdated = channelService.Get(channel.Id);
            toBeUpdated.Status = 0;
            channelService.Update(toBeUpdated);
            return RedirectToAction("mychannel", "channel");
        }
    }
}