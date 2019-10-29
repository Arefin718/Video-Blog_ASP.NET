using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeEntity.Class
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string  Password { get; set; }
        public string Address { get; set; }
        public string SocialLink { get; set; }
        public string Image { get; set; }



        public List<Channel> Channels { get; set; }
        public List<Video> Videos { get; set; }
        public List<Subscription> Subscriptions { get; set; }
        public List<Comment> Comments { get; set; }
        public List<React> Reacts { get; set; }
        public List<Report> Reports { get; set; }
        public List<Playlist> Playlists { get; set; }
        public List<Notification> Notifications { get; set; }
        public List<PasswordRecovery> PasswordRecoverys { get; set; }

    }
}
