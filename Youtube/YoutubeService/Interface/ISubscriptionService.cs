using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeEntity.Class;

namespace YoutubeService.Interface
{
    
    public interface ISubscriptionService : IService<Subscription>
    {
        bool UserSubscriptionStatus(Subscription sub);

        void Unsubscribe(Subscription sub);

        List<Subscription> SubcriptionBySubscriberId(int id);

        int TotalSubscriberByChannelId(int id);

        List<Subscription> SubcriptionByChannelId(int id);
    }
}
