using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace YoutubeEntity.Class
{
    public class Report : Entity
    {
        public int UserId { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
        public string Details { get; set; }
        public string Time { get; set; }

        public int? VideoId { get; set; }
        public int? ChannelId { get; set; }


        [ForeignKey("UserId")]
        public User User { get; set; }


        [ForeignKey("VideoId")]
        public Video Video { get; set; }

        [ForeignKey("ChannelId")]
        public Channel Channel { get; set; }

    }
}
