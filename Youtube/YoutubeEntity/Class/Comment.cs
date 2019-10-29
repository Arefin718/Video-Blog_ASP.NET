using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeEntity.Class
{
   public class Comment : Entity
    {
        public int UserId { get; set; }
        public int VideoId { get; set; }
        public string CommentContent { get; set; }
        public int ?ParentCommentId { get; set; }
        public string CommentTime { get; set; }



        [ForeignKey("UserId")]
        public User User { get; set; }

    }
}
