using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeEntity.Class;

namespace YoutubeService.Interface
{
    public interface IPlaylistService : IService<Playlist>
    {
        List<Playlist> GetPlaylistByUserId(int id);
    }
}
