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
    public class PlaylistService : Service<Playlist>, IPlaylistService
    {
        PlaylistRepository playRepo = new PlaylistRepository();
        public List<Playlist> GetPlaylistByUserId(int id)
        {
            return playRepo.GetPlaylistByUserId(id);
        }
    }
}
