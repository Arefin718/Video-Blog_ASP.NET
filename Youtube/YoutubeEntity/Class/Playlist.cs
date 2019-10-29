using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeEntity.Class
{
    public class Playlist:Entity
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
    


        [ForeignKey("UserId")]
        public User User { get; set; }

        public List<PlaylistVideo> PlaylistVideos { get; set; }

    }
}
