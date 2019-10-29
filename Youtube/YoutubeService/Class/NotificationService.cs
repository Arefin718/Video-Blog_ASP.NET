using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeEntity.Class;
using YoutubeRepository.Class;
using YoutubeService.Interface;

namespace YoutubeService.Class
{
    public class NotificationService : Service<Notification>, INotificationService
    {
        NotificationRepository notiRepo = new NotificationRepository();
        public List<Notification> GetNotificationsByReportedToId(int id)
        {
            return notiRepo.GetNotificationsByReportedToId(id);
        }

        public List<Notification> GetNotificationsByUser(int id)
        {
            return notiRepo.GetNotificationsByUser(id);
        }
       

        public List<Notification> getNewNotificationByUser(int id)
        {
            return notiRepo.GetNewNotificationsByUser(id);
        }
    }
}
