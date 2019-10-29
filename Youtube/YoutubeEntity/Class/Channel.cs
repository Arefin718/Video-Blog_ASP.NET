using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeEntity.Class
{
    public class Channel : Entity
    {
        public int UserId { get; set; }
        public string ChannelName { get; set; }
        public string ChannelDetails { get; set; }
        public string ChannelType { get; set; }
        public int Status { get; set; }

        public string ChannelImage { get; set; }


        [ForeignKey("UserId")]
        public User User { get; set; }

        public List<Video> Videos { get; set; }
        public List<Subscription> Subscriptions { get; set; }

    }
}
