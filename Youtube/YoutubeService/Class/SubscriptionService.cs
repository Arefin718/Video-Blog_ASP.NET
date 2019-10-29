using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeEntity.Class;
using YoutubeService.Interface;
using YoutubeRepository.Class;

namespace YoutubeService.Class
{
    public class SubscriptionService : Service<Subscription>, ISubscriptionService
    {
        SubscriptionRepository subRepo = new SubscriptionRepository();

        public List<Subscription> SubcriptionByChannelId(int id)
        {
            return subRepo.SubcriptionByChannelId(id);
        }

        public List<Subscription> SubcriptionBySubscriberId(int id)
        {
            return subRepo.SubcriptionBySubscriberId(id);
        }

        public int TotalSubscriberByChannelId(int id)
        {
            return subRepo.TotalSubscriberByChannelId(id);
        }

        public void Unsubscribe(Subscription sub)
        {
            subRepo.Unsubscribe(sub);
        }

        public bool UserSubscriptionStatus(Subscription sub)
        {
            return subRepo.UserSubscriptionStatus(sub);
        }
    }
}
