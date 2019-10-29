using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeEntity.Class
{
   public class PlaylistVideo: Entity
    {
        public int PlayListId { get; set; }
        public int VideoId { get; set; }


        [ForeignKey("PlayListId")]
        public Playlist Playlist { get; set; }

        [ForeignKey("VideoId")]
        public Video Video { get; set; }

    }
}
