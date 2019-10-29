using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeEntity.Class;
using YoutubeRepository.Interface;

namespace YoutubeRepository.Class
{
    public class ChannelRepository : Repository<Channel>, IChannelRepository
    {
        DataContext dataContext = new DataContext();
        Repository<Channel> channelRepo = new Repository<Channel>();
            
        public void ChangeChannelStatus(int id)
        {
            Channel channel = dataContext.Channels.SingleOrDefault(u => u.Id == id);

            if (channel.Status == 0)
            {
                channel.Status = 1;
            }
            else
            {
                channel.Status = 0;
            }

            channelRepo.Update(channel);
        }

        public List<Channel> GetChannelByUserId(int id)
        {
            return dataContext.Channels.AsNoTracking().Where(c => c.UserId == id && c.Status==1).ToList();
        }

    }
}
