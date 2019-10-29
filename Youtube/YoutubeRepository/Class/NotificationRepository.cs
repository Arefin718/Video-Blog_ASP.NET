using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeEntity.Class;
using YoutubeRepository.Interface;

namespace YoutubeRepository.Class
{
    public class NotificationRepository : Repository<Notification>, INotificationRepository
    {
        DataContext context = new DataContext();

        public List<Notification> GetNotificationsByReportedToId(int id)
        {
           return context.Set<Notification>().Include("NotifiedByUser").Where(n => n.NotifiedTo == id && n.Type=="Subscription").ToList();
        }

        public List<Notification> GetNotificationsByUser(int id)
        {
            return context.Set<Notification>().Include("NotifiedByUser").Where(n => n.NotifiedTo == id && (n.Type == "comment" || n.Type=="reply") && n.NotifiedBy !=id).ToList();
        }

        public List<Notification> GetNewNotificationsByUser(int id)
        {
            return context.Set<Notification>().Include("NotifiedByUser").Where(n => n.NotifiedTo == id && (n.Type == "comment" || n.Type == "reply") && n.Status == 1 && n.NotifiedBy != id).ToList();
        }
    }
}
