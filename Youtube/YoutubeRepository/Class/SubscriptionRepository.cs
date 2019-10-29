using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeEntity.Class;
using YoutubeRepository.Interface;

namespace YoutubeRepository.Class
{
    public class SubscriptionRepository : Repository<Subscription>, ISubscriptionRepository
    {
        DataContext datacontext = new DataContext();

        public List<Subscription> SubcriptionByChannelId(int id)
        {
            return datacontext.Subscriptions.Include("Subscriber").Include("Channel").Where(u => u.ChannelId == id).ToList();
        }

        public List<Subscription> SubcriptionBySubscriberId(int id)
        {
            return datacontext.Subscriptions.Include("Channel").Where(u => u.SubscriberId == id).ToList();
        }

        public int TotalSubscriberByChannelId(int id)
        {
            return datacontext.Subscriptions.Where(u => u.ChannelId == id).Count();
        }

        public void Unsubscribe(Subscription sub)
        {

            Subscription sb = datacontext.Subscriptions.SingleOrDefault(s => s.ChannelId == sub.ChannelId && s.SubscriberId == sub.SubscriberId);

            if (sb!=null){
                datacontext.Set<Subscription>().Remove(sb);
            }
            else
            {
                datacontext.Set<Subscription>().Add(sub);
            }

            datacontext.SaveChanges();

        }

        public bool UserSubscriptionStatus(Subscription sub)
        {
            bool valid = false;
            Subscription sb =  datacontext.Subscriptions.SingleOrDefault(s=> s.ChannelId == sub.ChannelId && s.SubscriberId == sub.SubscriberId);

            if (sb != null)
            {
                valid = true;
            }
            return valid;

        }
    }
}
