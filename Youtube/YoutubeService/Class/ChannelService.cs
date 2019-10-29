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
    public class ChannelService : Service<Channel>, IChannelService
    {
        ChannelRepository channelRepo = new ChannelRepository();

        public void ChangeChannelStatus(int id)
        {
            channelRepo.ChangeChannelStatus(id);
        }

        public List<Channel> GetChannelByUserId(int id)
        {
            return channelRepo.GetChannelByUserId(id);
        }

     
    }
}
