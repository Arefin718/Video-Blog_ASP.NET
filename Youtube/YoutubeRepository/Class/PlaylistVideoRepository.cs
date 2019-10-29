using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeEntity.Class;
using YoutubeRepository.Interface;

namespace YoutubeRepository.Class
{
    public class PlaylistVideoRepository : Repository<PlaylistVideo>, IPlaylistVideoRepository
    {
        DataContext context = new DataContext();

        public PlaylistVideo GetPlaylistVideoWithDetails(int id)
        {
            return context.PlaylistVideos.Include("Video").SingleOrDefault(p => p.Id == id);
        }

        public PlaylistVideo GetSongByVideoId(int id)
        {
            return context.PlaylistVideos.SingleOrDefault(pv=>pv.VideoId==id);
        }

        public List<PlaylistVideo> PlaylistSongs(int id)
        {
            return context.PlaylistVideos.Include("Playlist").Include("Video").Where(pv => pv.PlayListId == id).ToList();
        }

        public bool SongExistOrNot(PlaylistVideo plistVideo)
        {
            bool exist = false;
            PlaylistVideo pvdo = context.PlaylistVideos.SingleOrDefault(p => p.PlayListId == plistVideo.PlayListId && p.VideoId == plistVideo.VideoId);
            if(pvdo != null)
            {
                exist = true;
            }

            return exist;
        }
    }
}
