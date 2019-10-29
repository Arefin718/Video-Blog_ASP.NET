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
    public class NotificationController : Controller
    {
        INotificationService notificationService;

        public NotificationController()
        {
            this.notificationService = Injector.Container.Resolve<INotificationService>();
        }

        public void Insert(Notification notification)
        {
            notification.Status = 1;
            notification.Time = DateTime.Now.ToString();
            notificationService.Insert(notification);
        }

        public void Update(int id)
        {
            List<Notification> notification = notificationService.GetNotificationsByUser(id).ToList();
            foreach(var notifi in notification)
            {
                notifi.Status = 0;
                notificationService.Update(notifi);
            }
        }

        public JsonResult GetNotificationsByReportedToId(int id)
        {
            return Json(notificationService.GetNotificationsByReportedToId(id),JsonRequestBehavior.AllowGet);
        }

        public JsonResult getNotificationByUser(int id)
        {
            return Json(notificationService.GetNotificationsByUser(id), JsonRequestBehavior.AllowGet);
        }
        //getNewNotificationByUser
        public JsonResult getNewNotificationByUser(int id)
        {
            return Json(notificationService.getNewNotificationByUser(id), JsonRequestBehavior.AllowGet);
        }
    }
}