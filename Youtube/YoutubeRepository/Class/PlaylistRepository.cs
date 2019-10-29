using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeEntity.Class;
using YoutubeRepository.Interface;

namespace YoutubeRepository.Class
{
    public class PlaylistRepository : Repository<Playlist>, IPlaylistRepository
    {
        DataContext context = new DataContext();

        public List<Playlist> GetPlaylistByUserId(int id)
        {
            return context.Playlists.AsNoTracking().Where(p => p.UserId == id).ToList();
        }
    }
}
