using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeEntity.Class
{
    public class React : Entity
    {
        public int UserId { get; set; }
        public int VideoId { get; set; }


        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("VideoId")]
        public Video Video { get; set; }

    }
}
