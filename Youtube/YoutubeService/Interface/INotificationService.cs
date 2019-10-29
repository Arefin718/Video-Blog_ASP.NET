using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeEntity.Class;

namespace YoutubeService.Interface
{
    public interface INotificationService : IService<Notification>
    {
        List<Notification> GetNotificationsByReportedToId(int id);
        List<Notification> GetNotificationsByUser(int id);
        List<Notification> getNewNotificationByUser(int id);
        //getNewNotificationByUser
    }
}
