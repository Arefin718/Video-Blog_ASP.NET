using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeEntity.Class
{
    public class Notification : Entity
    {

        public string  Content { get; set; }
        public string  Time { get; set; }
        public int Status { get; set; }
        public string Type { get; set; }


        //Subscription
        //Comment
        //Like
        //Reply

        public int NotifiedBy { get; set; }
        public int NotifiedTo { get; set; }
        public int VideoId { get; set; }

        [ForeignKey("NotifiedBy")]
        public  User NotifiedByUser { get; set; }

        [ForeignKey("NotifiedTo")]
        public  User NotifiedToUser { get; set; }

        [ForeignKey("VideoId")]
        public Video Video { get; set; }
    }
}
