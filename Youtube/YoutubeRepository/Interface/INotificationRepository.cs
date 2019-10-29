using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeEntity.Class;

namespace YoutubeRepository.Interface
{
    public interface INotificationRepository :  IRepository<Notification>
    {
        List<Notification> GetNotificationsByReportedToId(int id);
        List<Notification> GetNotificationsByUser(int id);
        List<Notification> GetNewNotificationsByUser(int id);
    }
}
