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
    public class SubscriptionController : Controller
    {
        ISubscriptionService subscriptionService;
        IChannelService channelService;

        public SubscriptionController()
        {
            this.subscriptionService = Injector.Container.Resolve<ISubscriptionService>();
            this.channelService = Injector.Container.Resolve<IChannelService>();
        }
        public void Subscribe(int id)
        {
            Subscription sub = new Subscription();
            sub.ChannelId = id;
            sub.SubscriberId = Convert.ToInt32(Session["UserId"]);

            subscriptionService.Insert(sub);
        }


        public void Unsubscribe(int id)
        {
            Subscription sub = new Subscription();
            sub.ChannelId = id;
            sub.SubscriberId = Convert.ToInt32(Session["UserId"]);
            subscriptionService.Unsubscribe(sub);
        }

        [HttpGet]
        public ActionResult MySubscriptions()
        {    
            return View(subscriptionService.SubcriptionBySubscriberId(Convert.ToInt32(Session["UserId"])));
        }

    }
}