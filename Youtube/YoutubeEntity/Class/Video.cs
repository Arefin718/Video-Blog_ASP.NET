using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeEntity.Class
{
    public class Video :  Entity
    {
        public string VideoURL { get; set; }
        public int ChannelId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UploadTime { get; set; }
        public int ViewCount { get; set; }
        public string Type { get; set; }
        public string Tag { get; set; }
        public int Status { get; set; }
        public string Poster { get; set; }
        public int  Approve { get; set; }

        [ForeignKey("ChannelId")]
        public Channel Channel { get; set; }


        public List<Comment> Comments { get; set; }
        public List<React> Reacts { get; set; }
        public List<Report> Reports { get; set; }
        public List<PlaylistVideo> PlaylistVideos { get; set; }

    }
}
