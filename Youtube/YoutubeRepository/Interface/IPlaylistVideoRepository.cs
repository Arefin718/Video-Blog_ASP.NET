using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeEntity.Class;

namespace YoutubeRepository.Interface
{
    public interface IPlaylistVideoRepository : IRepository<PlaylistVideo>
    {
        bool SongExistOrNot(PlaylistVideo plistVideo);
        List<PlaylistVideo> PlaylistSongs(int id);
        PlaylistVideo GetSongByVideoId(int id);
        PlaylistVideo GetPlaylistVideoWithDetails(int id);
    }
}
