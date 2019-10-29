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
    public class PlaylistVideoService : Service<PlaylistVideo>, IPlaylistVideoService
    {
        PlaylistVideoRepository playRepo = new PlaylistVideoRepository();

        public PlaylistVideo GetPlaylistVideoWithDetails(int id)
        {
            return playRepo.GetPlaylistVideoWithDetails(id);
        }

        public PlaylistVideo GetSongByVideoId(int id)
        {
            return playRepo.GetSongByVideoId(id);
        }

        public List<PlaylistVideo> PlaylistSongs(int id)
        {
            return playRepo.PlaylistSongs(id);
        }

        public bool SongExistOrNot(PlaylistVideo plistVideo)
        {
            return playRepo.SongExistOrNot(plistVideo);
        }
    }
}
