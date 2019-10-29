using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeEntity.Class;

namespace YoutubeRepository.Interface
{
    public interface IChannelRepository :  IRepository<Channel>
    {
        List<Channel> GetChannelByUserId(int id);
        void ChangeChannelStatus(int id);

    }
}
