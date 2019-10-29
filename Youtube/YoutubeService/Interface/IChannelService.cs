using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeEntity.Class;

namespace YoutubeService.Interface
{
    public interface IChannelService : IService<Channel>
    {
        List<Channel> GetChannelByUserId(int id);
        void ChangeChannelStatus(int id);

    }
}
