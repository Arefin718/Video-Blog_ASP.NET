using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeEntity.Class
{
    public class Subscription : Entity
    {
       
        public int SubscriberId { get; set; }
        public int ChannelId { get; set; }


        [ForeignKey("SubscriberId")]
        public User Subscriber { get; set; }

        [ForeignKey("ChannelId")]
        public Channel Channel { get; set; }

    }
}
