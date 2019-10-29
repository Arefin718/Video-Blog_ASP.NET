using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeEntity.Class;

namespace YoutubeRepository.Interface
{
    public interface IPlaylistRepository :   IRepository<Playlist>
    {
        List<Playlist> GetPlaylistByUserId(int id);
    }
}
